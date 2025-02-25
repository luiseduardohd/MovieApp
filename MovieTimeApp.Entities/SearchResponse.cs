using MovieTimeApp.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MovieTimeApp.Models
{
    [DataContract]
    public class SearchResponse<T>
    {
        [DataMember(Name = "results")]
        public IList<T> Results { get; set; }

        [DataMember(Name = "page")]
        //public int PageNumber { get; private set; }
        public int Page { get;  set; }

        [DataMember(Name = "total_pages")]
        public int TotalPages { get; set; }

        [DataMember(Name = "total_results")]
        public int TotalResults { get; set; }

        [DataMember(Name = "dates")]
        public Dates Dates;
    }
}
