//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------

namespace Microsoft.Activities.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Serialization;

    [Serializable]
    public class DelegateActivityException : Exception
    {
        public DelegateActivityException() { }
        public DelegateActivityException(string message) : base(message) { }
        public DelegateActivityException(string message, Exception inner) : base(message, inner) { }
        protected DelegateActivityException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }
    }
}
