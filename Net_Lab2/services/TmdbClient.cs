using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Net_Lab2.models;


namespace Net_Lab2.services;

public sealed class TmdbClient : IDisposable
{
    private readonly HttpClient _http;

    public TmdbClient(string bearerToken)
    {
        _http = new HttpClient
        {
            BaseAddress = new Uri("https://api.themoviedb.org/3/")
        };

        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", bearerToken);
    }

    public async Task<TmdbSearchResponse?> SearchMoviesAsync(string query)
    {
        var url = $"search/movie?query={Uri.EscapeDataString(query)}&include_adult=false&language=pl-PL";
        var json = await _http.GetStringAsync(url);
        return JsonSerializer.Deserialize<TmdbSearchResponse>(json);
    }

    public async Task<TmdbMovieDetails?> GetMovieDetailsAsync(int movieId)
    {
        var json = await _http.GetStringAsync($"movie/{movieId}?language=pl-PL");
        return JsonSerializer.Deserialize<TmdbMovieDetails>(json);
    }

    public void Dispose() => _http.Dispose();
}
