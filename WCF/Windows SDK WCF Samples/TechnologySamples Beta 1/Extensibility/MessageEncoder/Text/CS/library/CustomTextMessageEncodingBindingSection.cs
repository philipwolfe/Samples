
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.Text;
using System.ServiceModel;
using System.Configuration;
using System.ComponentModel;
using System.ServiceModel.Configuration;

namespace Microsoft.ServiceModel.Samples
{
    public class CustomTextMessageEncodingElement : BindingElementExtensionElement
    {
        public override Type BindingElementType
        {
            get 
            { 
                return typeof(CustomTextMessageBindingElement); 
            }
        }

        protected override BindingElement CreateBindingElement()
        {
            return new CustomTextMessageBindingElement(
                this.Encoding, this.MediaType,
                ConvertToMessageVersion(this.MessageVersionString));
        }

        [ConfigurationProperty(ConfigConst.Name_Encoding,
            DefaultValue = ConfigConst.DefaultValue_Encoding)]
        public string Encoding
        {
            get
            {
                return (string)base[ConfigConst.Name_Encoding];
            }

            set
            {
                base[ConfigConst.Name_Encoding] = value;
            }
        }

        [ConfigurationProperty(ConfigConst.Name_MediaType,
           DefaultValue = ConfigConst.DefaultValue_MediaType)]
        public string MediaType
        {
            get
            {
                return (string)base[ConfigConst.Name_MediaType];
            }

            set
            {
                base[ConfigConst.Name_MediaType] = value;
            }
        }

        [ConfigurationProperty(ConfigConst.Name_MessageVersion, 
            DefaultValue = ConfigConst.DefaultValue_MessageVersion)]
        public string MessageVersionString
        {
            get
            {
                return (string)base[ConfigConst.Name_MessageVersion];
            }

            set
            {
                ValidateMessageVersionString(value);
                base[ConfigConst.Name_MessageVersion] = value;
            }
        }

        private void ValidateMessageVersionString(string msgVersion)
        {
            if ((msgVersion != ConfigConst.Value_Soap11Addressing10) ||
                 (msgVersion != ConfigConst.Value_Soap12Addressing10))
                throw new ArgumentOutOfRangeException("value");
        }

        private MessageVersion ConvertToMessageVersion(string msgVersionStr)
        {
            if (msgVersionStr == ConfigConst.Value_Soap11Addressing10)
                return MessageVersion.Soap11WSAddressing10;
            else
                if (msgVersionStr == ConfigConst.Value_Soap12Addressing10)
                    return MessageVersion.Soap12WSAddressing10;
                else
                    throw new ArgumentOutOfRangeException("msgVersionStr");

        }
    }

    internal class ConfigConst
    {
        internal const string SectionName = "customTextMessageEncoding";
        internal const string Name_Encoding = "encoding";
        internal const string Name_MediaType = "mediaType";
        internal const string Name_MessageVersion = "messageVersion";
        internal const string Value_Soap11Addressing10 = "Soap11WSAddressing10";
        internal const string Value_Soap12Addressing10 = "Soap12WSAddressing10";
        internal const string DefaultValue_MessageVersion = Value_Soap11Addressing10;
        internal const string DefaultValue_Encoding = "utf-8";
        internal const string DefaultValue_MediaType = "text/xml";
    }

}
