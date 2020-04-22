using System;
using System.Runtime.InteropServices;

namespace CodeRunner
{
	public class Sound
	{
		[DllImport("Winmm.dll")]
		private static extern bool sndPlaySound(string strSound ,int fuSound);

		public Sound()
		{
		}

		private static void PlaySound(string strSound)
		{
			strSound = Constants.APP_DIR + @"Resources\" + strSound;
			sndPlaySound(strSound ,1);
		}

		public static void PlayGetGold()
		{
			PlaySound("pop.wav");
		}

		public static void PlayVictory()
		{
			PlaySound("victory.wav");
		}

		public static void PlayDig()
		{
			PlaySound("dig.wav");
		}

		public static void PlayDeath()
		{
			PlaySound("death.wav");
		}

		public static void PlayEscape()
		{
			PlaySound("escape.wav");
		}

		public static void PlayStart()
		{
			//PlaySound("start.wav");
		}
	}
}
