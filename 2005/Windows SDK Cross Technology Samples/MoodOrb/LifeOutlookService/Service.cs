// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.ServiceModel;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Media;
using System.Timers;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Collections;


namespace Microsoft.Samples.MoodOrb
{
   
    public class LifeOutlookService : IOrbling
    {
        private OutlookScore m_Scorer;

        public static void Main()
        {
            try
            {
                ServiceHost serviceHost;

                // Get base address from app settings in configuration.
                Uri baseAddress = new Uri("http://localhost:8000/orbservices/LifeOutlookService"); //System.Configuration.ConfigurationManager.AppSettings["baseAddress"]

                // Create a ServiceHost<T> for the LifeOutlookService type and provide the base address.
                serviceHost = new ServiceHost(typeof(LifeOutlookService), baseAddress);

                // Open the ServiceHost to create listeners and start listening for messages.
                serviceHost.Open();

                Console.WriteLine("LifeOutlook Service Orbling Ready. Enter \"Shutdown\" to shutdown.");

                Console.Write(">");

                //Wait for the user to shutdown
                while (Console.ReadLine().ToLower() != "shutdown")
                {
                    Console.Write(">");
                }

                serviceHost.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
        }

        public LifeOutlookService()
        {
            m_Scorer = new OutlookScore();
        }

        public OrbDisplay GetInformation(OrbOptionValues Options)
        {
            //Deserialize the options, as they are in a string format since this is a remote service
            Options.ComponentProperties = OrbOption.DeserializeOptions(Options.ComponentProperties);

            OrbDisplay displayValue = new OrbDisplay();

            //Set the flags necessary in the Scorer
            m_Scorer.BadEventFlags = (Options.ComponentProperties["Bad Event Keywords"] as OrbListOption).GetList();
            m_Scorer.GoodEventFlags = (Options.ComponentProperties["Good Event Keywords"] as OrbListOption).GetList();
            m_Scorer.BadMailFlags = (Options.ComponentProperties["Bad Mail Keywords"] as OrbListOption).GetList();
            m_Scorer.GoodMailFlags = (Options.ComponentProperties["Good Mail Keywords"] as OrbListOption).GetList();

            m_Scorer.RequestedFreeHours = (Options.ComponentProperties["Minimum Free Hours"] as OrbHoursOption).Value;

            int overallScore;

            try
            {
                //Retrieve the Information needed to calculate a score
                m_Scorer.RetrieveInformation();

                //Get the Outlook Score
                overallScore = m_Scorer.GetScore();
            }
            catch (Exception ex)
            {
                overallScore = -1;
            }


            if (overallScore == -1)
            {
                //An error has occurred

                displayValue.DisplayColor = new OrbColor(Colors.Red);
                displayValue.DisplayType = OrbAnimationType.Pulse;
                displayValue.DisplayMessage = "An error has occurred with Outlook";
                displayValue.PulseInformation = OrbPulseDescriber.Forever;

            }
            else
            {
                //set the color
                displayValue.DisplayColor = new OrbColor(Colors.Red);

                if (overallScore > 13)
                {
                    displayValue.DisplayColor = new OrbColor(Colors.Yellow);
                }
                if (overallScore > 27)
                {
                    displayValue.DisplayColor = new OrbColor(Colors.Green);
                }
                if (overallScore > 40)
                {
                    displayValue.DisplayColor = new OrbColor(Colors.Blue);
                }

                //set the pulsing for unread mail
                if (m_Scorer.UnreadMail)
                {
                    displayValue.DisplayType = OrbAnimationType.Pulse;

                    OrbColor pulseColor = new OrbColor(Colors.White);

                    if (m_Scorer.UnreadHighImportance)
                    {
                        pulseColor = new OrbColor(Colors.Red);
                    }

                    displayValue.PulseInformation = new OrbPulseDescriber(3, pulseColor);
                }
            }

            return (displayValue);
        }

        public OrbOptions GetOptions()
        {
   	    //Create the options to be returned
            OrbOptions optionsList = new OrbOptions();
            optionsList.ComponentName = "LifeOutlook Orbling";
            optionsList.ComponentDescription = "Describes your life for today, based on Outlook";
            optionsList.ComponentProperties = new Dictionary<String,Object>();

            optionsList.ComponentProperties.Add("Bad Event Keywords", new OrbListOption());
            optionsList.ComponentProperties.Add("Good Event Keywords", new OrbListOption());
            optionsList.ComponentProperties.Add("Bad Mail Keywords", new OrbListOption());
            optionsList.ComponentProperties.Add("Good Mail Keywords", new OrbListOption());

            optionsList.ComponentProperties.Add("Minimum Free Hours", new OrbHoursOption(12.0));

            //serialize the options before transit
            return (SerializeOptions(optionsList));
        }

        private static OrbOptions SerializeOptions(OrbOptions preserialized)
        {
            OrbOptions serialized = new OrbOptions();
            serialized.ComponentName = preserialized.ComponentName;
            serialized.ComponentDescription = preserialized.ComponentDescription;

            serialized.ComponentProperties = OrbOption.SerializeOptions(preserialized.ComponentProperties);

            return (serialized);
        }


        public TimeSpan GetTime()
        {
            return (TimeSpan.FromMinutes(2));
        }
    }
}
