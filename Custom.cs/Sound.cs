using System;
using System.Collections.Generic;
using System.Linq;

using GlobalSettings = global::ZsTemplate.Properties.Settings;

namespace ZsTemplate
{
	// TODO: move in main class
	internal static class Sound
	{
		public static void Asterisk()
		{
			if( GlobalSettings.Default.UseSound )
				System.Media.SystemSounds.Asterisk.Play();
		}
		public static void Beep()
		{
			if( GlobalSettings.Default.UseSound )
				System.Media.SystemSounds.Beep.Play();
		}
		public static void Exclamation()
		{
			if( GlobalSettings.Default.UseSound )
				System.Media.SystemSounds.Exclamation.Play();
		}
		public static void Hand()
		{
			if( GlobalSettings.Default.UseSound )
				System.Media.SystemSounds.Hand.Play();
		}
		public static void Question()
		{
			if( GlobalSettings.Default.UseSound )
				System.Media.SystemSounds.Question.Play();
		}
	}
}
