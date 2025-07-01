using System.Text.Json.Serialization; // 记得加命名空间

namespace FlixNow.Models
{
    public class MovieDetails
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        // 你可以根据 TMDB API 返回的实际字段继续加其它属性
    }
}