//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------
namespace Microsoft.Samples.LinqToSqlActivitySample
{
    using System.Data.Linq.Mapping;

    [Table(Name = "Employees")]
    public class Employee
    {
        [Column]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string eMail { get; set; }

        [Column]
        public string Role { get; set; }

        [Column]
        public string Location { get; set; }


        public override string ToString()
        {
            return string.Format("{0} {1} ({2} at {3})", Id, Name, Role, Location);
        }
    }
}
