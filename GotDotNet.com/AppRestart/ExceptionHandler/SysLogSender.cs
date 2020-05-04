using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Net;

namespace PAB.ExceptionHandler
{	
	public class Sender
	{
		public  enum PriorityType
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
		private static UdpClient udp;
		private static ASCIIEncoding ascii= new ASCIIEncoding();
    private static string machine= System.Net.Dns.GetHostName() + " ";		
		private  Sender()
		{					
		}

		public static void Send(string ipAddress,  string body)
		{		
			if(ipAddress==null || (ipAddress.Length<5)) ipAddress=Dns.Resolve(Dns.GetHostName()).AddressList[0].ToString();
			 Send(Sender.PriorityType.Warning,DateTime.Now,body);
		}
		public static void Send( string body)
		{	
			string ipAddress = System.Configuration.ConfigurationSettings.AppSettings["sysLogIp"].ToString();
			if(udp==null) udp = new UdpClient(ipAddress, 514);
			byte[] rawMsg;
		PriorityType priority =Sender.PriorityType.Warning ;
			string[] strParams = { priority.ToString()+": ", DateTime.Now.ToString("MMM dd HH:mm:ss "),
									 machine,
									 body };
			rawMsg = ascii.GetBytes(string.Concat(strParams));
			udp.Send(rawMsg, rawMsg.Length);
			udp.Close();			 
			udp=null;			 
		}

		public static void Send(PriorityType priority, DateTime time, string body)
		{	
			string ipAddress = 
			 System.Configuration.ConfigurationSettings.AppSettings["sysLogIp"].ToString();
			if(udp==null) udp = new UdpClient(ipAddress, 514);
			byte[] rawMsg;
			string[] strParams = { priority.ToString()+": ", time.ToString("MMM dd HH:mm:ss "),
									 machine,
									 body };
			rawMsg = ascii.GetBytes(string.Concat(strParams));
			udp.Send(rawMsg, rawMsg.Length);
			udp.Close();			 
			udp=null;			 
		}

		public static void Send(string ipAddress,PriorityType priority, DateTime time, string body)
		{				
			if(udp==null) udp = new UdpClient(ipAddress, 514);
			byte[] rawMsg;
			string[] strParams = { priority.ToString()+": ", time.ToString("MMM dd HH:mm:ss "),
									 machine,
									 body };
			rawMsg = ascii.GetBytes(string.Concat(strParams));
			udp.Send(rawMsg, rawMsg.Length);
			udp.Close();			 
			udp=null;			 
		}

        //Jitender Modifications
        private static string _sDestIp;
        private static int _nDestPort = 514;

        public static void Send(SysLogPacket.FacilityType facility, SysLogPacket.PriorityType priority, string message)
        {
            string destIp = System.Configuration.ConfigurationSettings.AppSettings["sysLogIp"].ToString();
            udp = new UdpClient(destIp, _nDestPort);
            Sender._sDestIp = destIp;
            SysLogPacket pkt = new SysLogPacket();
            pkt.Facility = facility;
            pkt.Priority = priority;
            pkt.Message = message;
            pkt.Machine = Environment.MachineName;
            byte[] b = pkt.Serialize();
            udp.Send(b, b.Length);
        }

        public static void Send(SysLogPacket.PriorityType priority, string message)
        {
            string destIp = System.Configuration.ConfigurationSettings.AppSettings["sysLogIp"].ToString();
            udp = new UdpClient(destIp, Sender._nDestPort);
            Sender._sDestIp = destIp;
            SysLogPacket pkt = new SysLogPacket();
            pkt.Facility = SysLogPacket.FacilityType.SipServer;
            pkt.Priority = priority;
            pkt.Message = message;
            pkt.Machine = Environment.MachineName;
            byte[] b = pkt.Serialize();
            udp.Send(b, b.Length);
        }


        //Jitender Modifications
	}
}