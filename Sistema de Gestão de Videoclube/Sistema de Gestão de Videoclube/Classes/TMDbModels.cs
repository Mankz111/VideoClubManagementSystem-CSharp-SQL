using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Sistema_de_Gestão_de_Videoclube.Classes
{
    
    public class TmdbMovieSearchResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("genre_ids")]
        public List<int> GenreIds { get; set; } 

    }

    public class TmdbSearchResponse
    {
        [JsonPropertyName("results")]
        public List<TmdbMovieSearchResult> Results { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }


    public class TmdbMovieDetails
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("runtime")]
        public int? Runtime { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("genres")]
        public List<TmdbGenre> Genres { get; set; }

        [JsonPropertyName("credits")]
        public TmdbCredits Credits { get; set; }
    }

    public class TmdbGenre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class TmdbCredits
    {
        [JsonPropertyName("crew")]
        public List<TmdbCrewMember> Crew { get; set; }
    }

    public class TmdbCrewMember
    {
        [JsonPropertyName("job")]
        public string Job { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

