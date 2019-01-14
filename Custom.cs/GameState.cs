using System;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace Monitor
{
	public sealed class GameStateEventArgs : EventArgs
	{
		public int GameId { get; private set; }
		public GameStateEventArgs( int gameId ) { GameId = gameId; }
	}

	public sealed class GameState : IDisposable
	{
		public event EventHandler<GameStateEventArgs> GameStateChanged;
		private void OnGameStateChanged( GameStateEventArgs e )
		{
			EventHandler<GameStateEventArgs> handler = GameStateChanged;
			if( handler != null )
				handler( this, e );
		}


		private readonly BackgroundWorker bw;

		private void bw_DoWork( object sender, DoWorkEventArgs e )
		{
			Process iw3mp = null;

			bool last_game_flag = false;
			bool new_game_flag = false;

			bool game_detected = false;
			int gameID = 0;

			for( ; !bw.CancellationPending; Thread.Sleep( 500 ) )
			{
				//new_game_flag = false;
				game_detected = false;
				gameID = 0;

				try
				{
					iw3mp = Process.GetProcessesByName( "iw3mp" ).FirstOrDefault( s => s.MainWindowTitle == "Call of Duty 4" );
					if( iw3mp != null )
					{
						game_detected = true;
						gameID = iw3mp.Id;
					}
				}
				catch( InvalidOperationException ) { }
				catch( PlatformNotSupportedException ) { }

				last_game_flag = new_game_flag;
				new_game_flag = game_detected;

				if( new_game_flag != last_game_flag )
				{
					if( new_game_flag )
					{
						Thread.Sleep( 1000 );

						bw.ReportProgress( 1, gameID );
					}
					else
					{
						bw.ReportProgress( 0, 0 );
					}
				}
			}
		}

		private void bw_ProgressChanged( object sender, ProgressChangedEventArgs e )
		{
			OnGameStateChanged( new GameStateEventArgs( (int)e.UserState ) );
		}



		public bool IsAlive { get { return bw.IsBusy; } }



		public GameState()
		{
			bw = new BackgroundWorker();
			bw.WorkerReportsProgress = true;
			bw.WorkerSupportsCancellation = true;

			bw.DoWork += bw_DoWork;
			bw.ProgressChanged += bw_ProgressChanged;
		}

		public void Dispose()
		{
			bw.Dispose();
			GC.SuppressFinalize( this );
		}



		public void RunMonitor()
		{
			if( bw.IsBusy )
				return;

			bw.RunWorkerAsync();
		}

		public void StopMonitor()
		{
			bw.CancelAsync();
		}
	}
}