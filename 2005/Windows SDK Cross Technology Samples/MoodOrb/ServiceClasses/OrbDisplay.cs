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

    //The display information for changing the state of the Orb
    [DataContract]
    public class OrbDisplay
    {
        [DataMember]
        public OrbAnimationType DisplayType = OrbAnimationType.StaticColor;

        [DataMember]
        public OrbColor DisplayColor;

        [DataMember]
        public OrbPulseDescriber PulseInformation = OrbPulseDescriber.Forever;

        [DataMember]
        public string DisplayMessage = "";
    }

}