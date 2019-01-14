using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ZsTemplate
{
	static class NativeMethods
	{
		internal delegate IntPtr HookProc( int nCode, IntPtr wParam, IntPtr lParam );

		[DllImport( "user32.dll" )]
		internal static extern IntPtr CallNextHookEx( IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam );

		[DllImport( "user32.dll" )]
		internal static extern IntPtr SetWindowsHookEx( int idHook, HookProc lpfn, IntPtr hInstance, int threadId );

		[DllImport( "user32.dll" )]
		internal static extern void UnhookWindowsHookEx( IntPtr idHook );

		[DllImport( "user32.dll" )]
		internal static extern int GetWindowRect( IntPtr hWnd, ref Rectangle lpRect );

		[DllImport( "user32.dll" )]
		internal static extern void MoveWindow( IntPtr hWnd, int X, int Y, int nWidth, int nHeight, int bRepaint );



		[DllImport( "kernel32.dll" )]
		internal static extern IntPtr OpenProcess( UInt32 dwDesiredAccess, bool bInheritHandle, int dwProcessId );
		/*
		[DllImport( "kernel32.dll" )]
		internal static extern Int32 ReadProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, UIntPtr lpNumberOfBytesRead );
		*/
		[DllImport( "kernel32.dll", SetLastError = true )]
		internal static extern bool WriteProcessMemory( IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, UIntPtr lpNumberOfBytesWritten );

		[DllImport( "kernel32.dll" )]
		internal static extern Int32 CloseHandle( IntPtr hProcess );



		[DllImport( "PunkBusterGuid.dll" )]
		internal static extern string GetPunkBusterGuid( string key, int seed );
	}
}
