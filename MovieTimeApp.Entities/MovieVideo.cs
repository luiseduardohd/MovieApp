using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MovieTimeApp.Models
{
    [DataContract]
    public class MovieVideo
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "results")]
        public IList<MovieVideoItem> Videos { get; set; }
    }
}
