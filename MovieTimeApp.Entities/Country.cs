using System;
using System.Runtime.Serialization;


namespace MovieTimeApp.Models
{
    [DataContract]
    public class Country
    {
        [DataMember(Name = "iso_3166_1")]
        public string Iso_3166_1 { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
