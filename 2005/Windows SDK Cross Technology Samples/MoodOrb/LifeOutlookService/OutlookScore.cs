// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using Outlook=Microsoft.Office.Interop.Outlook;
using System.Windows;

namespace Microsoft.Samples.MoodOrb
{
    //Class which downloads information from Outlook and determines a "score" 
    //from that information, which is translated into a color for the Orb
    public class OutlookScore : IDisposable
    {
        private Outlook.NameSpace m_Namespace;
        private double m_FreeHours;
        private int m_EventCount;
        private int m_GoodEventHits;
        private int m_BadEventHits;

        private int m_MailCount;
        private int m_GoodMailHits;
        private int m_BadMailHits;

        private int m_UnreadHighImportance;

        private int m_Tasks;
        private int m_DueTasks;
        private int m_OverDueTasks;

        //p_ is used for user properties
        private double p_RequestedFreeHours = 8;
        private List<String> p_GoodEventFlags;
        private List<String> p_BadEventFlags;
        private List<String> p_GoodMailFlags;
        private List<String> p_BadMailFlags;

        private Outlook.Application m_OutlookApp;

        public OutlookScore()
        {
            //Create new reference to outlook
            m_OutlookApp = new Outlook.Application();

            //Save a reference to the Namespace we will be using
            m_Namespace = m_OutlookApp.GetNamespace("MAPI");

        }
	
	//Retrieve the necessary information for scoring from the Outlook connection
        public void RetrieveInformation()
        {
            //Calendars
            m_FreeHours = 0;

            m_EventCount = 0;
            m_GoodEventHits = 0;
            m_BadEventHits = 0;

            Outlook.MAPIFolder calFolder = m_Namespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);

            //Find those events which occur today (i.e. their start>=this morning and end<=this evening)
            foreach (object item in calFolder.Items.Restrict("[Start] >= '" + DateTime.Now.ToString("ddddd") + " 12:00 AM' AND [Start] <= '" + DateTime.Now.ToString("ddddd") + " 11:59 PM'"))
            {
                Outlook.AppointmentItem aItem = item as Outlook.AppointmentItem;

                if (aItem != null)
                {
                    m_EventCount++;

                    foreach (string keyword in p_GoodEventFlags)
                    {
                        if (aItem.Subject.ToLower().Contains(keyword.ToLower()))
                        {
                            m_GoodEventHits++;
                        }
                    }
                    foreach (string keyword in p_BadEventFlags)
                    {
                        if (aItem.Subject.ToLower().Contains(keyword.ToLower()))
                        {
                            m_BadEventHits++;
                        }
                    }

                    //Is this an All Day Event?
                    if (aItem.AllDayEvent)
                    {
                        m_FreeHours += 24;
                    }
                    else
                    {
                        TimeSpan difference = aItem.End - aItem.Start;

                        m_FreeHours += difference.TotalHours;
                    }
                }
            }

            //Tasks
            m_Tasks=0;
            m_DueTasks=0;
            m_OverDueTasks=0;

            foreach (object item in m_Namespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks).Items)
            {
                Outlook.TaskItem tItem = item as Outlook.TaskItem;

                if (tItem != null)
                {
                    m_Tasks++;

                    if (tItem.DueDate.Year == DateTime.Now.Year)
                    {
                        if (tItem.DueDate.DayOfYear == DateTime.Now.DayOfYear)
                        {
                            m_DueTasks++;
                        }
                    }

                    if (tItem.DueDate < DateTime.Now)
                    {
                        m_OverDueTasks++;
                    }
                }
            }

            //E-mail
            m_MailCount = 0;
            m_GoodMailHits = 0;
            m_BadMailHits = 0;

            m_UnreadHighImportance = 0;

            //Find the unread e-mail
            foreach (object item in m_Namespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox).Items.Restrict("[UnRead]=True"))
            {
                Outlook.MailItem mItem =  item as Outlook.MailItem;

                if (mItem!=null)
                {
                    if (mItem.UnRead)
                    {
                        m_MailCount++;

                        if (mItem.Importance == Outlook.OlImportance.olImportanceHigh)
                        {
                            m_UnreadHighImportance++;
                        }

                       foreach (string keyword in p_GoodMailFlags)
                        {
                            if (mItem.Subject.ToLower().Contains(keyword.ToLower()))
                            {
                                m_GoodMailHits++;
                            }
                        }
                        foreach (string keyword in p_BadMailFlags)
                        {
                            if (mItem.Subject.ToLower().Contains(keyword.ToLower()))
                            {
                                m_BadMailHits++;
                            }
                        }
                    }


                }
            }
        }


	//Calculates and returns the score based on the information collected by RetrieveInformation
        public int GetScore()
        {
            int baseScore = 50;

            //Free Time
            if ((24-m_FreeHours) < p_RequestedFreeHours)
            {
                baseScore -= 5;
            }

            if (m_FreeHours >= 24)
            {
                baseScore -= 10;
            }

	    //Define score weights here
	    int s_events = -1;
	    int s_events_good = 4;
	    int s_events_bad = -1;

	    int s_tasks = -1;
	    int s_tasks_due = -2;
	    int s_tasks_overdue = -5;
	
	    int s_mail = -2;
	    int s_mail_high = -2;
	    int s_mail_good = 4;
	    int s_mail_bad = -1;

            //Events (-1), good (4) and bad (-1)            
            baseScore += (s_events) * m_EventCount + (s_events_good) * m_GoodEventHits + (s_events_bad) * m_BadEventHits;

            //Tasks (-1), due (-2), overdue (-5)
            baseScore += (s_tasks) * m_Tasks + (s_tasks_due) * m_DueTasks + (s_tasks_overdue) * m_OverDueTasks;

            //Mail (-2), good (4) and bad (-1) and high (-2)
            baseScore += (s_mail) * m_MailCount + (s_mail_high) * m_UnreadHighImportance 
			 + m_GoodMailHits * (s_mail_good) + m_BadMailHits * (s_mail_bad);

            return(baseScore);
        }

        //Public properties to determine whether to Pulse the Orb
        public bool UnreadHighImportance
        {
            get { return (m_UnreadHighImportance>0); }
        }

        public bool UnreadMail
        {
            get
            {
                return (m_MailCount>0);
            }
        }

        //Personal Preferences
        public double RequestedFreeHours
        {
            get { return p_RequestedFreeHours; }
            set { p_RequestedFreeHours = value; }
        }

        public List<String> GoodEventFlags
        {
            get { return p_GoodEventFlags; }
            set { p_GoodEventFlags = value; }
        }
        public List<String> BadEventFlags
        {
            get { return p_BadEventFlags; }
            set { p_BadEventFlags = value; }
        }
        public List<String> GoodMailFlags
        {
            get { return p_GoodMailFlags; }
            set { p_GoodMailFlags = value; }
        }
        public List<String> BadMailFlags
        {
            get { return p_BadMailFlags; }
            set { p_BadMailFlags = value; }
        }

     	 private bool m_Disposed = false;

            ~OutlookScore()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(true);
            }

        protected virtual void Dispose(bool isDisposing)
        {
            if (m_Disposed)
            {
                return;
            }

            if (isDisposing)
            {
                //Free managed resources here   
        	    m_Namespace = null;
	            m_OutlookApp = null;
            }

            m_Disposed = true;

            //Free unmanaged resources here
        }

    }
}
