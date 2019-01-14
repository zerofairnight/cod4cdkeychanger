using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;


using GlobalSettings = ZsTemplate.Properties.Settings;

namespace ZsTemplate.Properties
{


	// La classe consente la gestione di eventi specifici sulla classe delle impostazioni:
	//  L'evento SettingChanging viene generato prima della modifica di un valore dell'impostazione.
	//  L'evento PropertyChanged viene generato dopo la modifica di un valore dell'impostazione.
	//  L'evento SettingsLoaded viene generato dopo il caricamento dei valori dell'impostazione.
	//  L'evento SettingsSaving viene generato prima del salvataggio dei valori dell'impostazione.
	internal sealed partial class Settings
	{

		public Settings()
		{
			// // Per aggiungere gestori eventi per il salvataggio e la modifica delle impostazioni, rimuovere i commenti dalle righe seguenti:
			//
			// this.SettingChanging += this.SettingChangingEventHandler;
			//
			// this.SettingsSaving += this.SettingsSavingEventHandler;
			//
		}

		private void SettingChangingEventHandler( object sender, System.Configuration.SettingChangingEventArgs e )
		{
			// Aggiungere qui il codice per gestire l'evento SettingChangingEvent.
		}

		private void SettingsSavingEventHandler( object sender, System.ComponentModel.CancelEventArgs e )
		{
			// Aggiungere qui il codice per gestire l'evento SettingsSaving.
		}
	}
}

namespace ZsTemplate
{

	internal static class Settings
	{
		private static T Calmp<T>( T value, T minValue, T maxValue ) where T : IComparable
		{
			if( value.CompareTo( minValue ) < 0 )
				return minValue;
			if( value.CompareTo( maxValue ) > 0 )
				return maxValue;

			return value;
		}

		public static void Load()
		{
			if( !GlobalSettings.Default.IsSynchronized )
				GlobalSettings.Default.Reload();
			{

				if( string.IsNullOrEmpty( GlobalSettings.Default.Language ) )
					GlobalSettings.Default.Language = "none";

				switch( GlobalSettings.Default.Language )
				{
					case "it-IT":
						break;
					case "en":
						break;
					default: GlobalSettings.Default.Language = CultureInfo.CurrentUICulture.Name;
						break;
				}

			}
			{
				GlobalSettings.Default.MaskValue = Calmp( GlobalSettings.Default.MaskValue, 0, 4 );
				GlobalSettings.Default.RegPath = ZsTemplate.CdKey.Reg.Get( GlobalSettings.Default.RegPath );
			}
			{
				StringCollection keys = new StringCollection();
				foreach( string s1 in GlobalSettings.Default.CDKeys )
				{
					if( !string.IsNullOrEmpty( s1 ) )
					{
						var r = SecureString.Decrypt( s1 );
						if( ZsTemplate.CdKey.Key.IsValid( r ) )
							if( !keys.Contains( r ) )
								keys.Add( r );
					}
				}
				GlobalSettings.Default.CDKeys = keys;
			}
		}

		public static void Save()
		{
			GlobalSettings.Default.Save();
		}
	}
}
