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
    //A set of options to show the user in the options window
    [DataContract]
    public class OrbOptions {
        [DataMember]
        public string ComponentName;
        
        [DataMember]
        public string ComponentDescription;
        
        [DataMember]
        public Dictionary<String,Object> ComponentProperties;
    }

}