using System;
using System.Windows.Forms;

using SingleInstance;
using GlobalSettings = ZsTemplate.Properties.Settings;

namespace ZsTemplate
{
	static class Program
	{
		[STAThread]
		static void Main( string[] args )
		{
			try
			{
				using( SingleInstanceController controller = new SingleInstanceController() )
				{
					if( controller.IsSingle( "{23D5DB57-EB0C-44A3-AC80-0515D8F23471}" ) )
					{
						if( !Arguments.Process( args ) )
						{
							Application.EnableVisualStyles();
							Application.SetCompatibleTextRenderingDefault( false );
							Application.Run( new ZsForm() );
						}
					}
				}
			}
			catch( Exception ex )
			{
				MessageBox.Show( ex.Message );
			}
		}
	}

	static class Arguments
	{
		public static bool Process( string[] args )
		{
			Settings.Load();
			if( args.Length > 0 )
				switch( args[0] )
				{
					case "-cracked":
						//handle_errorstate( CdKey.Key.Set( ZsTemplate.Properties.Settings.Default.RegPath, CdKey.GenerateUnique() ) );
						return true;

					case "-restore":
						//handle_errorstate( CdKey.Key.Set( ZsTemplate.Properties.Settings.Default.RegPath, CdKey.GenerateOriginal() ) );
						return true;

					default:
						break;
				}

			return false;
		}
	}
}


