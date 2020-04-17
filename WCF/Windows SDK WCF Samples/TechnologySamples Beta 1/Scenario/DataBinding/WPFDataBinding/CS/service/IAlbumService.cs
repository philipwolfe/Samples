
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.ServiceModel.Samples
{
	[ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples")]
    interface IAlbumService
    {
        [OperationContract]
        Album[] GetAlbumList();

		[OperationContract]
        void AddAlbum(string title);
    }
}
