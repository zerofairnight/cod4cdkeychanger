using System;
using System.ComponentModel;

namespace QuakeSocket
{
	internal class QuakeServer : IDisposable
	{
		public static readonly string HostName = "cod4master.activision.com";

		public bool IsStarted { get; private set; }

		public int Port { get; private set; }

		public string HostAddress { get; private set; }

		public string LocalAddress { get; private set; }

		public string Challange { get; private set; }

		public bool TestResponse { get; private set; }


		public readonly QuakeClient quakeClient = new QuakeClient();


		///<summary>
		/// Initializes a new instance of the QuakeServer class.
		/// </summary>
		public QuakeServer( string overrideHostAddress = null, string overrideLocalAddress = null )
		{
			const int localMinPort = 28960;
			const int localMaxPort = 28970;

			HostAddress = overrideHostAddress;
			LocalAddress = overrideLocalAddress;

			BackgroundWorker _bw = new BackgroundWorker();

			_bw.DoWork += ( _, e ) =>
			{
				if( HostAddress == null )
				{
					string s;
					if( !IPValidator.Resolve( HostName, out s ) )
						return;

					HostAddress = s;
				}
				if( LocalAddress == null )
				{
					string s;
					if( !IPValidator.ResolveOutside( out s ) )
						return;

					LocalAddress = s;
				}

				if( !quakeClient.SetUpListener( LocalAddress, localMinPort, localMaxPort ) )
					return;

				Port = quakeClient.Port;

				for( int i = 0; i < 5; i++ )
				{
					string __challange = null;
					quakeClient.SendHeartbeatFlatline( HostName );
					quakeClient.SendHeartbeat( HostName );

					// Get Challange
					if( !quakeClient.Receive( out __challange ) )
						continue;

					// Get Status
					if( !quakeClient.Receive( out __challange ) )
						continue;

					if( __challange != null )
					{
						Challange = __challange.Split( ' ' )[1].TrimEnd( '\0' );
						break;
					}
				}
				if( Challange == null )
				{
					quakeClient.SendHeartbeatFlatline( HostName );
					return;
				}

				for( int i = 0; i < 5; i++ )
				{

					string __rndChallange = new Random( (int)DateTime.Now.Ticks ).Next( 1000000000, 2000000000 ).ToString();

					quakeClient.SendGetIPAuthorize( HostName, Challange, HostAddress );
					quakeClient.SendGetIPAuthorize( HostName, __rndChallange, "0.0.0.0", "e" );

					string s = null;
					if( !quakeClient.Receive( out s ) )
						continue;

					if( s != null )
					{
						TestResponse = true;
						break;
					}
				}
			};
			_bw.RunWorkerCompleted += ( _, e ) =>
			{
				IsStarted = true;
				_bw.Dispose();
			};

			_bw.RunWorkerAsync();
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
				if( quakeClient != null )
				{
					quakeClient.Dispose();
				}
			}
		}
		~QuakeServer()
		{
			Dispose( false );
		}

		#endregion
	}
}
