//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Security.Permissions;
    using System.Text;
    using System.Threading;

    [HostProtection(Synchronization = true)]
    internal sealed class MultifileTraceListener : TraceListener
    {
        const string Extension = ".xml";
        const string MaxDiskSpaceAttribute = "maxDiskSpace";
        const int DefaultMaxDiskSpace = 100;
        const int UnlimitedMaxDiskSpace = -1;

        int         currentMessage = 0;
        int         maxDiskSpace = 0;
        bool        maxDiskSpaceInitialized = false;
        string      fileNamePrefix;
        long        amountDataWritten = 0;
        string      filePath;
        long        lastWriteTime = 0;
        bool        ranOutOfDiskAllowed = false;
        object      syncRoot = new object();

        public MultifileTraceListener() 
            : this(DefaultPath)
        {
        }

        public MultifileTraceListener(string filePath) 
        {
            if (null == filePath)
            {
                throw new ArgumentNullException("filePath");
            }

            this.filePath = filePath;
        }

        static string DefaultPath
        {
            get
            {
                return Environment.SystemDirectory + @"\LogFiles\Messages";
            }
        }

        protected override string[] GetSupportedAttributes()
        {
            return new string[] { MultifileTraceListener.MaxDiskSpaceAttribute };
        }

        int MaxDiskSpace
        {
            get
            {
                if (!this.maxDiskSpaceInitialized)
                {
                    lock (this.syncRoot)
                    {
                        if (!this.maxDiskSpaceInitialized)
                        {
                            try
                            {
                                string maxDiskSpaceOption = this.Attributes[MultifileTraceListener.MaxDiskSpaceAttribute];
                                this.maxDiskSpace = null == maxDiskSpaceOption ?
                                    MultifileTraceListener.DefaultMaxDiskSpace :
                                    int.Parse(maxDiskSpaceOption, CultureInfo.InvariantCulture);
                            }
                            catch (System.FormatException e)
                            {
                                throw new System.Configuration.ConfigurationErrorsException("Invalid value for maxDiskSpaceAttribute.", e);
                            }
                            finally
                            {
                                this.maxDiskSpaceInitialized = true;
                            }
                        }
                    }
                }

                return this.maxDiskSpace;
            }
        }

        string FileNamePrefix
        {
            get
            {
                if (fileNamePrefix == null)
                {
                    lock (this.syncRoot)
                    {
                        if (fileNamePrefix == null)
                        {
                            filePath = Path.GetFullPath(filePath);

                            if (!filePath.EndsWith(new String(Path.DirectorySeparatorChar, 1), StringComparison.Ordinal))
                            {
                                filePath += new String(Path.DirectorySeparatorChar, 1);
                            }

                            if (!Directory.Exists(filePath))
                            {
                                //avoiding synchronization issues
                                try
                                {
                                    Directory.CreateDirectory(filePath);
                                }
                                catch
                                {
                                    if (!Directory.Exists(filePath))
                                    {
                                        throw;
                                    }
                                }
                            }

                            using (Process process = Process.GetCurrentProcess())
                            {
                                string processId = process.Id.ToString(CultureInfo.InvariantCulture);
                                string name = AppDomain.CurrentDomain.FriendlyName;
                                fileNamePrefix = String.Format(CultureInfo.InvariantCulture, "{0}{1}({2})", filePath, processId, name.Replace('/', '-'));
                            }
                        }
                    }
                }

                return fileNamePrefix;
            }
        }

        void WriteStringToNewFile(string data)
        {
            long ticks = DateTime.Now.Ticks;

            lock (this.syncRoot)
            {
                ++this.currentMessage;
                if (ticks <= this.lastWriteTime)
                {
                    ++this.lastWriteTime;
                    ticks = this.lastWriteTime;
                }
                else
                {
                    this.lastWriteTime = ticks;
                }
            }

            string ticksString = ticks.ToString(CultureInfo.InvariantCulture);
            string fileName = String.Format(CultureInfo.InvariantCulture, "{0}_{1}_{2}{3}", this.FileNamePrefix, ticksString, currentMessage, MultifileTraceListener.Extension);
            Stream stream;
            try
            {
                stream = File.Open(fileName, FileMode.Create);
            }
            catch (System.IO.IOException)
            {
                fileName = String.Format(CultureInfo.InvariantCulture, "{0}_{1}_{2}.{4}{3}", this.FileNamePrefix, ticksString, currentMessage, MultifileTraceListener.Extension, Guid.NewGuid());
                stream = File.Open(fileName, FileMode.Create);
            }

            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(data);
            }

            if (this.MaxDiskSpace != MultifileTraceListener.UnlimitedMaxDiskSpace)
            {
                FileInfo fi = new FileInfo(fileName);
                this.amountDataWritten += fi.Length;
            }
        }

        public override void Write(string data)
        {
            WriteLine(data);
        }

        public override void WriteLine(string data)
        {
            if (data != null)
            {
                if (!this.ranOutOfDiskAllowed)
                {
                    if (this.MaxDiskSpace == MultifileTraceListener.UnlimitedMaxDiskSpace || this.amountDataWritten + data.Length <= (this.MaxDiskSpace * (1 << 20))) //convert MB to B
                    {
                        WriteStringToNewFile(data);
                    }
                    else
                    {
                        EventLog.WriteEntry("MultifileTraceListener","MultifileTraceListener exceeded allowed disk space. Consider adjusting maxDiskSpace configuration attribute.", EventLogEntryType.Warning);
                        this.ranOutOfDiskAllowed = true;
                    }
                }
            }
        }

        public override void TraceData(TraceEventCache eventCache, String source, TraceEventType severity, int id, object data)
        {
            WriteLine(data);
        }

        public override void TraceData(TraceEventCache eventCache, String source, TraceEventType severity, int id, params object[] data)
        {
            if (data != null)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != null)
                        WriteLine(data[i]);
                }
            }
        }

        public override void TraceEvent(TraceEventCache eventCache, String source, TraceEventType severity, int id, string message)
        {
            WriteLine(message);
        }

        public override void TraceEvent(TraceEventCache eventCache, String source, TraceEventType severity, int id, string format, params object[] args)
        {
            if (args != null)
                WriteLine(String.Format(CultureInfo.InvariantCulture, format, args));
            else
                WriteLine(format);
        }

        public override void WriteLine(object data)
        {
            Debug.Assert(data != null);
            WriteLine(data.ToString());
        }
    }
}

