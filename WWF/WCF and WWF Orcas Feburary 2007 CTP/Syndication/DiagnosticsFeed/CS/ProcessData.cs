using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using System.Runtime.Serialization;

namespace HelloSyndication
{
    [DataContract]
    class ProcessData
    {
        [DataMember]
        long VirtualMemorySize;

        [DataMember]
        long PeakVirtualMemorySize;

        [DataMember]
        long PeakWorkingSetSize;

        public ProcessData(Process p)
        {
            this.VirtualMemorySize = p.VirtualMemorySize64;
            this.PeakVirtualMemorySize = p.PeakVirtualMemorySize64;
            this.PeakWorkingSetSize = p.PeakWorkingSet64;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Virtual Memory: {0}", this.VirtualMemorySize);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("PeakVirtualMemorySize: {0}", this.PeakVirtualMemorySize);
            sb.Append(Environment.NewLine);
            sb.AppendFormat("PeakWorkingSetSize: {0}", this.PeakWorkingSetSize);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }
    }
}
