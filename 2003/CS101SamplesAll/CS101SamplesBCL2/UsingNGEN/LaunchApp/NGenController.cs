using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace LaunchApp
{
    /// <summary>
    /// Controls the execution of the NGEN utility.
    /// </summary>
    class NGenController
    {
        /// <summary>
        /// Private constructor to disallow instance creation.
        /// </summary>
        private NGenController() { }

        private static StringCollection outputLines = new StringCollection();

        /// <summary>
        /// Runs the NGen .NET Framework utility.
        /// </summary>
        /// <param name="command">A <see cref="LaunchApp.NGenCommand"/> for the NGen utility.</param>
        /// <param name="arguments">A <see cref="System.String"/> representing additional command-line arguments.</param>
        /// <returns>A <see cref="System.Collections.Specialized.StringCollection"/> representing the captured output from NGen with additional comments added at the end.</returns>
        public static StringCollection Run(NGenCommand command, string arguments)
        {
            outputLines.Clear();

            if (command == NGenCommand.Undefined)
            {
                outputLines.Add("Please provide a valid NGenCommand");
                return outputLines;
            }

            Process ngenProcess = new Process();
            ngenProcess.StartInfo.FileName = @"c:\windows\microsoft.net\framework\v2.0.50727\ngen";
            if (arguments == null || arguments.Trim().Length == 0)
                ngenProcess.StartInfo.Arguments = command.ToString();
            else
                ngenProcess.StartInfo.Arguments = String.Format("{0} {1}", command.ToString(), arguments);
            ngenProcess.StartInfo.RedirectStandardOutput = true;
            ngenProcess.StartInfo.UseShellExecute = false;
            ngenProcess.StartInfo.CreateNoWindow = true;
            ngenProcess.OutputDataReceived += new DataReceivedEventHandler(ngenProcess_OutputDataReceived);

            if (ngenProcess.Start())
            {
                // Read the entire output stream before waiting for the process to exit.
                ngenProcess.BeginOutputReadLine();

                ngenProcess.WaitForExit();
            }

            return outputLines;
        }

        /// <summary>
        /// Event handler for console standard output.
        /// </summary>
        /// <param name="sendingProcess"></param>
        /// <param name="outLine"></param>
        private static void ngenProcess_OutputDataReceived(object sendingProcess,
        DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                // Add the text to the outputLines StringCollection.
                outputLines.Add(outLine.Data);
            }
        }


    }
}
