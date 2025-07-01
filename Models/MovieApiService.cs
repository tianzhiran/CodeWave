using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace FlixNow.Models
{
    public class MovieApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;

        // Constructor: injects HttpClient factory and configuration
        public MovieApiService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = config["TMDB:ApiKey"]; // Safely read API key from appsettings.json
        }

        // Get details of a movie from TMDB API (multi-language support)
        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId, string languageCode)
        {
            var client = _httpClientFactory.CreateClient("TMDB");
            string requestUrl = $"/movie/{movieId}?api_key={_apiKey}&language={languageCode}";
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            // If TMDB returns 404, return null
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            string json = await response.Content.ReadAsStringAsync();
            MovieDetails details = JsonSerializer.Deserialize<MovieDetails>(json);
            return details;
        }

    }
}