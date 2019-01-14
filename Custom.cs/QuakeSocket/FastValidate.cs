using System;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ZsTemplate;

namespace QuakeSocket
{
	public enum ReportStatus
	{
		OnlineValid,
		OnlineInvalid,
		UnknowAuth,

		InvalidKey,
		InvalidGuid,

		DllNotFound,

		InactiveLocalServer,

		UnresolvedHostName,
		UnresolvedLocalName,
		UnresolvedClient,

		UnresolvedChallange,
		UnresolvedTestResponse,
		UnresolvedResponse,

		IncorrectResponse
	}

	public static class ReportStatusMessage
	{
		public static string ToMessage( this ReportStatus status )
		{
			switch( status )
			{
				case ReportStatus.OnlineValid:
					return global::ZsTemplate.Languages.ReportStatus.String.OnlineValid;
				case ReportStatus.OnlineInvalid:
					return global::ZsTemplate.Languages.ReportStatus.String.OnlineInvalid;
				case ReportStatus.UnknowAuth:
					return global::ZsTemplate.Languages.ReportStatus.String.UnknowAuth;

				case ReportStatus.InvalidKey:
					return global::ZsTemplate.Languages.ReportStatus.String.InvalidKey;
				case ReportStatus.InvalidGuid:
					return global::ZsTemplate.Languages.ReportStatus.String.InvalidGuid;
				case ReportStatus.DllNotFound:
					return global::ZsTemplate.Languages.ReportStatus.String.DllNotFound;

				case ReportStatus.InactiveLocalServer:
					return global::ZsTemplate.Languages.ReportStatus.String.InactiveLocalServer;
				case ReportStatus.UnresolvedHostName:
					return global::ZsTemplate.Languages.ReportStatus.String.UnresolvedHostName;
				case ReportStatus.UnresolvedLocalName:
					return global::ZsTemplate.Languages.ReportStatus.String.UnresolvedLocalName;
				case ReportStatus.UnresolvedClient:
					return global::ZsTemplate.Languages.ReportStatus.String.UnresolvedClient;
				case ReportStatus.UnresolvedChallange:
					return global::ZsTemplate.Languages.ReportStatus.String.UnresolvedChallange;
				case ReportStatus.UnresolvedTestResponse:
					return global::ZsTemplate.Languages.ReportStatus.String.UnresolvedTestResponse;
				case ReportStatus.UnresolvedResponse:
					return global::ZsTemplate.Languages.ReportStatus.String.UnresolvedResponse;
				case ReportStatus.IncorrectResponse:
					return global::ZsTemplate.Languages.ReportStatus.String.IncorrectResponse;
			}

			return null;
		}
	}



	public class ValidationCompletedEvent : EventArgs
	{
		public ReportStatus Status { get; private set; }
		public int Hash { get; private set; }

		public ValidationCompletedEvent( ReportStatus status, int hash )
		{
			Status = status;
			Hash = hash;
		}
	}


	internal class FastValidate : IDisposable
	{
		public event EventHandler<ValidationCompletedEvent> ValidationCompleted;

		private void OnValidationCompleted( ReportStatus status, int hash )
		{
			if( ValidationCompleted != null )
				ValidationCompleted( this, new ValidationCompletedEvent( status, hash ) );
		}

		BackgroundWorker bw = new BackgroundWorker();

		private readonly QuakeServer _quakeServer;

		/// <summary>
		/// Initializes a new instance of the FastValidate class.
		/// </summary>
		public FastValidate( QuakeServer quakeServer )
		{
			_quakeServer = quakeServer;
		}

		public void Validate( string cdKey )
		{
			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = true;
			bw.DoWork += bw_DoWork;
			bw.RunWorkerCompleted += bw_RunWorkerCompleted;
			bw.RunWorkerAsync( new string[] { cdKey } );
		}


		void bw_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			ReportStatus status;
			int hash;
			FromEvent( e.Result, out status, out hash );

			OnValidationCompleted( status, hash );
		}

		private object ToEvent( ReportStatus status, int hash )
		{
			return new object[] { status, hash };
		}

		private void FromEvent( object fromevent, out ReportStatus status, out int hash )
		{
			object[] obj = fromevent as object[];

			status = (ReportStatus)obj[0];
			hash = (int)obj[1];
		}


		void bw_DoWork( object sender, DoWorkEventArgs e )
		{
			string[] args = e.Argument as string[];
			string cdKey = args[0];
			string cdGuid = null;

			int hash = cdKey.GetHashCode();

			switch( CdGuid.Get( cdKey, out cdGuid ) )
			{
				case ErrorState.CDKey:
					e.Result = ToEvent( ReportStatus.InvalidKey, hash );
					return;
				case ErrorState.CDGuid:
					e.Result = ToEvent( ReportStatus.InvalidGuid, hash );
					return;
				case ErrorState.DllNotFound:
					e.Result = ToEvent( ReportStatus.DllNotFound, hash );
					return;
				default:
					e.Result = ToEvent( ReportStatus.OnlineInvalid, hash );
					break;
			}

			cdKey = cdKey.Remove( 16 );

			if( !_quakeServer.IsStarted )
			{
				for( int i = 0; i < 5; i++ ) if( !_quakeServer.IsStarted )
						System.Threading.Thread.Sleep( 1000 );
			}

			if( !_quakeServer.IsStarted )
			{
				e.Result = ToEvent( ReportStatus.InactiveLocalServer, hash );
				return;
			}
			if( _quakeServer.HostAddress == null )
			{
				e.Result = ToEvent( ReportStatus.UnresolvedHostName, hash );
				return;
			}
			if( _quakeServer.LocalAddress == null )
			{
				e.Result = ToEvent( ReportStatus.UnresolvedLocalName, hash );
				return;
			}
			if( _quakeServer.Port == 0 )
			{
				e.Result = ToEvent( ReportStatus.UnresolvedClient, hash );
				return;
			}
			if( _quakeServer.Challange == null )
			{
				e.Result = ToEvent( ReportStatus.UnresolvedChallange, hash );
				return;
			}
			if( !_quakeServer.TestResponse )
			{
				e.Result = ToEvent( ReportStatus.UnresolvedTestResponse, hash );
				return;
			}

			string s = null;
			for( int i = 0; i < 5; i++ )
			{
				string __rndChallange = new Random( (int)DateTime.Now.Ticks ).Next( 1000000000, 2000000000 ).ToString();

				_quakeServer.quakeClient.SendGetIPAuthorize( QuakeServer.HostName, __rndChallange, _quakeServer.LocalAddress, cdGuid );

				if( !_quakeServer.quakeClient.Receive( out s ) )
					continue;

				if( s != null && s.Contains( "CLIENT_UNKNOWN_TO_AUTH" ) )
					_quakeServer.quakeClient.SendGetKeyAuthorize( QuakeServer.HostName, cdKey, cdGuid );
				else break;
			}
			if( s == null )
			{
				e.Result = ToEvent( ReportStatus.UnresolvedResponse, hash );
				return;
			}
			else if( s.Contains( "KEY_IS_GOOD" ) )
			{
				e.Result = ToEvent( ReportStatus.OnlineValid, hash );
				return;
			}
			else if( s.Contains( "INVALID_CDKEY" ) )
			{
				e.Result = ToEvent( ReportStatus.OnlineInvalid, hash );
				return;
			}
			else if( s.Contains( "CLIENT_UNKNOWN_TO_AUTH" ) )
			{
				e.Result = ToEvent( ReportStatus.UnknowAuth, hash );
				return;
			}
			else
			{
				e.Result = ToEvent( ReportStatus.IncorrectResponse, hash );
				return;
			}
		}


		public void Abort()
		{
			if( bw != null )
			{
				bw.Dispose();
				bw = null;
			}
		}

		#region Dispose

		/// <summary>
		/// Releases all resources used by System.ComponentModel.Component
		/// </summary>
		public void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}
		protected virtual void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( bw != null )
				{
					bw.Dispose();
				}
			}
		}
		~FastValidate()
		{
			Dispose( false );
		}

		#endregion
	}
}
