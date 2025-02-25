using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MovieTimeApp.Models
{
    [DataContract]
    public class Movie
    {
        [DataMember(Name = "Id")]
        //[PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "adult")]
        public bool IsAdult { get; set; }

        [DataMember(Name = "backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name = "budget")]
        public decimal Budget { get; set; }

        [DataMember(Name = "genre_ids")]
        public IList<long> GenreIds { get; set; }

        [DataMember(Name = "homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "imdb_id")]
        public string ImdbId { get; set; }

        [DataMember(Name = "original_language")]
        public string OriginalLanguage { get; set; }

        [DataMember(Name = "original_title")]
        public string OriginalTitle { get; set; }

        [DataMember(Name = "overview")]
        public string Overview { get; set; }

        [DataMember(Name = "popularity")]
        public double Popularity { get; set; }

        [DataMember(Name = "poster_path")]
        public string PosterPath { get; set; }

        //private string Poster_Path { get { return this.PosterPath; } set { this.PosterPath = value; } }

        [DataMember(Name = "production_countries")]
        public IList<Country> ProductionCountries { get; set; }

        [DataMember(Name = "release_date")]
        public DateTime ReleaseDate { get; set; }

        [DataMember(Name = "revenue")]
        public decimal Revenue { get; set; }

        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }

        [DataMember(Name = "spoken_languages")]
        public IList<Language> SpokenLanguages { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }

        [DataMember(Name = "video")]
        public bool HasVideo { get; set; }

        [DataMember(Name = "vote_average")]
        public double VoteAverage { get; set; }

        [DataMember(Name = "vote_count")]
        public int VoteCount { get; set; }
    }
}
