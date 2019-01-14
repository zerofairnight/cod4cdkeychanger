using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;


using GlobalSettings = ZsTemplate.Properties.Settings;

namespace ZsTemplate
{
	struct RuleSet
	{ 
	
	}

	struct KeyCode
	{
		string Node { get; set; }	// 'Activision\Call of duty bla bla'
		string Value { get; set; }	// 'cdkey'
	}


	static class CdGuid
	{
		internal static string Get( string cdKey )
		{
			string cdGuid;
			Get( cdKey, out cdGuid );
			return cdGuid;
		}

		internal static ErrorState Get( string cdKey, out string cdGuid )
		{
			cdGuid = null;

			if( !CdKey.Key.IsValid( cdKey ) )
				return ErrorState.CDKey;

			try
			{
				cdGuid = NativeMethods.GetPunkBusterGuid( cdKey.ToLowerInvariant().Remove( 16 ), 0x00b684a3 );
			}
			catch( DllNotFoundException ) 
			{
				return ErrorState.DllNotFound;
			}

			if( cdGuid != null && cdGuid.Length == 32 )
			{
				return ErrorState.None;
			}

			return ErrorState.CDGuid;
		}

		internal static bool IsValid( string cdGuid )
		{
			return cdGuid != null && cdGuid.Length == 32;
		}
	}

	static class CdKey
	{
		internal static ErrorState Inject( int GameID, string cdKey )
		{
			if( !Key.IsValid( cdKey ) )
				return ErrorState.CDKey;

			if( GameID == 0 )
				return ErrorState.GameHandle;

			try
			{
				byte[] b =
				Encoding.ASCII.GetBytes(
					string.Concat( cdKey.Remove( 16 ), "\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00\x00", cdKey.Substring( 16 ) )
				);

				IntPtr cod;

				using( System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById( GameID ) )
				{
					if( process.HandleCount < 1 )
						return ErrorState.Injection;

					cod = NativeMethods.OpenProcess( 0x1F0FFF, true, GameID );
				}

				NativeMethods.WriteProcessMemory( cod, (IntPtr)0x00724B84, b, (UIntPtr)b.Length, UIntPtr.Zero );
				NativeMethods.CloseHandle( cod );


				//IntPtr cod = MemoryOpen( GameID );
				//MemoryWrite( cod, 0x00724B84, b );
				//MemoryClose( cod );
			}
			catch
			{
				return ErrorState.Injection;
			}

			return ErrorState.None;
		}



		public static string GetHash( string cd1 )
		{
			int v2 = 0;
			for( int i = 0; i < 16; i++ )
			{
				v2 ^= cd1[i];
				for( int j = 1; j < 9; j++ )
				{
					if( (v2 & 1) != 0 )
						v2 ^= 0x14002;
					v2 >>= 1;
				}
			}

			return String.Format( CultureInfo.InvariantCulture, "{0:X4}", v2 );
		}



		public static string GenerateUnique()
		{
			string cd1 = null;
			{
				using( RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider() )
				{
					byte[] data = new byte[1];
					crypto.GetNonZeroBytes( data );

					data = new byte[16];
					crypto.GetNonZeroBytes( data );

					StringBuilder result = new StringBuilder( 16 );
					char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
					foreach( byte b in data )
						result.Append( chars[b % (chars.Length - 1)] );

					cd1 = result.ToString();
				}
			}
			return cd1 + GetHash( cd1 );
		}

		public static string GenerateOriginal()
		{
			StringCollection keys = GlobalSettings.Default.CDKeys;
			if( keys.Count > 0 )
				return keys[new Random( DateTime.Now.Millisecond ).Next( keys.Count )];

			return string.Empty;
		}


		internal static class Reg
		{
			public static string Get( string value )
			{
				List<string> list = new List<string>();

				list.Add( @"HKEY_LOCAL_MACHINE\SOFTWARE\Activision\Call of Duty 4" );
				list.Add( @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Activision\Call of Duty 4" );
				list.Add( value );

				string reg = null;

				foreach( string s in list ) if( IsValid( s ) ) reg = s;

				return reg;
			}

			public static bool IsValid( string value )
			{
				return IsValidAsErrorState( value ) == ErrorState.None;
			}

			public static ErrorState IsValidAsErrorState( string value )
			{
				if( string.IsNullOrEmpty( value ) )
					return ErrorState.RegistryEmpty;

				else if( value.StartsWith( "HKEY_CURRENT_USER", StringComparison.OrdinalIgnoreCase ) ) { }
				else if( value.StartsWith( "HKEY_LOCAL_MACHINE", StringComparison.OrdinalIgnoreCase ) ) { }
				else if( value.StartsWith( "HKEY_CLASSES_ROOT", StringComparison.OrdinalIgnoreCase ) ) { }
				else if( value.StartsWith( "HKEY_USERS", StringComparison.OrdinalIgnoreCase ) ) { }
				else if( value.StartsWith( "HKEY_CURRENT_CONFIG", StringComparison.OrdinalIgnoreCase ) ) { }
				else return ErrorState.RegistryRoot;

				if( !value.EndsWith( "Activision\\Call of Duty 4", StringComparison.OrdinalIgnoreCase ) )
					return ErrorState.RegistryPeak;

				try
				{
					if( Registry.GetValue( value, "codkey", null ) == null )
						return ErrorState.Registry;
				}
				catch( System.Security.SecurityException )
				{
					return ErrorState.RegistrySecurityGet;
				}
				catch( System.IO.IOException )
				{
					return ErrorState.RegistryIO;
				}

				return ErrorState.None;
			}
		}

		internal static class Key
		{
			internal static ErrorState Get( string registryKey, out string cdKey )
			{
				cdKey = null;
				ErrorState errorState = Reg.IsValidAsErrorState( registryKey );
				if( errorState != ErrorState.None )
					return errorState;

				cdKey = Registry.GetValue( registryKey, "codkey", string.Empty ).ToString();

				return ErrorState.None;
			}

			internal static ErrorState Set( string registryKey, string cdKey )
			{
				if( !IsValid( cdKey ) )
					return ErrorState.CDKey;

				try
				{
					ErrorState errorState = Reg.IsValidAsErrorState( registryKey );
					if( errorState != ErrorState.None )
						return errorState;

					Registry.SetValue( registryKey, "codkey", cdKey );
				}
				catch( System.Security.SecurityException )
				{
					return ErrorState.RegistrySecuritySet;
				}
				catch( UnauthorizedAccessException )
				{
					return ErrorState.RegistryUnauthorizedAccess;
				}

				return ErrorState.None;
			}

			internal static bool IsValid( string value )
			{
				return IsValidAsErrorState( value ) == ErrorState.None;
			}

			public static ErrorState IsValidAsErrorState( string value )
			{
				if( value != null && value.Length == 20 )
				{
					string cd1 = value.Remove( 16 );
					string cd2 = value.Substring( 16 );

					return GetHash( cd1 ) == cd2 ? ErrorState.None : ErrorState.CDKey;
				}
				return ErrorState.CDKey;
			}
		}
	}
}

