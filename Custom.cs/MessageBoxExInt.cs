using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZsTemplate;

namespace MessageBoxEx
{
	public static class MessageBoxExInt
	{
		public static DialogResult Show( Exception ex )
		{
			if( ex == null )
				throw new ArgumentException( null );

			string err = ex.Message;
			while( ex.InnerException != null )
			{
				ex = ex.InnerException;
				err += Environment.NewLine;
				err += ex.Message;
			}

			Initialize( null );
			return MessageBox.Show( err, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, 0, 0 );
		}

		public static DialogResult Show( IWin32Window owner, Exception ex )
		{
			if( ex == null )
				throw new ArgumentException( "" );

			string err = ex.Message;

			while( ex.InnerException != null )
			{
				ex = ex.InnerException;
				err += Environment.NewLine;
				err += ex.Message;
			}


			Initialize( owner );
			return MessageBox.Show( err, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, 0, 0 );
		}


		#region Show

		//
		public static DialogResult Show( string text )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, 0, 0, 0, 0 );
		}

		public static DialogResult Show( IWin32Window owner, string text )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, 0, 0, 0, 0 );
		}

		//
		public static DialogResult Show( string text, string caption )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, 0, 0, 0, 0 );
		}

		public static DialogResult Show( IWin32Window owner, string text, string caption )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, 0, 0, 0, 0 );
		}

		//
		public static DialogResult Show( string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, 0, 0, 0 );
		}

		public static DialogResult Show( IWin32Window owner, string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, 0, 0, 0 );
		}

		//
		public static DialogResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, icon, 0, 0 );
		}

		public static DialogResult Show( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, icon, 0, 0 );
		}

		//
		public static DialogResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, icon, defaultButton, 0 );
		}

		public static DialogResult Show( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, icon, defaultButton, 0 );
		}

		//
		public static DialogResult Show( string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, icon, defaultButton, options );
		}

		public static DialogResult Show( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, icon, defaultButton, options );
		}

		#endregion

		#region ShowApp

		/////////// ShowApp caption is Application.ProductName							   
		//							   
		public static DialogResult ShowApp( string text )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, 0, 0, 0, 0 );
		}

		public static DialogResult ShowApp( IWin32Window owner, string text )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, 0, 0, 0, 0 );
		}

		//							   
		public static DialogResult ShowApp( string text, MessageBoxButtons buttons )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, buttons, 0, 0, 0 );
		}

		public static DialogResult ShowApp( IWin32Window owner, string text, MessageBoxButtons buttons )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, buttons, 0, 0, 0 );
		}

		//							   
		public static DialogResult ShowApp( string text, MessageBoxButtons buttons, MessageBoxIcon icon )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, buttons, icon, 0, 0 );
		}

		public static DialogResult ShowApp( IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, buttons, icon, 0, 0 );
		}

		//							   
		public static DialogResult ShowApp( string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, buttons, icon, defaultButton, 0 );
		}

		public static DialogResult ShowApp( IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, buttons, icon, defaultButton, 0 );
		}

		//							   
		public static DialogResult ShowApp( string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, buttons, icon, defaultButton, options );
		}

		public static DialogResult ShowApp( IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, buttons, icon, defaultButton, options );
		}

		#endregion

		#region ShowEmpty

		/////////// ShowEmpty caption is string.Empty	
		//							   
		public static DialogResult ShowEmpty( string text )
		{
			Initialize( null );
			return MessageBox.Show( text, string.Empty, 0, 0, 0, 0 );
		}

		public static DialogResult ShowEmpty( IWin32Window owner, string text )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, string.Empty, 0, 0, 0, 0 );
		}

		//							   
		public static DialogResult ShowEmpty( string text, MessageBoxButtons buttons )
		{
			Initialize( null );
			return MessageBox.Show( text, string.Empty, buttons, 0, 0, 0 );
		}

		public static DialogResult ShowEmpty( IWin32Window owner, string text, MessageBoxButtons buttons )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, string.Empty, buttons, 0, 0, 0 );
		}

		//							   
		public static DialogResult ShowEmpty( string text, MessageBoxButtons buttons, MessageBoxIcon icon )
		{
			Initialize( null );
			return MessageBox.Show( text, string.Empty, buttons, icon, 0, 0 );
		}

		public static DialogResult ShowEmpty( IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, string.Empty, buttons, icon, 0, 0 );
		}

		//							   
		public static DialogResult ShowEmpty( string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton )
		{
			Initialize( null );
			return MessageBox.Show( text, string.Empty, buttons, icon, defaultButton, 0 );
		}

		public static DialogResult ShowEmpty( IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, string.Empty, buttons, icon, defaultButton, 0 );
		}

		//							   
		public static DialogResult ShowEmpty( string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( null );
			return MessageBox.Show( text, string.Empty, buttons, icon, defaultButton, options );
		}

		public static DialogResult ShowEmpty( IWin32Window owner, string text, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, string.Empty, buttons, icon, defaultButton, options );
		}

		#endregion

		#region ShowError

		/////////// ShowError MessageBoxIcon.Error
		//	
		public static DialogResult ShowError( string text )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, 0, 0 );
		}

		public static DialogResult ShowError( IWin32Window owner, string text )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error, 0, 0 );
		}

		//							   
		public static DialogResult ShowError( string text, string caption )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error, 0, 0 );
		}

		public static DialogResult ShowError( IWin32Window owner, string text, string caption )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error, 0, 0 );
		}

		//							   
		public static DialogResult ShowError( string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Error, 0, 0 );
		}

		public static DialogResult ShowError( IWin32Window owner, string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Error, 0, 0 );
		}

		//							   
		public static DialogResult ShowError( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Error, defaultButton, 0 );
		}

		public static DialogResult ShowError( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Error, defaultButton, 0 );
		}

		//							   
		public static DialogResult ShowError( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Error, defaultButton, options );
		}

		public static DialogResult ShowError( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Error, defaultButton, options );
		}

		#endregion

		#region ShowExclamation

		/////////// ShowExclamation MessageBoxIcon.Exclamation
		//	
		public static DialogResult ShowExclamation( string text )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 0, 0 );
		}

		public static DialogResult ShowExclamation( IWin32Window owner, string text )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 0, 0 );
		}

		//							   
		public static DialogResult ShowExclamation( string text, string caption )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 0, 0 );
		}

		public static DialogResult ShowExclamation( IWin32Window owner, string text, string caption )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, 0, 0 );
		}

		//							   
		public static DialogResult ShowExclamation( string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Exclamation, 0, 0 );
		}

		public static DialogResult ShowExclamation( IWin32Window owner, string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Exclamation, 0, 0 );
		}

		//							   
		public static DialogResult ShowExclamation( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Exclamation, defaultButton, 0 );
		}

		public static DialogResult ShowExclamation( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Exclamation, defaultButton, 0 );
		}

		//							   
		public static DialogResult ShowExclamation( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Exclamation, defaultButton, options );
		}

		public static DialogResult ShowExclamation( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Exclamation, defaultButton, options );
		}

		#endregion

		#region ShowInformation

		/////////// ShowInformation MessageBoxIcon.Information
		//	
		public static DialogResult ShowInformation( string text )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, 0, 0 );
		}

		public static DialogResult ShowInformation( IWin32Window owner, string text )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information, 0, 0 );
		}

		//							   
		public static DialogResult ShowInformation( string text, string caption )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information, 0, 0 );
		}

		public static DialogResult ShowInformation( IWin32Window owner, string text, string caption )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information, 0, 0 );
		}

		//							   
		public static DialogResult ShowInformation( string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Information, 0, 0 );
		}

		public static DialogResult ShowInformation( IWin32Window owner, string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Information, 0, 0 );
		}

		//							   
		public static DialogResult ShowInformation( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Information, defaultButton, 0 );
		}

		public static DialogResult ShowInformation( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Information, defaultButton, 0 );
		}

		//							   
		public static DialogResult ShowInformation( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Information, defaultButton, options );
		}

		public static DialogResult ShowInformation( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Information, defaultButton, options );
		}

		#endregion

		#region ShowQuestion

		/////////// ShowQuestion MessageBoxIcon.Question
		//	
		public static DialogResult ShowQuestion( string text )
		{
			Initialize( null );
			return MessageBox.Show( text, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 0, 0 );
		}

		public static DialogResult ShowQuestion( IWin32Window owner, string text )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 0, 0 );
		}

		//							   
		public static DialogResult ShowQuestion( string text, string caption )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 0, 0 );
		}

		public static DialogResult ShowQuestion( IWin32Window owner, string text, string caption )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, 0, 0 );
		}

		//							   
		public static DialogResult ShowQuestion( string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Question, 0, 0 );
		}

		public static DialogResult ShowQuestion( IWin32Window owner, string text, string caption, MessageBoxButtons buttons )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Question, 0, 0 );
		}

		//							   
		public static DialogResult ShowQuestion( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Question, defaultButton, 0 );
		}

		public static DialogResult ShowQuestion( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Question, defaultButton, 0 );
		}

		//							   
		public static DialogResult ShowQuestion( string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( null );
			return MessageBox.Show( text, caption, buttons, MessageBoxIcon.Question, defaultButton, options );
		}

		public static DialogResult ShowQuestion( IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxDefaultButton defaultButton, MessageBoxOptions options )
		{
			Initialize( owner );
			return MessageBox.Show( owner, text, caption, buttons, MessageBoxIcon.Question, defaultButton, options );
		}

		#endregion



		[StructLayout( LayoutKind.Sequential )]
		private struct CWPRETSTRUCT
		{
			public IntPtr lResult;
			public IntPtr lParam;
			public IntPtr wParam;
			public uint message;
			public IntPtr hwnd;
		};


		private static IWin32Window _owner = null;
		private static NativeMethods.HookProc _hookProc = null;
		private static IntPtr _hHook = IntPtr.Zero;

		private static void Initialize( IWin32Window owner )
		{
			if( owner == null )
				return;

			if( _hHook != IntPtr.Zero )
				return;

			_owner = owner;
			_hookProc = MessageBoxHookProc;

#pragma warning disable 0618
			_hHook = NativeMethods.SetWindowsHookEx( 12, _hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId() );
#pragma warning restore 0618
		}

		private static IntPtr MessageBoxHookProc( int nCode, IntPtr wParam, IntPtr lParam )
		{
			if( nCode < 0 )
			{
				return NativeMethods.CallNextHookEx( _hHook, nCode, wParam, lParam );
			}

			CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure( lParam, typeof( CWPRETSTRUCT ) );
			IntPtr hook = _hHook;

			if( msg.message == 5 )
			{
				try
				{
					CenterWindow( msg.hwnd );
				}
				finally
				{
					NativeMethods.UnhookWindowsHookEx( _hHook );
					_hHook = IntPtr.Zero;
				}
			}

			return NativeMethods.CallNextHookEx( hook, nCode, wParam, lParam );
		}

		private static void CenterWindow( IntPtr hChildWnd )
		{
			Rectangle recChild = new Rectangle( 0, 0, 0, 0 );
			if( NativeMethods.GetWindowRect( hChildWnd, ref recChild ) == 0 )
				return;


			int width = recChild.Width - recChild.X;
			int height = recChild.Height - recChild.Y;

			Rectangle recParent = new Rectangle( 0, 0, 0, 0 );
			if( NativeMethods.GetWindowRect( _owner.Handle, ref recParent ) == 0 )
				return;

			System.Drawing.Point ptCenter = new System.Drawing.Point( 0, 0 );
			ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
			ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);


			System.Drawing.Point ptStart = new System.Drawing.Point( 0, 0 );
			ptStart.X = (ptCenter.X - (width / 2));
			ptStart.Y = (ptCenter.Y - (height / 2));

			ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
			ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;

			NativeMethods.MoveWindow( hChildWnd, ptStart.X, ptStart.Y, width, height, 0 );
		}
	}
}
