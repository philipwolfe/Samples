using System;
using System.IO;
using System.Globalization;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;

namespace Microsoft.Samples.SpaceInvaders
{
	public enum LcdKey
	{
		None,
		Up,
		Down,
		Left,
		Right,
		Enter,
		Exit
	}

	[CLSCompliant(false)]
	public class SerialLcd
	{
		private const int READ_BUFFER_SIZE = 128;
		private const int MAX_DATA_LENGTH = 16;
		private const int MAX_RESPONSE_TIME = 250;
		private const int LINE_LENGTH = 16;
		private const int MAX_PACKET_LENGTH = MAX_DATA_LENGTH + 4;
		private const byte NORMAL_RESPONSE = 0x40;
		private const byte NORMAL_REPORT = 0x80;
		private const byte ERROR_RESPONSE = 0xC0;
		private const byte KEY_ACTIVITY_REPORT = 0x80;
		private const byte FAN_SPEED_REPORT = 0x81;
		private const byte TEMPATURE_SENSOR_REPORT = 0x82;
		ushort CYCLIC_REDUNDANCY_CHECK_SEED = 0xFFFF;
		private SerialPort com;
		private byte[] packetRcvBuffer;
		private byte[] packetXMitBuffer;
		private Thread receiveThread;
		private Thread eventThread;
		private LcdPacket responsePacket;
		private Queue<LcdPacket> reportQueue;
		private Object responseSignal;
		private Object reportSignal;
		private LcdKey _key;
		[FlagsAttribute]
		public enum Fans { Fan1 = 1, Fan2 = 2, Fan3 = 4, Fan4 = 8 };
		private byte fan1Power, fan2Power, fan3Power, fan4Power;
		public delegate EventHandler<EventArgs> KeyActivityEventHandler(object sender, EventArgs e);
		//public delegate void KeyActivityEventHandler(Object sender, EventArgs e);

		public SerialLcd()
		{
			// comport
			com = new SerialPort("COM3", 19200);
			
			packetRcvBuffer = new byte[MAX_PACKET_LENGTH];
			packetXMitBuffer = new byte[MAX_PACKET_LENGTH];
			fan1Power = fan2Power = fan3Power = fan4Power = (byte)0;
			reportQueue = new Queue<LcdPacket>();
			responseSignal = new Object();
			reportSignal = new Object();
		}
		public List<byte> Ping(List<byte> data)
		{
			byte type = 0;

			if (16 < data.Count)
			{
				throw new ArgumentException("data", "must have 16 items or less");
			}

			return SendReturnData(type, (byte)data.Count, data);
		}

		public List<byte> GetHardwareFirmwareVersion
		{
			get
			{
				byte type = 1;
				return SendReturnData(type, 0, (List<byte>)null);
			}
		}

		public bool WriteUserFlashArea(List<byte> data)
		{
			byte type = 2;

			data = CreateListOfLength(data, 16);
			return SendReturnBool(type, 16, data);
		}

		public List<byte> ReadUserFlashArea()
		{
			byte type = 3;

			return SendReturnData(type, 0, (List<byte>)null);
		}
		public bool SaveState()
		{
			byte type = 4;

			return SendReturnBool(type, 0, null);
		}
		public bool Clear()
		{
			byte type = 6;

			return SendReturnBool(type, 0, null);
		}
		public bool WriteLine1(string line)
		{
			byte type = 7;

			return WriteLine(type, line);
		}
		public bool WriteLine1(List<byte> data)
		{
			byte type = 7;

			data = CreateListOfLength(data, 16);
			return SendReturnBool(type, 16, data);
		}
		public bool WriteLine2(string line)
		{
			byte type = 8;
			return WriteLine(type, line);
		}

		public bool WriteLine2(List<byte> data)
		{
			byte type = 8;

			data = CreateListOfLength(data, 16);
			return SendReturnBool(type, 16, data);
		}
		private bool WriteLine(byte type, string line)
		{
			line = CreateStringOfLength(line, LINE_LENGTH);
			byte[] vals = System.Text.Encoding.ASCII.GetBytes(line.ToCharArray());
			List<byte> sendVals = new List<byte>();
			foreach (byte b in vals)
			{
				sendVals.Add(b);
			}

			return SendReturnBool(type, 16, sendVals);
		}
		public bool SetCursorPosition(int column, int row)
		{
			byte type = 11;
			List<byte> data = new List<byte>();

			if (15 < column || 0 > column)
			{
				throw new ArgumentOutOfRangeException("column", "must be 0-15");
			}

			if (1 < column || 0 > column)
			{
				throw new ArgumentOutOfRangeException("row", "must be 0-1");
			}

			data.Add((byte)column);
			data.Add((byte)row);
			return SendReturnBool(type, 2, data);
		}

		//0-50(0=light 50= very dark)
		public bool SetLcdContrast(int contrastValue)
		{
			byte type = 13;
			List<byte> data = new List<byte>();

			if (0 > contrastValue || 50 < contrastValue)
			{
				throw new ArgumentOutOfRangeException("contrastValue", "must be 0 -50");
			}

			data.Add((byte)contrastValue);
			return SendReturnBool(type, 1, data);
		}
		//0-100(0= 0ff 100=on)
		public bool SetLcdBacklight(int backlightValue)
		{
			byte type = 14;
			List<byte> data = new List<byte>();

			if (0 > backlightValue || 100 < backlightValue)
			{
				throw new ArgumentOutOfRangeException("backlightValue", "must be 0 - 50");
			}

			data.Add((byte)backlightValue);
			return SendReturnBool(type, 1, data);
		}
		public List<byte> GetLastFanPulse
		{
			get
			{
				byte type = 15;
				return SendReturnData(type, 0, null);
			}
		}
		public bool SetupFanReporting(Fans fans)
		{
			byte type = 16;
			List<byte> data = new List<byte>();

			if ((int)fans < (int)Fans.Fan1 || (int)(Fans.Fan1 | Fans.Fan2 | Fans.Fan3 | Fans.Fan4) < (int)fans)
			{
				throw new ArgumentOutOfRangeException("backlightValue", "must be 0 -50");
			}

			data.Add((byte)fans);
			return SendReturnBool(type, 1, data);
		}
		public bool SetFan1Power(int fan1)
		{
			return SetFanPower(fan1, fan2Power, fan3Power, fan4Power);
		}
		public bool SetFan2Power(int fan2)
		{
			return SetFanPower(fan1Power, fan2, fan3Power, fan4Power);
		}
		public bool SetFan3Power(int fan3)
		{
			return SetFanPower(fan1Power, fan2Power, fan3, fan4Power);
		}
		public bool SetFan4Power(int fan4)
		{
			return SetFanPower(fan1Power, fan2Power, fan3Power, fan4);
		}

		public bool SetFanPower(params int[] fans)
		{
			if (fans == null) {
				throw new ArgumentNullException("The fans argument cannot be null");
			}
			if (fans.Length > 4)
			{
				throw new ArgumentException("At most, 4 fans can be specified");
			}

			byte type = 17;
			List<byte> data = new List<byte>();

			if (fans[0] < 0 || 100 < fans[0])
				throw new ArgumentOutOfRangeException("fan1", "must be 0-100");

			if (fans.Length > 1 && (fans[1] < 0 || 100 < fans[1]))
				throw new ArgumentOutOfRangeException("fan2", "must be 0-100");

			if (fans.Length > 2 && (fans[2] < 0 || 100 < fans[2]))
				throw new ArgumentOutOfRangeException("fan3", "must be 0-100");

			if (fans.Length > 3 && (fans[3] < 0 || 100 < fans[3]))
				throw new ArgumentOutOfRangeException("fan4", "must be 0-100");

			fan1Power = (byte)fans[0];
			data.Add(fan1Power);
			if (fans.Length > 1)
			{
				fan2Power = (byte)fans[1];
				data.Add(fan2Power);
				if (fans.Length > 2)
				{
					fan3Power = (byte)fans[2];
					data.Add(fan3Power);
					if (fans.Length > 3)
					{
						fan4Power = (byte)fans[3];
						data.Add(fan4Power);
					}
				}
			}

			return SendReturnBool(type, 4, data);
		}

		private string CreateStringOfLength(string s, int length)
		{
			if (length < s.Length)
				s = s.Substring(length);
			else if (length > s.Length)
			{
				s = s + (new String(' ', length - s.Length));
			}

			return s;
		}

		private List<byte> CreateListOfLength(List<byte> bArray, int length)
		{
			if (length != bArray.Count)
			{
				while (bArray.Count > 16)
				{
					bArray.RemoveAt(bArray.Count - 1);
				}
			}

			return bArray;
		}
		private LcdPacket Send(byte type, byte dataLength, List<byte> data)
		{
			ushort _cyclicRedundancyCheck;

			if ((null == data && dataLength != 0) || dataLength > data.Count)
				throw new ArgumentException("data");


			packetXMitBuffer[0] = type;
			packetXMitBuffer[1] = dataLength;
			if (0 != dataLength)
			{
				for (int i = 0; i < dataLength; i++)
				{
					packetXMitBuffer[i + 2] = data[i];
				}
			}

			_cyclicRedundancyCheck = CyclicRedundancyCheckGenerator.GenerateCyclicRedundancyCheck(packetXMitBuffer, dataLength + 2, CYCLIC_REDUNDANCY_CHECK_SEED);
			packetXMitBuffer[2 + dataLength + 1] = (byte)(_cyclicRedundancyCheck >> 8);
			packetXMitBuffer[2 + dataLength] = (byte)_cyclicRedundancyCheck;
			lock (responseSignal)
			{
				responsePacket = null;
				// comport
				if (com.IsOpen)
				{
					com.Write(packetXMitBuffer, 0, dataLength + 4);
					if (Monitor.Wait(responseSignal, MAX_RESPONSE_TIME))
					{
						return responsePacket;
					}
				}
				else
				{
					return null;
				}
			}

			return null;
		}
		private List<byte> SendReturnData(byte type, byte dataLength, List<byte> data)
		{
			LcdPacket packet = Send(type, dataLength, data);

			if (null != packet)
			{
				return packet.Data;
			}
			else
			{
				return null;
			}
		}

		private bool SendReturnBool(byte type, byte dataLength, List<byte> data)
		{
			LcdPacket packet = Send(type, dataLength, data);

			if (null != packet)
			{
				return (type == (packet.Type & 0x0F) && LcdPacket.LcdPacketType.NormalResponse == responsePacket.PacketType);
			}
			else
			{
				return false;
			}
		}
		private void Receive()
		{
			byte[] receiveBuffer = new byte[128];
			int bytesRead = 0;
			int bufferIndex = 0;
			int startPacketIndex = 0;
			int expectedPacketLength = -1;
			bool expectedPacketLengthIsSet = false;
			int numBytesToRead = receiveBuffer.Length;

			while (true)
			{
				if (expectedPacketLengthIsSet || 1 >= bytesRead)
				{
					//If the expectedPacketLength has been or no bytes have been read
					//This covers the case that more then 1 entire packet has been read in at a time
					// comport
					try
					{
						bytesRead += com.Read(receiveBuffer, bufferIndex, numBytesToRead);
						bufferIndex = startPacketIndex + bytesRead;
					}
					catch (IOException)
					{
						return;
					}
				}

				if (1 < bytesRead)
				{
					//The buffer has the dataLength for the packet
					if (!expectedPacketLengthIsSet)
					{
						//If the expectedPacketLength has not been set for this packet
						expectedPacketLength = receiveBuffer[(1 + startPacketIndex) % receiveBuffer.Length] + 4;
						expectedPacketLengthIsSet = true;
					}

					if (bytesRead >= expectedPacketLength)
					{
						//The buffer has atleast as many bytes for this packet
						AddPacket(receiveBuffer, startPacketIndex);
						expectedPacketLengthIsSet = false;
						if (bytesRead == expectedPacketLength)
						{
							//The buffer contains only the bytes for this packet
							bytesRead = 0;
							bufferIndex = startPacketIndex;
						}
						else
						{
							//The buffer also has bytes for the next packet
							startPacketIndex += expectedPacketLength;
							startPacketIndex %= receiveBuffer.Length;
							bytesRead -= expectedPacketLength;
							bufferIndex = startPacketIndex + bytesRead;
						}
					}
				}

				bufferIndex %= receiveBuffer.Length;
				numBytesToRead = bufferIndex < startPacketIndex ? startPacketIndex - bufferIndex : receiveBuffer.Length - bufferIndex;
			}
		}
		private void ReportEventHandler()
		{
			LcdPacket packet = null;

			while (true)
			{
				while (null == packet)
				{
					lock (reportSignal)
					{
						if (0 != reportQueue.Count)
							packet = reportQueue.Dequeue();
						else
							Monitor.Wait(reportSignal);
					}
				}

				switch (packet.Type)
				{
					case KEY_ACTIVITY_REPORT :
						ReportKeyActivityEventHandler(packet);
						break;
				}
				packet = null;
			}
		}

		public LcdKey Key
		{
			get
			{
				return _key;
			}
			set
			{
				_key = value;
			}
		}

		private void ReportKeyActivityEventHandler(LcdPacket packet)
		{
			if (1 != packet.DataLength)
			{
				return;
			}

			switch (packet.Data[0])
			{
				case 1:
					Key = LcdKey.Up;
					break;

				case 2:
					Key = LcdKey.Down;
					break;

				case 3:
					Key = LcdKey.Left;
					break;

				case 4:
					Key = LcdKey.Right;
					break;

				case 5:
					Key = LcdKey.Enter;
					break;

				case 6:
					Key = LcdKey.Exit;
					break;

				case 7:
					if (Key == LcdKey.Up)
						Key = LcdKey.None;

					break;

				case 8:
					if (Key == LcdKey.Down)
						Key = LcdKey.None;

					break;

				case 9:
					if (Key == LcdKey.Left)
						Key = LcdKey.None;

					break;

				case 10:
					if (Key == LcdKey.Right)
						Key = LcdKey.None;

					break;

				case 11:
					if (Key == LcdKey.Enter)
						Key = LcdKey.None;

					break;

				case 12:
					if (Key == LcdKey.Enter)
						Key = LcdKey.None;

					break;
			}
		}

		private void ReportKeyActivityEventHandler(KeyActivityEventHandler keyActivityEventHandler)
		{
			try
			{
				if (null != keyActivityEventHandler)
					keyActivityEventHandler(this, null);
			}
			catch (Exception) { }
		}

		private LcdPacket CreatePacket(byte[] buffer, int startIndex)
		{
			byte type = buffer[startIndex];
			byte dataLength = buffer[(startIndex + 1) % buffer.Length];
			List<byte> data = new List<byte>();
			ushort _cyclicRedundancyCheck = 0;

			for (int i = 0; i < dataLength; i++)
			{
				data.Add(buffer[(startIndex + 2 + i) % buffer.Length]);
			}

			_cyclicRedundancyCheck |= (ushort)buffer[(startIndex + 2 + dataLength) % buffer.Length];
			_cyclicRedundancyCheck |= (ushort)(buffer[(startIndex + 2 + dataLength + 1) % buffer.Length] << 8);
			return new LcdPacket(type, dataLength, data, _cyclicRedundancyCheck);
		}
		private bool AddPacket(byte[] buffer, int startIndex)
		{
			LcdPacket packet = CreatePacket(buffer, startIndex);
			ushort calculatedCyclicRedundancyCheck = CyclicRedundancyCheckGenerator.GenerateCyclicRedundancyCheck(buffer, startIndex, packet.DataLength + 2, CYCLIC_REDUNDANCY_CHECK_SEED);

			switch (packet.PacketType)
			{
				case LcdPacket.LcdPacketType.NormalResponse :
					AddResponsePacket(packet);
					break;

				case LcdPacket.LcdPacketType.NormalReport :
					AddReportPacket(packet);
					break;

				case LcdPacket.LcdPacketType.ErrorResponse :
					AddResponsePacket(packet);
					break;
			}
			if (calculatedCyclicRedundancyCheck != packet.CyclicRedundancyCheck)
			{
				Console.WriteLine("CyclicRedundancyCheck ERROR!!!: Calculated CyclicRedundancyCheck={0} Actual CyclicRedundancyCheck={1}", Convert.ToString(calculatedCyclicRedundancyCheck, 16), packet.CyclicRedundancyCheck, CultureInfo.InvariantCulture);
				return false;
			}

			return true;
		}
		private void AddResponsePacket(LcdPacket packet)
		{
			lock (responseSignal)
			{
				responsePacket = packet;
				Monitor.Pulse(responseSignal);
			}
		}
		private void AddReportPacket(LcdPacket packet)
		{
			lock (reportSignal)
			{
				reportQueue.Enqueue(packet);
				Monitor.Pulse(reportSignal);
			}
		}

		public bool IsOpen
		{
			get
			{
				if (com == null)
					return false;
				else
					return com.IsOpen;
			}
		}

		public void Reset()
		{
			WriteLine1("Crystalfontz 633");
			WriteLine2("HW v1.2  FW v1.0");
		}

		public void Open()
		{
			if (!com.IsOpen)
			{
				com.Open();
				SetLcdContrast(15);
				SetLcdBacklight(100);
				WriteLine1("Ready...");
				WriteLine2("");
				eventThread = new Thread(new ThreadStart(ReportEventHandler));
				eventThread.Start();
				receiveThread = new Thread(new ThreadStart(Receive));
				receiveThread.Start();
			}
		}

		public void Close()
		{
			// comport
			if (com.IsOpen)
			{
				Reset();
				com.Close();
				receiveThread.Abort();
				eventThread.Abort();
			}
		}
	}

	[CLSCompliant(false)]
	public class LcdPacket
	{
		private byte type;
		private byte dataLength;
		private List<byte> data;
		private ushort _cyclicRedundancyCheck;
		public enum LcdPacketType { NormalResponse, NormalReport, ErrorResponse };
		private const byte NORMAL_RESPONSE = 0x40;
		private const byte NORMAL_REPORT = 0x80;
		private const byte ERROR_RESPONSE = 0xC0;
		public LcdPacket(byte type, byte dataLength, List<byte> data)
		{
			this.type = type;
			this.dataLength = dataLength;
			this.data = data;
		}
		public LcdPacket(byte type, byte dataLength, List<byte> data, ushort cyclicRedundancyCheckValue)
		{
			this.type = type;
			this.dataLength = dataLength;
			this.data = data;
			this._cyclicRedundancyCheck = cyclicRedundancyCheckValue;
		}
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();

			sb.Append("Type: " + Convert.ToString(type, 16) + "\n");
			sb.Append("DataLength: " + Convert.ToString(dataLength, 16) + "\n");
			sb.Append("Data: ");
			for (int i = 0; i < dataLength; i++)
			{
				sb.Append(Convert.ToString(data[i], 16) + ", ");
			}

			sb.Append("\n");
			sb.Append("CyclicRedundancyCheck: " + Convert.ToString(_cyclicRedundancyCheck, 16) + "\n");
			return sb.ToString();
		}
		public byte Type
		{
			get
			{
				return type;
			}
		}

		public LcdPacketType PacketType
		{
			get
			{
				switch (type & 0xC0)
				{
					case NORMAL_RESPONSE :
						return LcdPacketType.NormalResponse;

					case NORMAL_REPORT :
						return LcdPacketType.NormalReport;

					case ERROR_RESPONSE :
						return LcdPacketType.ErrorResponse;

					default :
						throw new Exception("Unexpected Packet Type: " + System.Convert.ToString(type, 16));
				}
			}
		}

		public byte DataLength
		{
			get
			{
				return dataLength;
			}
		}
		public List<byte> Data
		{
			get
			{
				return data;
			}
		}
		public ushort CyclicRedundancyCheck
		{
			get
			{
				return _cyclicRedundancyCheck;
			}
		}
	}
	[CLSCompliant(false)]
	public sealed class CyclicRedundancyCheckGenerator
	{
		private CyclicRedundancyCheckGenerator() {}

		//CyclicRedundancyCheck lookup table to avoid bit-shifting loops.
		static ushort[] CyclicRedundancyCheckLookupTable = {
			0x00000, 0x01189, 0x02312, 0x0329B, 0x04624, 0x057AD, 0x06536, 0x074BF, 0x08C48, 0x09DC1, 0x0AF5A, 0x0BED3, 0x0CA6C, 0x0DBE5, 0x0E97E, 0x0F8F7, 0x01081, 0x00108, 0x03393, 0x0221A, 0x056A5, 0x0472C, 0x075B7, 0x0643E, 0x09CC9, 0x08D40, 0x0BFDB, 0x0AE52, 0x0DAED, 0x0CB64, 0x0F9FF, 0x0E876, 0x02102, 0x0308B, 0x00210, 0x01399, 0x06726, 0x076AF, 0x04434, 0x055BD, 0x0AD4A, 0x0BCC3, 0x08E58, 0x09FD1, 0x0EB6E, 0x0FAE7, 0x0C87C, 0x0D9F5, 0x03183, 0x0200A, 0x01291, 0x00318, 0x077A7, 0x0662E, 0x054B5, 0x0453C, 0x0BDCB, 0x0AC42, 0x09ED9, 0x08F50, 0x0FBEF, 0x0EA66, 0x0D8FD, 0x0C974, 0x04204, 0x0538D, 0x06116, 0x0709F, 0x00420, 0x015A9, 0x02732, 0x036BB, 0x0CE4C, 0x0DFC5, 0x0ED5E, 0x0FCD7, 0x08868, 0x099E1, 0x0AB7A, 0x0BAF3, 0x05285, 0x0430C, 0x07197, 0x0601E, 0x014A1, 0x00528, 0x037B3, 0x0263A, 0x0DECD, 0x0CF44, 0x0FDDF, 0x0EC56, 0x098E9, 0x08960, 0x0BBFB, 0x0AA72, 0x06306, 0x0728F, 0x04014, 0x0519D, 0x02522, 0x034AB, 0x00630, 0x017B9, 0x0EF4E, 0x0FEC7, 0x0CC5C, 0x0DDD5, 0x0A96A, 0x0B8E3, 0x08A78, 0x09BF1, 0x07387, 0x0620E, 0x05095, 0x0411C, 0x035A3, 0x0242A, 0x016B1, 0x00738, 0x0FFCF, 0x0EE46, 0x0DCDD, 0x0CD54, 0x0B9EB, 0x0A862, 0x09AF9, 0x08B70, 0x08408, 0x09581, 0x0A71A, 0x0B693, 0x0C22C, 0x0D3A5, 0x0E13E, 0x0F0B7, 0x00840, 0x019C9, 0x02B52, 0x03ADB, 0x04E64, 0x05FED, 0x06D76, 0x07CFF, 0x09489, 0x08500, 0x0B79B, 0x0A612, 0x0D2AD, 0x0C324, 0x0F1BF, 0x0E036, 0x018C1, 0x00948, 0x03BD3, 0x02A5A, 0x05EE5, 0x04F6C, 0x07DF7, 0x06C7E, 0x0A50A, 0x0B483, 0x08618, 0x09791, 0x0E32E, 0x0F2A7, 0x0C03C, 0x0D1B5, 0x02942, 0x038CB, 0x00A50, 0x01BD9, 0x06F66, 0x07EEF, 0x04C74, 0x05DFD, 0x0B58B, 0x0A402, 0x09699, 0x08710, 0x0F3AF, 0x0E226, 0x0D0BD, 0x0C134, 0x039C3, 0x0284A, 0x01AD1, 0x00B58, 0x07FE7, 0x06E6E, 0x05CF5, 0x04D7C, 0x0C60C, 0x0D785, 0x0E51E, 0x0F497, 0x08028, 0x091A1, 0x0A33A, 0x0B2B3, 0x04A44, 0x05BCD, 0x06956, 0x078DF, 0x00C60, 0x01DE9, 0x02F72, 0x03EFB, 0x0D68D, 0x0C704, 0x0F59F, 0x0E416, 0x090A9, 0x08120, 0x0B3BB, 0x0A232, 0x05AC5, 0x04B4C, 0x079D7, 0x0685E, 0x01CE1, 0x00D68, 0x03FF3, 0x02E7A, 0x0E70E, 0x0F687, 0x0C41C, 0x0D595, 0x0A12A, 0x0B0A3, 0x08238, 0x093B1, 0x06B46, 0x07ACF, 0x04854, 0x059DD, 0x02D62, 0x03CEB, 0x00E70, 0x01FF9, 0x0F78F, 0x0E606, 0x0D49D, 0x0C514, 0x0B1AB, 0x0A022, 0x092B9, 0x08330, 0x07BC7, 0x06A4E, 0x058D5, 0x0495C, 0x03DE3, 0x02C6A, 0x01EF1, 0x00F78
		};
		public static ushort GenerateCyclicRedundancyCheck(byte[] data, int dataLength, ushort seed)
		{
			ushort newCyclicRedundancyCheck;

			newCyclicRedundancyCheck = seed;
			for (int i = 0; i < dataLength; i++)
			{
				newCyclicRedundancyCheck = (ushort)((newCyclicRedundancyCheck >> 8) ^ CyclicRedundancyCheckLookupTable[(newCyclicRedundancyCheck ^ data[i]) & 0xff]);
			}

			return ((ushort)~newCyclicRedundancyCheck);
		}
		public static ushort GenerateCyclicRedundancyCheck(byte[] data, int startIndex, int length, ushort seed)
		{
			ushort newCyclicRedundancyCheck;

			newCyclicRedundancyCheck = seed;
			for (int i = 0; i < length; i++)
			{
				newCyclicRedundancyCheck = (ushort)((newCyclicRedundancyCheck >> 8) ^ CyclicRedundancyCheckLookupTable[(newCyclicRedundancyCheck ^ data[(startIndex + i) % data.Length]) & 0xff]);
			}

			return ((ushort)~newCyclicRedundancyCheck);
		}
	}
}