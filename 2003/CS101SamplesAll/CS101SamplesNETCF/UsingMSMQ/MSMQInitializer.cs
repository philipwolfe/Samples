using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices; // For DllImport
using System.IO; // For File IO

namespace UsingMSMQ
{
    class MSMQInitializer
    {
        // Constructor
        public MSMQInitializer()
        {
        }

        // MSMQAdm.exe utility 
        private const String MSMQ_ADM = @"\windows\msmqadm.exe";
        private const String MSMQ_DRIVER_REG = @"Drivers\BuiltIn\MSMQD";

        public class ProcessInfo
        {
            public IntPtr hProcess = IntPtr.Zero;
            public IntPtr hThread = IntPtr.Zero;
            public Int32 ProcessId = 0;
            public Int32 ThreadId = 0;
        }

        [DllImport("CoreDll.DLL", SetLastError = true)]
        private extern static int CreateProcess(
            String imageName,
            String cmdLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            Int32 boolInheritHandles,
            Int32 dwCreationFlags,
            IntPtr lpEnvironment,
            IntPtr lpszCurrentDir,
            IntPtr lpsiStartInfo,
            ProcessInfo pi);

        [DllImport("CoreDll.dll")]
        private extern static Int32 GetLastError();

        [DllImport("CoreDll.dll")]
        private extern static Int32 GetExitCodeProcess(IntPtr hProcess, out Int32 exitcode);

        [DllImport("CoreDll.dll")]
        private extern static Int32 CloseHandle(IntPtr hProcess);

        [DllImport("CoreDll.dll")]
        private extern static IntPtr ActivateDevice(string lpszDevKey, Int32 dwClientInfo);

        [DllImport("CoreDll.dll")]
        private extern static Int32 WaitForSingleObject(IntPtr Handle, Int32 Wait);

        public String Init()
        {
            // Create a StringBuilder to store the status
            StringBuilder sb = new StringBuilder();

            // We need to move the MSMQ components deployed to the system folder
            CopyFilesRequired();

            // Check status of MSMQ (is it installed and running yet?
            if (!(CreateProcess(MSMQ_ADM, "status")))
            {
                // Deletes the MSMQ registry key and store directory. All messages are lost.
                CreateProcess(MSMQ_ADM, "register cleanup");

                // Installs MSMQ as device drivers.
                if (CreateProcess(MSMQ_ADM, "register install"))
                {
                    sb.Append("Registered Drivers Successfully\n");
                }
                else
                {
                    throw new Exception("Failed to install MSMQ! System Error = " + GetLastError().ToString());
                }

                // Creates the MSMQ Configuration in Registry
                if (CreateProcess(MSMQ_ADM, "register"))
                {
                    sb.Append("Registered MSMQ Successfully\n");
                }
                else
                {
                    throw new Exception("Failed to Register MSMQ! System Error = " + GetLastError().ToString());
                }

                // Enables the native MSMQ protocol
                if (CreateProcess(MSMQ_ADM, "enable binary"))
                {
                    sb.Append("Enable Binary Successfully\n");
                }
                else
                {
                    throw new Exception("Failed to enable Binary! System Error = " + GetLastError().ToString());
                }

                // Starts the MSMQ service
                if (CreateProcess(MSMQ_ADM, "start"))
                {
                    sb.Append("Started MSMQ Successfully\n");
                }
                else
                {
                    // This is one additional step that is needed for PocketPCs
                    // The Device Drivers have to be loaded before the service can be started 

                    // ActivateDevice will load the device drivers
                    IntPtr handle = ActivateDevice(MSMQ_DRIVER_REG, 0);
                    CloseHandle(handle);

                    // Let us check if MSMQ is running
                    if (CreateProcess(MSMQ_ADM, "status"))
                    {
                        sb.Append("MSMQ is up and running\n");
                    }
                    else
                    {
                        throw new Exception("Failed to start MSMQ! System Error = " + GetLastError().ToString());
                    }
                }
            }
            else
                sb.Append("MSMQ is already up and running\n");

            // Return Status
            return sb.ToString();
        }

        // CreateProcess
        // Used to Create a process
        private bool CreateProcess(String ExeName, String CmdLine)
        {
            Int32 INFINITE;
            unchecked { INFINITE = (int)0xFFFFFFFF; }

            ProcessInfo pi = new ProcessInfo();
            if (CreateProcess(ExeName, CmdLine, IntPtr.Zero, IntPtr.Zero,
                0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, pi) == 0)
            {
                return false;
            }

            WaitForSingleObject(pi.hProcess, INFINITE);

            Int32 exitCode;
            if (GetExitCodeProcess(pi.hProcess, out exitCode) == 0)
            {
                // Free handles
                CloseHandle(pi.hThread); 
                CloseHandle(pi.hProcess);
                throw new Exception("Failure in GetExitCodeProcess");
            }
            // Free handles
            CloseHandle(pi.hThread);
            CloseHandle(pi.hProcess);

            if (exitCode != 0)
                return false;
            else
                return true;
        }

        // CopyFilesRequired
        private static void CopyFilesRequired()
        {
            string myPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (!File.Exists(@"\windows\msmqadm.exe"))
                File.Copy(myPath + "\\msmqadm.exe", @"\windows\msmqadm.exe");

            if (!File.Exists(@"\windows\msmqadmext.dll"))
                File.Copy(myPath + "\\msmqadmext.dll", @"\windows\msmqadmext.dll");

            if (!File.Exists(@"\windows\msmqd.dll"))
                File.Copy(myPath + "\\msmqd.dll", @"\windows\msmqd.dll");

            if (!File.Exists(@"\windows\msmqrt.dll"))
                File.Copy(myPath + "\\msmqrt.dll", @"\windows\msmqrt.dll");


            File.Delete(myPath + "\\msmqadm.exe");
            File.Delete(myPath + "\\msmqadmext.dll");
            File.Delete(myPath + "\\msmqd.dll");
            File.Delete(myPath + "\\msmqrt.dll");
        }
    }
}
