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
using System.ServiceModel;
using System.Windows;
using System.Windows.Media;
using System.Runtime.Serialization;
using System.Collections;
using System.Xml;
using System.IO;

/// <summary>
/// Project which contains the interfaces, classes and methods for remote service orblings
/// </summary>

namespace Microsoft.Samples.MoodOrb
{

     //A class describing how to pulse the Orb, if the DisplayType of the OrbDisplay is OrbAnimationType.Pulse
    [DataContract]
    public class OrbPulseDescriber
    {
        [DataMember]
        private int m_PulseCount;
        
        [DataMember]
        private OrbColor m_PulseColor;

        [DataMember]
        private bool m_IsForever = false;

        //Create a default Pulse with a white color
        public OrbPulseDescriber(int count)
            : this(count, new OrbColor(Colors.White))
        {            
        }

        public OrbPulseDescriber(int count, OrbColor pulseColor)
        {
            m_PulseCount = count;
            m_PulseColor = pulseColor;
        }

        public static OrbPulseDescriber Forever
        {
            get
            {
                OrbPulseDescriber pCounter = new OrbPulseDescriber(0);
                pCounter.m_IsForever = true;

                return (pCounter);
            }
        }

        public bool IsForever
        {
            get
            {
                return (m_IsForever);
            }
        }

        public OrbColor Color
        {
            get
            {
                return (m_PulseColor);
            }
        }

        public int Count
        {
            get
            {
                if (m_IsForever)
                {
                    throw new InvalidOperationException("A Non-terminating PulseCounter cannot have a finite count.");
                }
                else
                {
                    return (m_PulseCount);
                }
            }
        }
    }


}