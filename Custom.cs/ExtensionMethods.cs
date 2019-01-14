using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.ComponentModel;

namespace ExtensionMethods
{
	public static class ExtensionMethodsStrings
	{
		public static string Collapse( string format, params object[] args )
		{
			return String.Format( System.Globalization.CultureInfo.InvariantCulture, format, args );
		}
	}
}
