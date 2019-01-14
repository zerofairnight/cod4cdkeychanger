using System.Windows.Forms;
using System.Drawing;
using MessageBoxEx;

using HandlerString = ZsTemplate.Languages.Error.String;

namespace System
{
	public enum ErrorState
	{
		None,
		Generic,

		CDKey,		// Cdkey is invalid
		CDGuid,		// CdGuid is invalid, gestisci come dll corrotta!!!

		Registry,		// RegKey in invalid, keyValue does not contain 'codkey'
		RegistryEmpty,	// RegKey is emptry
		RegistryRoot,	// keyName does not begin with a valid registry root. 
		RegistryPeak,	// keyName does not terminate with 'Activision\\Call of Duty 4'

		RegistrySecuritySet,	// The user does not have the permissions required to create or modify registry keys.
		RegistrySecurityGet,	// The user does not have the permissions required to read from the registry key.
		RegistryUnauthorizedAccess,	//The RegistryKey is read-only, and thus cannot be written to; for example, it is a root-level node. 
		RegistryIO,				// The RegistryKey that contains the specified value has been marked for deletion.

		GameHandle,	// Game is close

		Injection,			// Unmanaged inject error

		DllNotFound
	}


	public struct ErrorContainer
	{
		public Color Color { get; set; }
		public ErrorState State { get; set; }
		public string Message { get; set; }
		public string Tip { get; set; }


		public static bool operator ==( ErrorContainer left, ErrorContainer right )
		{
			return left.Equals( right );
		}

		public static bool operator !=( ErrorContainer left, ErrorContainer right )
		{
			return !left.Equals( right );
		}

		public override bool Equals( object obj )
		{
			if( !(obj is ErrorContainer) )
				return false;

			return State == ((ErrorContainer)obj).State;
		}

		public override int GetHashCode()
		{
			if( this == null )
				return 0;

			return (this as object).GetHashCode();
		}
	}



	public struct ErrorColor
	{
		public static Color None { get { return Color.Transparent; } }
		public static Color Generic { get { return Color.Red; } }

		public static Color CDKey { get { return Color.Red; } }
		public static Color CDGuid { get { return Color.Red; } }

		public static Color Registry { get { return Color.Red; } }
		public static Color RegistryEmpty { get { return Color.Red; } }
		public static Color RegistryRoot { get { return Color.Red; } }
		public static Color RegistryPeak { get { return Color.Red; } }

		public static Color RegistrySecuritySet { get { return Color.Red; } }
		public static Color RegistrySecurityGet { get { return Color.Red; } }
		public static Color RegistryUnauthorizedAccess { get { return Color.Red; } }
		public static Color RegistryIO { get { return Color.Red; } }

		public static Color GameHandle { get { return Color.Red; } }

		public static Color Injection { get { return Color.Red; } }
		public static Color DllNotFound { get { return Color.Red; } }



		public static bool operator ==( ErrorColor left, ErrorColor right )
		{
			return left.Equals( right );
		}

		public static bool operator !=( ErrorColor left, ErrorColor right )
		{
			return !left.Equals( right );
		}

		public override bool Equals( object obj )
		{
			if( !(obj is ErrorColor) )
				return false;

			return (Color)(this as object) == (Color)obj;
		}

		public override int GetHashCode()
		{
			if( this == null )
				return 0;

			return (this as object).GetHashCode();
		}

	}

	public struct ErrorMessage
	{
		public static string None { get { return string.Empty; } }
		public static string Generic { get { return HandlerString.Generic; } }

		public static string CDKey { get { return  HandlerString.CDKey; } }
		public static string CDGuid { get { return  HandlerString.CDGuid; } }

		public static string Registry { get { return HandlerString.Registry; } }
		public static string RegistryEmpty { get { return HandlerString.RegistryEmpty; } }
		public static string RegistryRoot { get { return HandlerString.RegistryRoot; } }
		public static string RegistryPeak { get { return HandlerString.RegistryPeak; } }

		public static string RegistrySecuritySet { get { return HandlerString.RegistrySecuritySet; } }
		public static string RegistrySecurityGet { get { return HandlerString.RegistrySecurityGet; } }
		public static string RegistryUnauthorizedAccess { get { return HandlerString.RegistryUnauthorizedAccess; } }
		public static string RegistryIO { get { return HandlerString.RegistryIO; } }

		public static string GameHandle { get { return HandlerString.GameHandle; } }

		public static string Injection { get { return HandlerString.Injection; } }
		public static string DllNotFound { get { return HandlerString.DllNotFound; } }




		public static bool operator ==( ErrorMessage left, ErrorMessage right )
		{
			return left.Equals( right );
		}

		public static bool operator !=( ErrorMessage left, ErrorMessage right )
		{
			return !left.Equals( right );
		}

		public override bool Equals( object obj )
		{
			if( !(obj is ErrorMessage) )
				return false;

			return (string)(this as object) == (string)obj;
		}

		public override int GetHashCode()
		{
			if( this == null )
				return 0;

			return (this as object).GetHashCode();
		}
	}

	public struct ErrorTip
	{
		public static string None { get { return string.Empty; } }
		public static string Generic { get { return HandlerString.GenericTip; } }

		public static string CDKey { get { return HandlerString.CDKeyTip; } }
		public static string CDGuid { get { return HandlerString.CDGuidTip; } }

		public static string Registry { get { return HandlerString.RegistryTip; } }
		public static string RegistryEmpty { get { return HandlerString.RegistryEmptyTip; } }
		public static string RegistryRoot { get { return HandlerString.RegistryRootTip; } }
		public static string RegistryPeak { get { return HandlerString.RegistryPeakTip; } }

		public static string RegistrySecuritySet { get { return HandlerString.RegistrySecuritySetTip; } }
		public static string RegistrySecurityGet { get { return HandlerString.RegistrySecurityGetTip; } }
		public static string RegistryUnauthorizedAccess { get { return HandlerString.RegistryUnauthorizedAccessTip; } }
		public static string RegistryIO { get { return HandlerString.RegistryIOTip; } }

		public static string GameHandle { get { return HandlerString.GameHandleTip; } }

		public static string Injection { get { return HandlerString.InjectionTip; } }
		public static string DllNotFound { get { return HandlerString.DllNotFoundTip; } }

		public static bool operator ==( ErrorTip left, ErrorTip right )
		{
			return left.Equals( right );
		}

		public static bool operator !=( ErrorTip left, ErrorTip right )
		{
			return !left.Equals( right );
		}

		public override bool Equals( object obj )
		{
			if( !(obj is ErrorTip) )
				return false;

			return (string)(this as object) == (string)obj;
		}

		public override int GetHashCode()
		{
			if( this == null )
				return 0;

			return (this as object).GetHashCode();
		}
	}



	public static class ErrorHandler
	{
		public static ErrorContainer HandleContainer( IWin32Window owner, ErrorState error )
		{
			ErrorContainer c = new ErrorContainer();

			c.State = ErrorState.None;
			c.Color = ErrorColor.None;
			c.Message = null;
			c.Tip = null;

			switch( error )
			{
				case ErrorState.None:
					{
						break;
					}
				case ErrorState.Generic:
					{
						c.State =	 ErrorState.Generic;
						c.Color =	 ErrorColor.Generic;
						c.Message =	 ErrorMessage.Generic;
						c.Tip =		 ErrorTip.Generic;

						MessageBoxExInt.ShowError( owner, ErrorMessage.Generic );
						break;
					}
				case ErrorState.CDKey:
					{
						c.State = ErrorState.CDKey;
						c.Color = ErrorColor.CDKey;
						c.Message = ErrorMessage.CDKey;
						c.Tip = ErrorTip.CDKey;

						MessageBoxExInt.ShowError( owner, ErrorMessage.CDKey );
						break;
					}
				case ErrorState.CDGuid:
					{
						c.State = ErrorState.CDGuid;
						c.Color = ErrorColor.CDGuid;
						c.Message = ErrorMessage.CDGuid;
						c.Tip = ErrorTip.CDGuid;

						MessageBoxExInt.ShowError( owner, ErrorMessage.CDGuid );
						break;
					}
				case ErrorState.Registry:
					{
						c.State = ErrorState.Registry;
						c.Color = ErrorColor.Registry;
						c.Message = ErrorMessage.Registry;
						c.Tip = ErrorTip.Registry;

						MessageBoxExInt.ShowError( owner, ErrorMessage.Registry );
						break;
					}
				case ErrorState.RegistryEmpty:
					{
						c.State = ErrorState.RegistryEmpty;
						c.Color = ErrorColor.RegistryEmpty;
						c.Message = ErrorMessage.RegistryEmpty;
						c.Tip = ErrorTip.RegistryEmpty;

						MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryEmpty );
						break;
					}
				case ErrorState.RegistryRoot:
					{
						c.State = ErrorState.RegistryRoot;
						c.Color = ErrorColor.RegistryRoot;
						c.Message = ErrorMessage.RegistryRoot;
						c.Tip = ErrorTip.RegistryRoot;

						MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryRoot );
						break;
					}
				case ErrorState.RegistryPeak:
					{
						c.State = ErrorState.RegistryPeak;
						c.Color = ErrorColor.RegistryPeak;
						c.Message = ErrorMessage.RegistryPeak;
						c.Tip = ErrorTip.RegistryPeak;

						MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryPeak );
						break;
					}
				case ErrorState.RegistrySecuritySet:
					{
						c.State = ErrorState.RegistrySecuritySet;
						c.Color = ErrorColor.RegistrySecuritySet;
						c.Message = ErrorMessage.RegistrySecuritySet;
						c.Tip = ErrorTip.RegistrySecuritySet;

						MessageBoxExInt.ShowError( owner, ErrorMessage.RegistrySecuritySet );
						break;
					}
				case ErrorState.RegistrySecurityGet:
					{
						c.State = ErrorState.RegistrySecurityGet;
						c.Color = ErrorColor.RegistrySecurityGet;
						c.Message = ErrorMessage.RegistrySecurityGet;
						c.Tip = ErrorTip.RegistrySecurityGet;

						MessageBoxExInt.ShowError( owner, ErrorMessage.RegistrySecurityGet );
						break;
					}
				case ErrorState.RegistryUnauthorizedAccess:
					{
						c.State = ErrorState.RegistryUnauthorizedAccess;
						c.Color = ErrorColor.RegistryUnauthorizedAccess;
						c.Message = ErrorMessage.RegistryUnauthorizedAccess;
						c.Tip = ErrorTip.RegistryUnauthorizedAccess;

						MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryUnauthorizedAccess );
						break;
					}
				case ErrorState.RegistryIO:
					{
						c.State = ErrorState.RegistryIO;
						c.Color = ErrorColor.RegistryIO;
						c.Message = ErrorMessage.RegistryIO;
						c.Tip = ErrorTip.RegistryIO;

						MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryIO );
						break;
					}
				case ErrorState.GameHandle:
					{
						c.State = ErrorState.GameHandle;
						c.Color = ErrorColor.GameHandle;
						c.Message = ErrorMessage.GameHandle;
						c.Tip = ErrorTip.GameHandle;

						MessageBoxExInt.ShowError( owner, ErrorMessage.GameHandle );
						break;
					}
				case ErrorState.Injection:
					{
						c.State = ErrorState.Injection;
						c.Color = ErrorColor.Injection;
						c.Message = ErrorMessage.Injection;
						c.Tip = ErrorTip.Injection;

						MessageBoxExInt.ShowError( owner, ErrorMessage.Injection );
						break;
					}
				case ErrorState.DllNotFound:
					{
						c.State = ErrorState.DllNotFound;
						c.Color = ErrorColor.DllNotFound;
						c.Message = ErrorMessage.DllNotFound;
						c.Tip = ErrorTip.DllNotFound;

						MessageBoxExInt.ShowError( owner, ErrorMessage.DllNotFound );
						break;
					}
			}

			return c;
		}

		public static bool Handle( IWin32Window owner, ErrorState error )
		{
			switch( error )
			{
				case ErrorState.None:
					break;
				case ErrorState.Generic:
					MessageBoxExInt.ShowError( owner, ErrorMessage.Generic );
					break;
				case ErrorState.CDKey:
					MessageBoxExInt.ShowError( owner, ErrorMessage.CDKey );
					break;
				case ErrorState.CDGuid:
					MessageBoxExInt.ShowError( owner, ErrorMessage.CDGuid );
					break;
				case ErrorState.Registry:
					MessageBoxExInt.ShowError( owner, ErrorMessage.Registry );
					break;
				case ErrorState.RegistryEmpty:
					MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryEmpty );
					break;
				case ErrorState.RegistryRoot:
					MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryRoot );
					break;
				case ErrorState.RegistryPeak:
					MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryPeak );
					break;
				case ErrorState.RegistrySecuritySet:
					MessageBoxExInt.ShowError( owner, ErrorMessage.RegistrySecuritySet );
					break;
				case ErrorState.RegistrySecurityGet:
					MessageBoxExInt.ShowError( owner, ErrorMessage.RegistrySecurityGet );
					break;
				case ErrorState.RegistryUnauthorizedAccess:
					MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryUnauthorizedAccess );
					break;
				case ErrorState.RegistryIO:
					MessageBoxExInt.ShowError( owner, ErrorMessage.RegistryIO );
					break;
				case ErrorState.GameHandle:
					MessageBoxExInt.ShowError( owner, ErrorMessage.GameHandle );
					break;
				case ErrorState.Injection:
					MessageBoxExInt.ShowError( owner, ErrorMessage.Injection );
					break;
				case ErrorState.DllNotFound:
					MessageBoxExInt.ShowError( owner, ErrorMessage.DllNotFound );
					break;
			}

			return error != ErrorState.None;
		}
	}
}
