using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Net_Lab2.Data;

public sealed class MovieEntity
{
    public int Id { get; set; }
    public int TmdbId { get; set; }
    public string Title { get; set; } = "";
    public string? Overview { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public double VoteAverage { get; set; }
    public string? PosterPath { get; set; }

    public List<MovieGenreEntity> MovieGenres { get; set; } = [];

    [NotMapped]
    public string GenresText => string.Join(", ", MovieGenres.Select(x => x.Genre.Name));

    public override string ToString()
        => $"{Title} | {ReleaseDate:yyyy-MM-dd} | ocena: {VoteAverage:0.0} | {GenresText}";
}

public sealed class GenreEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public List<MovieGenreEntity> MovieGenres { get; set; } = [];
}

public sealed class MovieGenreEntity
{
    public int MovieEntityId { get; set; }
    public MovieEntity Movie { get; set; } = null!;

    public int GenreEntityId { get; set; }
    public GenreEntity Genre { get; set; } = null!;
}
