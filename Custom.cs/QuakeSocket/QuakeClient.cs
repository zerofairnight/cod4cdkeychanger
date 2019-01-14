using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace QuakeSocket
{
	internal class QuakeClient : IDisposable
	{
		private readonly Encoding encoding;
		private UdpClient quakeUdpClient;

		public string Address { get; private set; }
		public int Port { get; private set; }

		public bool IsAlive { get; private set; }

		/// <summary>
		/// Initializes a new instance of the QuakeUdpClient class.
		/// </summary>
		public QuakeClient()
		{
			encoding = Encoding.GetEncoding( 1252 );
			quakeUdpClient = null;
		}

		public bool SetUpListener( string address, int startPort, int lastPort )
		{
			for( int port = startPort; port < lastPort; port++ )
			{
				try
				{
					quakeUdpClient = new UdpClient( port );

					quakeUdpClient.Client.SendTimeout = 1000;
					quakeUdpClient.Client.ReceiveTimeout = 1000;

					Address = address;
					Port = port;

					IsAlive = true;
					return true;
				}
				catch( ArgumentOutOfRangeException ) { }
				catch( SocketException ) { }

				if( quakeUdpClient != null )
				{
					quakeUdpClient.Close();
					quakeUdpClient = null;
				}

				IsAlive = false;
			}

			return false;
		}


		public bool Send( string hostName, int port, string value )
		{
			if( !IsAlive )
				return false;

			byte[] b = encoding.GetBytes( value );

			try
			{
				quakeUdpClient.Send( b, b.Length, hostName, port );
				return true;
			}
			catch( SocketException ) { }
			return false;
		}

		public bool Receive( out string receiverData )
		{
			receiverData = null;

			if( !IsAlive )
				return false;
			try
			{
				IPEndPoint ep = new IPEndPoint( IPAddress.Any, 0 );
				receiverData = encoding.GetString( quakeUdpClient.Receive( ref ep ) );
				return true;
			}
			catch( SocketException ) { }
			return false;
		}



		/// <summary>
		/// Send heartbeat request that advise the masterserver that we have start up the server.
		/// </summary>
		/// <param name="hostName">Quake master server, cod4master.activision.com</param>
		/// <returns>True if no errors have occurred, false otherwise</returns>
		public bool SendHeartbeat( string hostName )
		{
			return Send( hostName, 20810, string.Concat( "\xff\xff\xff\xff",
				"heartbeat COD-4" )
			);
		}

		/// <summary>
		/// Send heartbeat flatline request that advise the masterserver that we have shut down the server.
		/// </summary>
		/// <param name="hostName">Quake master server, cod4master.activision.com</param>
		/// <returns>True if no errors have occurred, false otherwise</returns>
		public bool SendHeartbeatFlatline( string hostName )
		{
			return Send( hostName, 20810, string.Concat( "\xff\xff\xff\xff",
				"heartbeat flatline" )
			);
		}

		/// <summary>
		/// Send getIpAuthorize request that tell the master server that we have retrive his challange ID.
		/// </summary>
		/// <param name="hostName">Quake master server, cod4master.activision.com</param>
		/// <param name="challange">The retrived challange ID.</param>
		/// <param name="hostAddress">Quake master server ipv4, IPV4( cod4master.activision.com )</param>
		/// <returns>True if no errors have occurred, false otherwise</returns>
		public bool SendGetIPAuthorize( string hostName, string challange, string hostAddress )
		{
			return Send( hostName, 20800, string.Concat( "\xff\xff\xff\xff",
				string.Format( System.Globalization.CultureInfo.InvariantCulture,
					"getIpAuthorize {0} {1} \"\" 0",
					challange,
					hostAddress ) ) );
		}

		/// <summary>
		/// Send getIpAuthorize request that ask the master server to validate the cdGuid.
		/// </summary>
		/// <param name="hostName">Quake master server, cod4master.activision.com</param>
		/// <param name="randomChallange">Any random challange from (1 to 2)*10^9</param>
		/// <param name="clientAddress">The client address, that have send the getKeyAuthorize request</param>
		/// <param name="cdGuid">The cdGuid from the getKeyAuthorize request</param>
		/// <returns>True if no errors have occurred, false otherwise</returns>
		/// <remarks>Ask for a response that should contain
		/// 'KEY_IS_GOOD', cdKey is valid
		/// 'INVALID_CDKEY', cdguid is already in use
		/// 'CLIENT_UNKNOWN_TO_AUTH', send getKeyAuthorize first
		/// </remarks>
		public bool SendGetIPAuthorize( string hostName, string randomChallange, string clientAddress, string cdGuid )
		{
			return Send( hostName, 20800, string.Concat( "\xff\xff\xff\xff",
				string.Format( System.Globalization.CultureInfo.InvariantCulture,
					"getIpAuthorize {0} {1} \"\" 0 PB \"{2}\"",
					randomChallange,
					clientAddress,
					cdGuid ) )
			);
		}


		/// <summary>
		/// Send getKeyAuthorize request that ask the master server to check this keycode.
		/// </summary>
		/// <param name="hostName">Quake master server, cod4master.activision.com</param>
		/// <param name="cdKey">Frist 16 char of the 20 len char cdKey</param>
		/// <param name="cdGuid">The cdGuid from the cdKey</param>
		/// <returns>True if no errors have occurred, false otherwise</returns>
		public bool SendGetKeyAuthorize( string hostName, string cdKey, string cdGuid )
		{
			return Send( hostName, 20800, string.Concat( "\xff\xff\xff\xff",
				string.Format( System.Globalization.CultureInfo.InvariantCulture,
					"getKeyAuthorize 0 {0} PB {1}",
					cdKey,
					cdGuid ) )
			);
		}

		/// <summary>
		/// Send getChallenge request that ask the server to validate the cdGuid.
		/// </summary>
		/// <param name="serverName">Quake server, any address</param>
		/// <param name="serverPort">Quake server, any port</param>
		/// <param name="cdGuid"></param>
		/// <returns>True if no errors have occurred, false otherwise</returns>
		/// <remarks>Ask for a response that should contain
		/// 'needcdkey', send getKeyAuthorize first
		/// 'EXE_ERR_BAD_CDKEY', cdguid is invalid, key is invalid
		/// 'EXE_ERR_CDKEY_IN_USE', cdKey already in use
		/// 'challengeResponse', cdKey is valid
		/// </remarks>
		public bool SendGetChallenge( string serverName, int serverPort, string cdGuid )
		{
			return Send( serverName, serverPort, string.Concat( "\xff\xff\xff\xff",
				string.Format( System.Globalization.CultureInfo.InvariantCulture,
					"getChallenge 0 \"{0}\"",
					cdGuid ) )
			);
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
				IsAlive = false;
				if( quakeUdpClient != null )
				{
					quakeUdpClient.Close();
				}
			}
		}
		~QuakeClient()
		{
			Dispose( false );
		}

		#endregion
	}
}
