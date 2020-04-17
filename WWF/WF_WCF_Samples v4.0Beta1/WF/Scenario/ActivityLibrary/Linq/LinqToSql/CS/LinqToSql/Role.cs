//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.LinqToSqlActivitySample
{
    using System.Data.Linq.Mapping;

    [Table(Name = "Roles")]
    public class Role
    {
        [Column]
        public string Code { get; set; }

        [Column]
        public string Name { get; set; }
    }
}
