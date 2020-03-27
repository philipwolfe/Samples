using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace PlayingSounds
{
	public partial class Form1 : Form
	{
		// A SoundPlayer control is used for playing system sounds
		// and .wav files.
		private SoundPlayer player;

		public Form1()
		{
			InitializeComponent();

			player = new SoundPlayer();
			// Timout loading a sound file after 10 seconds
			// Timing out will throw a TimeoutException
			// If the load is asynchronous, the TimeoutException is captured in
			// AsyncCompletedEventArgs.Error.
			player.LoadTimeout = 10000;

			// Register a function to handle notification that loading the sound file is complete.
			// Large sound files may take some time to load, so asyncrhonous loading support 
			// is provided through the LoadAsync() method.  The SoundPlayer raises the LoadCompleted
			// event when the asynchronous load is complete.			
			player.LoadCompleted += new AsyncCompletedEventHandler(soundFileLoaded);
			
			// Display available system sounds on the form.
			LoadSystemSounds();
		}

		public void LoadSystemSounds()
		{
			// These are the system sounds currently supported.
			// There is no list avaliable for enumerating,
			// so load them manually
			systemSoundsComboBox.Items.AddRange(
				new string[] { "Asterisk", "Beep", "Exclamation", "Hand" });
		}

		private void browseButton_Click(object sender, EventArgs e)
		{
			// Provide a file dialog for browsing for the sound file.
			string fileName;
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = "c:\\windows\\media";
			openFileDialog1.Filter = "WAV files (*.wav)|*.wav";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				// In this sample, the SoundPlayer.SoundLocation is used.
				// Alternatively, the SoundPlayer.Stream could be used with
				// openFileDialog1.OpenFile()
				if ((fileName = openFileDialog1.FileName) != null)
				{
					soundFileNameTextBox.Text = fileName;
					player.SoundLocation = fileName;
					// Once the file has been selected, start loading it
					// asyncrhonously, in case it is large.
					// If the file is not preloaded, the Play(Async) methods
					// load it before playing it.
					player.LoadAsync();		
				}
			}
		}
	
		private void playSyncButton_Click(object sender, EventArgs e)
		{
			// Play the sound synchronously.
			// Do not loop on the sound unless playing asynchronously.
			player.PlaySync();
		}

		private void playAsyncButton_Click(object sender, EventArgs e)
		{
			if (loopCheckBox.Checked)
			{
				// Looping has been requested.
				// Play the sound repeatedly, until stopped using the 
				// SoundPlayer.Stop method.
				player.PlayLooping();
			}
			else
			{
				// Play the sound asynchronously once and stop.
				// The sound may be stopped before it is finished playing
				// by calling the SoundPlayer.Stop method.
				player.Play();
			}		
		}

		private void soundFileLoaded(object sender, AsyncCompletedEventArgs e)
		{
			// Check the event args for any errors.
			if (e.Error == null)
				statusStrip1.Text = String.Empty;
			else if (e.Error.GetType() == typeof(TimeoutException))
			{
				statusStrip1.Text = "Load timed out.";
				MessageBox.Show(this, "Loading timed out. Load a smaller file or increase the LoadTimeout value.", this.Text);
			}
			else
				statusStrip1.Text = "ERROR: " + e.Error.Message;
		}

		private void stopAsyncPlayButton_Click(object sender, EventArgs e)
		{
			// Stop the sound from playing.
			// Stopping is supported only if the sound is played
			// using the asynchronous SoundPlayer.Play() method.
			player.Stop();
		}

		private void playSystemSoundButton_Click(object sender, EventArgs e)
		{
			// System Sounds are supported directly in the .NET Framework 2.0,
			// and hang off the SystemSounds class.  Each is a SystemSound,
			// which implements a synchronous Play method.  
			switch (systemSoundsComboBox.Text)
			{
				case "Asterisk":
					SystemSounds.Asterisk.Play();
					break;
				case "Beep":
					SystemSounds.Beep.Play();
					break;
				case "Exclamation":
					SystemSounds.Exclamation.Play();
					break;
				case "Hand":
					SystemSounds.Hand.Play();
					break;
				default:
					throw new ApplicationException("Invalid system sound.");
			}
		}
	}
}