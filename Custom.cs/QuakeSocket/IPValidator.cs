using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace QuakeSocket
{
	internal static class IPValidator
	{
		private static bool IsLocalIpAddress( string host )
		{
			try
			{
				IPAddress[] hostIPs = Dns.GetHostAddresses( host );
				IPAddress[] localIPs = Dns.GetHostAddresses( Dns.GetHostName() );

				foreach( IPAddress hostIP in hostIPs )
				{
					if( IPAddress.IsLoopback( hostIP ) )
						return true;

					foreach( IPAddress localIP in localIPs )
						if( hostIP.Equals( localIP ) )
							return true;
				}
			}
			catch( ArgumentException ) { }
			catch( SocketException ) { }

			return false;
		}

		public static bool ResolveOutside( out string hostAddress )
		{
			hostAddress = null;
			try
			{
				WebRequest myWebRequest = WebRequest.Create( "http://icanhazip.com/" );
				myWebRequest.Timeout = 5000;

				using( WebResponse myWebResponse = myWebRequest.GetResponse() )
				{
					byte[] read = new byte[12];
					myWebResponse.GetResponseStream().Read( read, 0, read.Length );
					hostAddress = Encoding.ASCII.GetString( read ).Trim();
					return true;
				}
			}
			catch( WebException ) { }

			return false;
		}

		public static bool Resolve( string hostNameOrAddress, out string hostAddress )
		{
			hostAddress = null;
			try
			{
				IPAddress[] v_IPAddress = Dns.GetHostAddresses( hostNameOrAddress );
				if( v_IPAddress.Length > 0 && v_IPAddress[0].AddressFamily == AddressFamily.InterNetwork )
				{
					hostAddress = v_IPAddress[0].ToString();
					return true;
				}
			}
			catch( ArgumentException ) { }
			catch( SocketException ) { }

			return false;
		}

		public static bool Resolve( string hostNameOrAddress, out string hostAddress, out int hostPort )
		{
			hostAddress = null;
			hostPort = 28960;

			if( string.IsNullOrEmpty( hostNameOrAddress ) || hostNameOrAddress.Length >= 255 )
				return false;

			if( hostNameOrAddress.Contains( ":" ) )
			{
				string locPort = hostNameOrAddress.Split( ':' )[1];
				if( !string.IsNullOrEmpty( locPort ) )
				{
					StringBuilder sb = new StringBuilder();
					foreach( char c in locPort ) if( char.IsNumber( c ) ) sb.Append( c );

					locPort = sb.ToString();

					if( !string.IsNullOrEmpty( locPort ) )
						hostPort = int.Parse( locPort, CultureInfo.InvariantCulture );

					if( hostPort < 1 )
						return false;
				}
				hostNameOrAddress = hostNameOrAddress.Split( ':' )[0];
			}

			return Resolve( hostNameOrAddress, out hostAddress );
		}
	}
}
