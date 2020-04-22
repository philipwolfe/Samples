using System;
using DxVBLib;
using System.Collections;

namespace SpaceWar
{


	/// <summary>
	/// Summary description for SoundHandler.
	/// </summary>
	public class SoundHandler
	{
		DirectSound sound;
		ArrayList sounds = new ArrayList();

		Sounds lastSound;

		const int VolumeEngine = -1000;
		const int VolumeOtherShot = -2000;
		const int VolumeHaHa = -3000;

		public SoundHandler(DirectSound sound)
		{
			this.sound = sound;
			CreateSoundBuffers();
		}
	
		DirectSoundBuffer LoadFile(string filename)
		{
			DSBUFFERDESC bufferDesc = new DSBUFFERDESC();
			bufferDesc.lFlags = CONST_DSBCAPSFLAGS.DSBCAPS_CTRLVOLUME;
			WAVEFORMATEX waveFormat;

			DirectSoundBuffer buffer;
			buffer = 
				sound.CreateSoundBufferFromFile(
				filename, 
				ref bufferDesc,
				out waveFormat);		

			return buffer;
		}

		void AddBuffer(string filename, Sounds thisSound, bool looping, int volume)
		{
			SoundBuffer buffer;

			buffer = new SoundBuffer(
				sound,
				filename,
				thisSound,
				looping);
			sounds.Add(buffer);
			buffer.SetVolume(volume);
		}

		void AddBuffer(string filename, Sounds thisSound, bool looping)
		{
			AddBuffer(filename, thisSound, looping, 0);
		}

		void CreateSoundBuffers()
		{
			AddBuffer(@"hypercharge.wav", Sounds.ShipHyper, false);
			AddBuffer(@"sci fi bass.wav", Sounds.ShipAppear, false);
			AddBuffer(@"laser2.wav", Sounds.ShipFire, false);
			AddBuffer(@"explode.wav", Sounds.ShipExplode, false);

			AddBuffer(@"engine.wav", Sounds.ShipThrust,	true, VolumeEngine);
			AddBuffer(@"laser2_other.wav", Sounds.OtherShipFire, false, VolumeOtherShot);
			AddBuffer(@"explode_other.wav", Sounds.OtherShipExplode, false);
			AddBuffer(@"engine_other.wav", Sounds.OtherShipThrust, true, VolumeEngine);

			AddBuffer(@"sci fi bass.wav", Sounds.OtherShipAppear, false);
			AddBuffer(@"haha.wav", Sounds.Taunt, false, VolumeHaHa);
			
			AddBuffer(@"dude_quest1.wav", Sounds.Dude1, false);
			AddBuffer(@"dude_quest2.wav", Sounds.Dude2, false);
			AddBuffer(@"dude_quest3.wav", Sounds.Dude3, false);
			AddBuffer(@"dude_quest4.wav", Sounds.Dude4, false);
			AddBuffer(@"dude_quest5.wav", Sounds.Dude5, false);
		}

		public void Play(Sounds soundsToPlay)
		{
				// check each enum value. If that value
				// is set, play the sound...
			foreach (SoundBuffer buffer in sounds)
			{
				bool on = ((buffer.Sound & soundsToPlay) != 0);
				buffer.Play(on);
				if (on)
				{
					//Console.WriteLine("{0} on", buffer.Sound);
				}
			}
			lastSound = soundsToPlay;
		}
	}
}
