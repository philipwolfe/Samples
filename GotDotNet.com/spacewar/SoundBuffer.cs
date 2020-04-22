using System;
using DxVBLib;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for SoundBuffer.
	/// </summary>
	public class SoundBuffer
	{
		DirectSoundBuffer buffer;
		Sounds thisSound;
		bool looping;
		bool lastValue;

		public SoundBuffer(DirectSound sound, string filename, Sounds thisSound, bool looping)
		{
			this.thisSound = thisSound;
			this.looping = looping;

			DSBUFFERDESC bufferDesc = new DSBUFFERDESC();
			bufferDesc.lFlags = CONST_DSBCAPSFLAGS.DSBCAPS_CTRLVOLUME;
			WAVEFORMATEX waveFormat;

			try
			{
				buffer = 
					sound.CreateSoundBufferFromFile(
					filename, 
					ref bufferDesc,
					out waveFormat);		
			}
			catch (Exception e)
			{
				throw new Exception(
					String.Format("Error opening {0}; please run SpaceWar from sound file directory",
									filename), e);
			}
		}

		public Sounds Sound
		{
			get
			{
				return thisSound;
			}
		}

		public void SetVolume(int volume)
		{
			buffer.SetVolume(volume);
		}

		public void Play(bool on)
		{
				// looping sounds don't get restarted
			if (looping)
			{
				if (on)
				{
					if (!lastValue)
					{
						buffer.SetCurrentPosition(1000);
						CONST_DSBPLAYFLAGS playFlags = CONST_DSBPLAYFLAGS.DSBPLAY_LOOPING;
						buffer.Play(playFlags);
					}
				}
				else
				{
					buffer.Stop();
				}
				lastValue = on;
			}
			else
			{
				if (on)
				{
					buffer.SetCurrentPosition(0);
					CONST_DSBPLAYFLAGS playFlags = CONST_DSBPLAYFLAGS.DSBPLAY_DEFAULT;
					buffer.Play(playFlags);
				}
			}
		}
	}
}
