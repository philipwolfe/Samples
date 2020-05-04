using System;
using System.IO;
using System.Net;
using System.Text;

namespace PAB.ExceptionHandler
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SysLogPacket
	{
		private byte _bPRI;
		private string _sTime;
		private string _sMachine;
		private string _sMessage;
		private PriorityType _Priority;
		private FacilityType _Facility;

		/// <summary>
		/// Enum for Priority levels
		/// </summary>
		public enum PriorityType
		{
			Emergency,
			Alert,
			Critical,
			Error,
			Warning,
			Notice,
			Informational,
			Debug
		}

		/// <summary>
		/// Enum for facility types
		/// </summary>
		public enum FacilityType
		{
			kernel_messages, // 0
			user_level_messages,
			mail_system,
			system_daemons,
			security_authorization_messages,
			internal_mess,
			line_printer_subsystem,
			network_news_subsystem,
			UUCP_subsystem,
			clock_daemon,
			security_authorization_messages2,
			FTP_daemon,
			NTP_subsystem, //12
			log_audit,
			log_alert,
			clock_daemon2,
			local_use_0,
			local_use_1,
			local_use_2,
			local_use_3, //19
			local_use_4,
			local_use_5,
			local_use_6,
			local_use_7,
            SipServer
		}

		/// <summary>
		/// Constructor, defaults to current time, machine name is resolved by DNS
		/// </summary>
		public SysLogPacket()
		{
			Time = DateTime.Now.ToString("MMM dd HH:mm:ss");
			try
			{
				Machine = Dns.GetHostName();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error resolving machine name: " + e.Message);
			}
		}

		/// <summary>
		/// Gets or sets the facility.
		/// </summary>
		/// <value></value>
		public FacilityType Facility
		{
			get { return _Facility; }
			set { _Facility = value; }
		}

		/// <summary>
		/// Gets or sets the priority.
		/// </summary>
		/// <value></value>
		public PriorityType Priority
		{
			get { return _Priority; }
			set { _Priority = value; }
		}

		/// <summary>
		/// Gets or sets the time.
		/// </summary>
		/// <value></value>
		public string Time
		{
			get { return _sTime; }
			set { _sTime = value; }
		}

		/// <summary>
		/// Gets or sets the machine.
		/// </summary>
		/// <value></value>
		public string Machine
		{
			get { return _sMachine; }
			set { _sMachine = value; }
		}

		
		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value></value>
		public string Message
		{
			get { return _sMessage; }
			set { _sMessage = value; }
		}

		/// <summary>
		/// Serialize to byte[]
		/// </summary>
		/// <returns>byte[] packet</returns>
		public byte[] Serialize()
		{
			_bPRI = (byte) (((byte) _Facility << 3) + ((byte) _Priority & 0x7));
			string sPRI = _bPRI.ToString();


			byte[] buf = new byte[sPRI.Length + _sTime.Length + _sMachine.Length + _sMessage.Length + 4];

			MemoryStream ms = new MemoryStream(buf);
			ms.WriteByte(0x3c); // write "<"
			ms.Write(ASCIIEncoding.ASCII.GetBytes(sPRI), 0, sPRI.Length);
			ms.WriteByte(0x3e); //write ">"
			ms.Write(ASCIIEncoding.ASCII.GetBytes(_sTime), 0, _sTime.Length);
			ms.WriteByte(0x20); // write space
			ms.Write(ASCIIEncoding.ASCII.GetBytes(_sMachine), 0, _sMachine.Length);
			ms.WriteByte(0x20); // write space
			ms.Write(ASCIIEncoding.ASCII.GetBytes(_sMessage), 0, _sMessage.Length);
			return buf;
		}

		/// <summary>
		/// Serializes a Syslog Packet
		/// </summary>
		/// <param name="pkt">SysLogPacket</param>
		/// <returns>byte[] packet bytes</returns>
		public byte[] Serialize(SysLogPacket pkt)
		{
			_bPRI = (byte) (((byte) pkt._Facility << 3) + ((byte) pkt._Priority & 0x7));
			string sPRI = _bPRI.ToString();
			byte[] buf = new byte[sPRI.Length + pkt._sTime.Length + pkt._sMachine.Length + pkt._sMessage.Length + 4];
			MemoryStream ms = new MemoryStream(buf);
			ms.WriteByte(0x3c); // write "<"
			ms.Write(ASCIIEncoding.ASCII.GetBytes(sPRI), 0, sPRI.Length);
			ms.WriteByte(0x3e); //write ">"
			ms.Write(ASCIIEncoding.ASCII.GetBytes(pkt._sTime), 0, pkt._sTime.Length);
			ms.WriteByte(0x20); // write space
			ms.Write(ASCIIEncoding.ASCII.GetBytes(pkt._sMachine), 0, pkt._sMachine.Length);
			ms.WriteByte(0x20); // write space
			ms.Write(ASCIIEncoding.ASCII.GetBytes(pkt._sMessage), 0, pkt._sMessage.Length);
			return buf;
		}

		/// <summary>
		/// Deserializes the specified SysLog Packet
		/// </summary>
		/// <param name="bPkt">Byte[] packet</param>
		/// <returns></returns>
		public SysLogPacket Deserialize (byte[] bPkt)
		{
			SysLogPacket workPkt = new SysLogPacket() ;
			string retStr = String.Empty;
   string workStr = System.Text.Encoding.UTF8.GetString(bPkt) ;
			string bPriStr = workStr.Substring(workStr.IndexOf("<")+1,workStr.IndexOf(">")-(workStr.IndexOf("<")+1)   ) ;
			int p= int.Parse(bPriStr);
    
			 byte bPri=(byte)p;
			workPkt._Priority = (SysLogPacket.PriorityType )(bPri & 7);
			workPkt.Facility = (SysLogPacket.FacilityType )(bPri >>3);
			workPkt._sTime =workStr.Substring(workStr.IndexOf(">")+1,15  ) ;
			workStr = workStr.Substring( workStr.IndexOf(">")+17) ;
	
			workPkt.Machine = workStr.Substring(0,workStr.IndexOf(" "));
			workStr = workStr.Substring(workStr.IndexOf(" ")+1);
		 workPkt._sMessage = workStr;
			if(workPkt._sMessage.Length ==0) throw new InvalidOperationException("Invalid or empty Message") ;
			return workPkt;
		}
	}
}