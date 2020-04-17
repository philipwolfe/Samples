//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace RtcActivityLibrary.Services
{
    public class RTCConstants
    {
        public const int RTCCS_FORCE_PROFILE = 0x00000001;
        public const int RTCCS_FAIL_ON_REDIRECT = 0x00000002;
        public const int RTCTR_UDP = 0x00000001;
        public const int RTCTR_TCP = 0x00000002;
        public const int RTCTR_TLS = 0x00000004;
        public const int RTCAU_ALL = 0x0001009F;
        public const int RTCAU_BASIC = 0x00000001;
        public const int RTCAU_DIGEST = 0x00000002;
        public const int RTCAU_NTLM = 0x00000004;
        public const int RTCAU_KERBEROS = 0x00000008;
        public const int RTCAU_USE_LOGON_CRED = 0x00010000;
        public const int RTCRF_REGISTER_PRESENCE = 0x00000004;
        public const int RTCRF_REGISTER_NOTIFY = 0x00000008;
        public const int RTCRF_REGISTER_ALL = 0x0000000F;
        public const int RTCRMF_BUDDY_ROAMING = 0x00000001;
        public const int RTCRMF_WATCHER_ROAMING = 0x00000002;
        public const int RTCRMF_PRESENCE_ROAMING = 0x00000004;
        public const int RTCRMF_PROFILE_ROAMING = 0x00000008;
        public const int RTCRMF_ALL_ROAMING = 0x0000000F;
        public const int RTCEF_CLIENT = 0x00000001;
        public const int RTCEF_REGISTRATION_STATE_CHANGE = 0x00000002;
        public const int RTCEF_SESSION_STATE_CHANGE = 0x00000004;
        public const int RTCEF_SESSION_OPERATION_COMPLETE = 0x00000008;
        public const int RTCEF_PARTICIPANT_STATE_CHANGE = 0x00000010;
        public const int RTCEF_MESSAGING = 0x00000080;
        public const int RTCEF_BUDDY = 0x00000100;
        public const int RTCEF_WATCHER = 0x00000200;
        public const int RTCEF_PROFILE = 0x00000400;
        public const int RTCEF_INFO = 0x00001000;
        public const int RTCEF_GROUP = 0x00002000;
        public const int RTCEF_MEDIA_REQUEST = 0x00004000;
        public const int RTCEF_ROAMING = 0x00010000;
        public const int RTCEF_PRESENCE_PROPERTY = 0x00020000;
        public const int RTCEF_BUDDY2 = 0x00040000;
        public const int RTCEF_WATCHER2 = 0x00080000;
        public const int RTCEF_PRESENCE_DATA = 0x00800000;
        public const int RTCEF_PRESENCE_STATUS = 0x01000000;
        public const int RTCEF_ALL = 0x01FFFFFF;
        public const int RTCIF_ENABLE_SERVER_CLASS = 0x00000010;
        public const int RTCIF_DISABLE_STRICT_DNS = 0x00000020;
        public const int RTC_E_STATUS_CLIENT_UNAUTHORIZED = -2131820143; //0x80EF0191;
        public const int RTC_E_STATUS_CLIENT_PROXY_AUTHENTICATION_REQUIRED = -2131820137; //0x80EF0197;
        public const int RTC_E_STATUS_CLIENT_FORBIDDEN = -2131820141; //0x80EF0193
        public const int RTC_E_STATUS_CLIENT_NOT_FOUND = -2131820140; //0x80EF0194

    }
}
