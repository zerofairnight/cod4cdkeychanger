using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;

namespace SingleInstance
{
	sealed partial class SingleInstanceController : MarshalByRefObject, IDisposable
	{
		public delegate void ReceiveDelegate( string[] args );

		// HACK : use non static parameter for disallow compile error
		private string[] args;



		public bool IsSingle()
		{
			args = null;
			s_Mutex = new Mutex( false, s_Guid );
			if( s_Mutex.WaitOne( 0, true ) )
			{
				return true;
			}
			else
			{
				s_Mutex.Close();
				s_Mutex = null;

				return false;
			}
		}

		public bool IsSingle( ReceiveDelegate r )
		{
			Receiver += r;

			return IsSingle();
		}
		//
		public bool IsSingle( string guid, int port )
		{
			s_Guid = guid;
			s_Port = port;

			return IsSingle();
		}

		public bool IsSingle( string guid, int port, ReceiveDelegate r )
		{
			s_Guid = guid;
			s_Port = port;
			Receiver += r;

			return IsSingle();
		}

		//
		public bool IsSingle( string guid )
		{
			s_Guid = guid;

			return IsSingle();
		}

		public bool IsSingle( string guid, ReceiveDelegate r )
		{
			s_Guid = guid;
			Receiver += r;

			return IsSingle();
		}



		public void Dispose()
		{
			if( s_Mutex != null )
			{
			//	m_Mutex.ReleaseMutex();
				s_Mutex.Close();
				s_Mutex.Dispose();
			}

			if( s_TCPChannel != null )
			{
				s_TCPChannel.StopListening( null );
			}

			
			s_Mutex = null;
			s_TCPChannel = null;
		}



		public void CreateChannel( ReceiveDelegate r )
		{
			args = null;
			Receiver += r;

			CreateInstanceChannel();
		}

		public void CreateChannel()
		{
			args = null;
			s_TCPChannel = new TcpChannel( s_Port );

			ChannelServices.RegisterChannel( s_TCPChannel, false );

			RemotingConfiguration.RegisterWellKnownServiceType(
				typeof( SingleInstanceController ),
				s_Guid,
				WellKnownObjectMode.SingleCall
			);
		}



		public void Receive( string[] s )
		{
			args = s;

			if( Receiver != null )
				Receiver( args );
		}

		public void Send( string[] s )
		{
			args = s;

			SingleInstanceController ctrl;
			TcpChannel channel = new TcpChannel();
			ChannelServices.RegisterChannel( channel, false );

			ctrl = (SingleInstanceController)Activator.GetObject(
				typeof( SingleInstanceController ),
				string.Concat( "tcp://localhost:", s_Port, "/", s_Guid )
			);

			ctrl.Receive( args );
		}
	}

	sealed partial class SingleInstanceController
	{
		public static ReceiveDelegate Receiver { get; set; }

		private static TcpChannel s_TCPChannel;
		private static Mutex s_Mutex;

		private static int s_Port = 1234;
		private static string s_Guid = System.Reflection.Assembly.GetExecutingAssembly().GetName( false ).CodeBase.Replace( "\\", "_" );



		public static void CreateInstanceChannel( ReceiveDelegate r )
		{
			Receiver += r;

			CreateInstanceChannel();
		}

		public static void CreateInstanceChannel()
		{
			s_TCPChannel = new TcpChannel( s_Port );

			ChannelServices.RegisterChannel( s_TCPChannel, false );

			RemotingConfiguration.RegisterWellKnownServiceType(
				typeof( SingleInstanceController ),
				s_Guid,
				WellKnownObjectMode.SingleCall
			);
		}



		public static void InstanceSend( string[] s )
		{
			SingleInstanceController ctrl;
			TcpChannel channel = new TcpChannel();
			ChannelServices.RegisterChannel( channel, false );

			ctrl = (SingleInstanceController)Activator.GetObject(
				typeof( SingleInstanceController ),
				string.Concat( "tcp://localhost:", s_Port, "/", s_Guid )
			);

			ctrl.Receive( s );
		}
	}
}
