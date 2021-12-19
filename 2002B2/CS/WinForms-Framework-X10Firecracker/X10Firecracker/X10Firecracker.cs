using System;
using System.IO;
using System.Runtime.InteropServices;

namespace X10FirecrackerInterface
{
	/// <summary>
	/// Summary description for X10Firecracker.
	/// </summary>
	public class X10Firecracker
	{
		private const string HeaderCode = "1101010110101010"; //Header (never changes)
		private const string FooterCode = "10101101"; //Footer (never changes)
		private const string MakeBrighterCommandCode = "10001000"; //Brightens last device, if applicable
		private const string MakeDimmerCommandCode = "10011000"; //Dims last device, if applicable
		private const string FirstGroupCode = "0000"; //Applies to devices 1-8
		private const string SecondGroupCode = "0100"; //Applies to devices 9-16
    
		private const int DefaultCommPort = 1;
    
		private int mCommPort = DefaultCommPort;
		private FileStream mCommFileStream;

		public X10Firecracker()
		{
			if (!Initialize())
			{
				System.Windows.Forms.MessageBox.Show("Initialization of the default communications port, COM" + mCommPort.ToString() + ", was unsuccessful. Please choose another port.","COM" + mCommPort.ToString() + " Unavailable");
				}
			//
			// TODO: Add constructor logic here
			//
		}

		//Commands that may be sent to SendCommand().
		public enum Commands
		{
			TurnOn = 0,
			TurnOff = 1,
			MakeBrighter = 2,
			MakeDimmer = 3
		}

		//EscapeCommFunction() iFunc parameter values.
		private enum EscapeCommFunctions
		{
			SetRts = 3,
			ClrRts = 4,
			SetDtr = 5,
			ClrDtr = 6
		}

		//y value in mBinaryCommandCode(x,y) array.
		private enum BinaryCommandCodes
		{
			TurnOnIndex = 0,
			TurnOffIndex = 1
		}

		//House codes A-P in binary.
		private string[] mBinaryHouseCode = {"0110", "0111", "0100", "0101", "1000", "1001", "1010", "1011", "1110", "1111", "1100", "1101", "0000", "0001", "0010", "0011"};

		//Pattern: { { Dev Code 1, On } { Deve Code 1, Off }, { Dev Code 2, On } { Dev Code 2, Off }, ... }
		//Bit layout: "0ac0b000" where bits
		//a = 1-4/9-12 vs. 5-9/13-16
		//b = 1-2/5-6/9-10/13-14 vs. 3-4/7-8/11-12/15-16
		//c = on vs. off
		private string[,] mBinaryCommandCode = {{"00000000", "00100000"}, {"00010000", "00110000"}, {"00001000", "00101000"}, {"00011000", "00111000"}, {"01000000", "01100000"}, {"01010000", "01110000"}, {"01001000", "01101000"}, {"01011000", "01111000"}, {"00000000", "00100000"}, {"00010000", "00110000"}, {"00001000", "00101000"}, {"00011000", "00111000"}, {"01000000", "01100000"}, {"01010000", "01110000"}, {"01001000", "01101000"}, {"01011000", "01111000"}};

		//Set mCommFileStream to an exclusive read/write FileStream for the current mCommPort.
		private bool Initialize()
		{
			bool success = false;
			//First, try to close mCommFileStream in case it was already open.
			if (mCommFileStream != null)
			{
				try
				{
					mCommFileStream.Close();
				}
				catch
				{
					//
				}
				mCommFileStream = null;
			}
			//Next, open a new FileStream based on mCommPort.
			try
			{
				//The following tasks are performed in one statement:
				//1. Instantiate a "COMx" file where x = mCommPort.
				//2. Open the file for exclusive read/write access, which returns a Stream for the specified port.
				//3. Convert the returned Stream into a FileStream for later use with EscapeCommFunction().
				//4. Set a member variable to the FileStream.
				//Note: The File object is a one-time variable here because it is not needed after Initialize.
				//The Stream object that was generated from it lives on in a member variable.
				mCommFileStream = (System.IO.FileStream)((new System.IO.FileInfo("COM" + mCommPort.ToString())).Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None ));
				success = true;
			}
			catch
			{
				//
			}
			return success;
		}

		//Send to the mCommPort serial port a binary stream consisting of the house code,
		//device code, and any additional binary data that helps execute the desired command.
		public bool SendCommand(char houseCode,int deviceCode,Commands cmd)
		{
			int bit;
			string binaryCmd = "";

			switch (cmd)
			{
				case Commands.TurnOn:
					binaryCmd = HeaderCode + GetBinaryHouseCode(houseCode) + GetBinaryGroupCode(deviceCode) + GetBinaryCommandCode(deviceCode, BinaryCommandCodes.TurnOnIndex) + FooterCode;
					break;
				case Commands.TurnOff:
					binaryCmd = HeaderCode + GetBinaryHouseCode(houseCode) + GetBinaryGroupCode(deviceCode) + GetBinaryCommandCode(deviceCode, BinaryCommandCodes.TurnOffIndex) + FooterCode;
					break;
				case Commands.MakeBrighter:
					binaryCmd = HeaderCode + GetBinaryHouseCode(houseCode) + GetBinaryGroupCode(deviceCode) + MakeBrighterCommandCode + FooterCode;
					break;
				case Commands.MakeDimmer:
					binaryCmd = HeaderCode + GetBinaryHouseCode(houseCode) + GetBinaryGroupCode(deviceCode) + MakeDimmerCommandCode + FooterCode;
					break;
			}

			try
			{
				int hCommPort = mCommFileStream.Handle.ToInt32();

				//While transmitting data to the FireCracker, it is important to
				//ensure that at least one of the signals (RTS or DTR) is high
				//at all times to supply power to the device. Should both of the
				//signals drop to 0 at any time, the FireCracker will be reset and
				//will require the entire signal to be transmitted again.
				for (bit = 0; bit <= binaryCmd.Length - 1;bit++)
				{
					if (Convert.ToDouble(binaryCmd.Substring(bit, 1)) == 0)
					{
						EscapeCommFunction(hCommPort, Convert.ToInt32(EscapeCommFunctions.ClrRts));
						EscapeCommFunction(hCommPort, Convert.ToInt32(EscapeCommFunctions.SetDtr));
					}
					else
					{
						EscapeCommFunction(hCommPort, Convert.ToInt32(EscapeCommFunctions.SetRts));
						EscapeCommFunction(hCommPort, Convert.ToInt32(EscapeCommFunctions.ClrDtr));
					}
					EscapeCommFunction(hCommPort, Convert.ToInt32(EscapeCommFunctions.SetRts));
					EscapeCommFunction(hCommPort, Convert.ToInt32(EscapeCommFunctions.SetDtr));
				}
			}
			catch
			{
				return false;
			}			
			return true;			
		}

		//Determine the binary group code from the device code.
		private string GetBinaryGroupCode(int deviceCode)
		{
			//return Iif(deviceCode > 8, SecondGroupCode, FirstGroupCode).ToString;
			if (deviceCode > 8)
			{
				return Convert.ToString(SecondGroupCode);
			}
			else
			{
				return Convert.ToString(FirstGroupCode);
			}
		}

		//Convert a house code (A-P) to its binary representation.
		private string GetBinaryHouseCode(char houseCode)
		{		
			return mBinaryHouseCode[Convert.ToInt16(System.Char.GetNumericValue(Char.ToLower(houseCode)) - System.Char.GetNumericValue(Convert.ToChar("a")))];
			//	return mBinaryHouseCode(ASC(Char.ToLower(houseCode)) - ASC("a"));
		}

		//Convert a device code + command code index to its binary representation.
		private string GetBinaryCommandCode(int deviceCode, BinaryCommandCodes codeIndex)
		{
			return mBinaryCommandCode[deviceCode - 1, Convert.ToInt16(codeIndex)];
		}

		//Provide access to EscapeCommFunction() in the Win32 API through kernel32.dll.
		[DllImport("kernel32.dll")]
		public static extern bool EscapeCommFunction(int hFile,long ifunc);

		//Read/write property wraps mCommPort. Setting it causes mCommFileStream to re-initialize.
		public int CommPort
		{
			get
			{
				return mCommPort;
			}
			set
			{
				mCommPort = value;
				if (!Initialize())
				{
					System.Windows.Forms.MessageBox.Show("Initialization of COM" + mCommPort.ToString() + " was unsuccessful. Please choose another port.", "COM" + mCommPort.ToString() + " Unavailable" );
				}
			}
		}	
	}
}
