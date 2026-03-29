using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net_Lab2.Data;
using Net_Lab2.services;

using Microsoft.EntityFrameworkCore;
using Net_Lab2.models;

namespace Net_Lab2.services;

public sealed class MovieService
{
    private readonly MovieDbContext _db;
    private readonly TmdbClient _api;

    public MovieService(MovieDbContext db, TmdbClient api)
    {
        _db = db;
        _api = api;
    }

    public async Task<MovieEntity> GetOrFetchMovieAsync(string title)
    {
        var existing = await _db.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .FirstOrDefaultAsync(m => m.Title.ToLower() == title.ToLower());

        if (existing is not null)
            return existing;

        var search = await _api.SearchMoviesAsync(title)
                     ?? throw new Exception("Brak odpowiedzi z API.");

        var first = search.Results.FirstOrDefault()
                    ?? throw new Exception("Nie znaleziono filmu o takiej nazwie.");

        var details = await _api.GetMovieDetailsAsync(first.Id)
                      ?? throw new Exception("Nie udało się pobrać szczegółów filmu.");

        var movie = await _db.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .FirstOrDefaultAsync(m => m.TmdbId == details.Id);

        if (movie is not null)
            return movie;

        movie = new MovieEntity
        {
            TmdbId = details.Id,
            Title = details.Title,
            Overview = details.Overview,
            ReleaseDate = TryParseDate(details.ReleaseDate),
            VoteAverage = details.VoteAverage,
            PosterPath = details.PosterPath
        };

        foreach (var g in details.Genres)
        {
            var genre = await _db.Genres.FirstOrDefaultAsync(x => x.Name == g.Name);
            if (genre is null)
            {
                genre = new GenreEntity { Name = g.Name };
                _db.Genres.Add(genre);
            }

            movie.MovieGenres.Add(new MovieGenreEntity
            {
                Movie = movie,
                Genre = genre
            });
        }

        _db.Movies.Add(movie);
        await _db.SaveChangesAsync();
        return movie;
    }

    public Task<List<MovieEntity>> GetAllAsync()
        => _db.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .OrderBy(m => m.Title)
            .ToListAsync();

    public Task<List<MovieEntity>> FilterByRatingAsync(double minRating)
        => _db.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Where(m => m.VoteAverage >= minRating)
            .OrderByDescending(m => m.VoteAverage)
            .ToListAsync();

    public Task<List<MovieEntity>> SortByRatingDescAsync()
        => _db.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .OrderByDescending(m => m.VoteAverage)
            .ToListAsync();

    public async Task<MovieEntity> AddManualMovieAsync(
        string title,
        string? overview,
        DateOnly? releaseDate,
        double voteAverage,
        IEnumerable<string> genres)
    {
        var movie = new MovieEntity
        {
            Title = title,
            Overview = overview,
            ReleaseDate = releaseDate,
            VoteAverage = voteAverage
        };

        foreach (var genreName in genres.Select(x => x.Trim()).Where(x => x.Length > 0))
        {
            var genre = await _db.Genres.FirstOrDefaultAsync(x => x.Name == genreName);
            if (genre is null)
            {
                genre = new GenreEntity { Name = genreName };
                _db.Genres.Add(genre);
            }

            movie.MovieGenres.Add(new MovieGenreEntity
            {
                Movie = movie,
                Genre = genre
            });
        }

        _db.Movies.Add(movie);
        await _db.SaveChangesAsync();
        return movie;
    }

    private static DateOnly? TryParseDate(string? value)
        => DateOnly.TryParse(value, out var date) ? date : null;
}
