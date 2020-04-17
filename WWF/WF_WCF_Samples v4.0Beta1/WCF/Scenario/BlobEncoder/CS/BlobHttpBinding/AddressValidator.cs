//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.BlobMessageEncoder
{
    using System;
    using System.Configuration;

    class AddressValidator : ConfigurationValidatorBase
    {
        public AddressValidator()
        {
        }

        public override bool CanValidate(Type type)
        {
            return type == typeof(System.Net.IPAddress);
        }

        public override void Validate(object value)
        {
            if (!((Uri)value).IsWellFormedOriginalString())
            {
                throw new ArgumentException("The provided Uri is not well formed");
            }
        }
    }
}
