using GlobalSettings = ZsTemplate.Properties.Settings;
using System.Text;
using System;


namespace System.Security.Cryptography
{
	public static class SecureString
	{
		private static string Mask( string value, char mask, int maskedChar, bool escape )
		{
			int value_len = value.Length;

			if( value == null || !escape || maskedChar > value_len )
				return value;

			StringBuilder sb = new StringBuilder( value.Remove( value_len - maskedChar ), value_len );
			for( int i = 0; i < maskedChar; i++ )
				sb.Append( mask );

			return sb.ToString();
		}

		//
		public static string Mask( string value, bool escape )
		{
			if( GlobalSettings.Default.HashMask )
				return HashedMask( value );

			return Mask( value, GlobalSettings.Default.MaskChar, 4 * GlobalSettings.Default.MaskValue, escape );
		}

		public static string Mask( string value )
		{
			if( GlobalSettings.Default.HashMask )
				return HashedMask( value );

			return Mask( value, GlobalSettings.Default.MaskChar, 4 * GlobalSettings.Default.MaskValue, true );
		}

		public static string HashedMask( string cd_key )
		{
			return HashedMask( cd_key, GlobalSettings.Default.MaskChar );
		}
		public static string HashedMask( string cd_key, char mask )
		{
			if( cd_key.Length != 20 )
				return cd_key;

			StringBuilder sb = new StringBuilder( 20 );
			for( int i = 0; i < 16; i++ )
				sb.Append( mask );

			sb.Append( ZsTemplate.CdKey.GetHash( cd_key ) );

			return sb.ToString();
		}





		private const string cypPassword = "YVYcW5FHC1ECOtlkT2uW";


		public static string Crypt( string value )
		{
			using( TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider() )
			using( MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider() )
			{
				des.Key = hashmd5.ComputeHash( ASCIIEncoding.ASCII.GetBytes( cypPassword ) );
				des.Mode = CipherMode.ECB;
				using( ICryptoTransform desdencrypt = des.CreateEncryptor() )
				{
					byte[] buff = ASCIIEncoding.ASCII.GetBytes( value );
					buff = desdencrypt.TransformFinalBlock( buff, 0, buff.Length );
					return System.Convert.ToBase64String( buff );
				}
			}
		}

		public static string Decrypt( string value )
		{
			using( TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider() )
			using( MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider() )
			{
				des.Key = hashmd5.ComputeHash( ASCIIEncoding.ASCII.GetBytes( cypPassword ) );
				des.Mode = CipherMode.ECB;
				using( ICryptoTransform desdencrypt = des.CreateDecryptor() )
				{
					try
					{
						byte[] buff = System.Convert.FromBase64String( value );
						buff = desdencrypt.TransformFinalBlock( buff, 0, buff.Length );
						return ASCIIEncoding.ASCII.GetString( buff );
					}
					catch( FormatException ) { }
					catch( CryptographicException ) { }
				}
			}

			return string.Empty;
		}
	}
}