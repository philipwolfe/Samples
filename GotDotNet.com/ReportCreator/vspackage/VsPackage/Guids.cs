/***************************************************************************
         Copyright (c) Microsoft CorporationAll rights reserved.             
    This code sample is provided "AS IS" without warranty of any kind
    it is not recommended for use in a production environment.
***************************************************************************/

// Guids.cs
// MUST match guid.h (for the satellite DLL)
using System;

namespace Vsip.VsPackage
{
    class GuidList
    {
        public static readonly Guid guidVsPackagePkg =        new Guid("{9aa75229-9d91-4841-8a43-45f03018a250}");
        public static readonly Guid guidVsPackageCmdSet =        new Guid("{2713e020-c2b7-4634-a436-5e8d4fbb631f}");


		public static readonly Guid guidEditorFactory = 		new Guid("{f4b1224e-6c23-43e3-a978-fbe849feea9e}");

    };
}