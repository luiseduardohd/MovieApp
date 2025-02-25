using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MovieTimeApp.Entities
{
    [DataContract]
    public class Dates
    {
        [DataMember(Name = "maximum")]
        //public string Maximum;
        public DateTimeOffset Maximum;

        [DataMember(Name = "minimum")]
        //public string Minimum;
        public DateTimeOffset Minimum;
    }
}
