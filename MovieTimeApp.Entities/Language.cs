using System;
using System.Runtime.Serialization;


namespace MovieTimeApp.Models
{
    [DataContract]
    public class Language
    {
        [DataMember(Name = "iso_639_1")]
        public string Iso_639_1 { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
