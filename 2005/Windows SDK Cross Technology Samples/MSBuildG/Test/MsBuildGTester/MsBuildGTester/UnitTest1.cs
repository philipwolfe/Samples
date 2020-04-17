using System;
using Microsoft.VisualStudio.QualityTools.UnitTesting.Framework;
using Microsoft.Samples.MSBuildG;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MsBuildGTester
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        private List<string> m_ProjectList = null;

        private TestContext m_testContext;
        public TestContext TestContext
        {
            get { return m_testContext; }
            set { m_testContext = value; }
        }

        public UnitTest1()
        {

            //Initialize the projects list

            m_ProjectList = new List<string>();

            //C#
            m_ProjectList.Add("AvalonApplication1");
            m_ProjectList.Add("ConsoleApplication1");
            m_ProjectList.Add("WindowsApplication1");
            m_ProjectList.Add("WindowsControlLibrary1");

            //Visual Basic
            m_ProjectList.Add("AvalonApplication2");
            m_ProjectList.Add("ConsoleApplication2");
            m_ProjectList.Add("WindowsApplication2");
            m_ProjectList.Add("WindowsControlLibrary2");
        }

        /// <summary>
        /// Initialize() is called once during test execution before
        /// test methods in this test class are executed.
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            SettingsSystem.Storage.BinPath = Microsoft.Samples.MSBuildG.SettingsSystem.FindFrameworkPath();
        }
        /// <summary>
        /// Cleanup() is called once during test execution after
        /// test methods in this class have executed unless the
        /// corresponding Initialize() call threw an exception.
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
        }

        /// <summary>
        /// We are testing to see if the wizard's construction system works. This is done by opening directories
        /// with the associated project name and running the system on those directories. The output (i.e. project file)
        /// is then compared to the manually created one, named &lt;projectname&gt;.real. If the contents match, the test is a success.
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            //Test each project here

            string projectsPath = @"";   

            foreach (string projectName in m_ProjectList)
            {
                //Create the project with default criteria

                BuildProject m_Project = new BuildProject();
                m_Project.ProjectName = projectName;
                m_Project.ProjectNotes = "Notes Go Here";

                //send in the Files list (retrieved from the directory, use ALL files)

                List<string> fileNames = new List<string>();

                List<string> Extensions = new List<string>();

                Extensions.Add("cs");
                Extensions.Add("vb");
                Extensions.Add("xaml");
                Extensions.Add("xaml.cs");
                Extensions.Add("xaml.vb");
                Extensions.Add("ico"); //To test resources

                //We only want to test default file types, as if the user selected only those sources files he/she would need

                foreach (string filePath in System.IO.Directory.GetFiles(projectName))
                {
                    foreach (string ext in Extensions)
                    {
                        if (System.IO.Path.GetExtension(filePath) == "." + ext)
                        {

                            fileNames.Add(filePath);
                        }
                    }

                }

                //Create the template

                m_Project.CreateTemplate(fileNames.ToArray());

                //Create and Save the file

                m_Project.Create();

                //compare to the .real file for testing

                TextReader realFile = new StreamReader(projectName + @"\" + projectName + ".real");

                string realContents = realFile.ReadToEnd();

                realFile.Close();

                TextReader generatedFile = new StreamReader(m_Project.Filename);

                string generatedContents = generatedFile.ReadToEnd();

                generatedFile.Close();

                Assert.AreEqual<string>(realContents, generatedContents, "Error With Project: " + projectName);

                m_Project = null;
            }
        }
    }
}

