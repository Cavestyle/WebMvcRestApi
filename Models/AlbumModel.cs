using System;
using System.Collections.Generic;

namespace OpendorseWebMvc.Models
{
    public class AlbumModel
    {
        public int ResultCount { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Result
    {
        public string ArtistName { get; set; }
        public string CollectionName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PrimaryGenreName { get; set; }
    }
}