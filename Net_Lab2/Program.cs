using Net_Lab2.Data;
using Net_Lab2.services;
using System.Globalization;


using Microsoft.EntityFrameworkCore;


Console.OutputEncoding = System.Text.Encoding.UTF8;
CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

//var token = Environment.GetEnvironmentVariable("TMDB_TOKEN");
var token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJlZDViNjRjOGY2MDM2Yjc3MDcyMjk4YWZmNzE5ZjQ3MCIsIm5iZiI6MTc2ODkzNDE1MS41MzQwMDAyLCJzdWIiOiI2OTZmY2IwN2JjMGU3YzhlMWI3YWJmMjUiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.sknb7zG3l1rrhhquIvFGhdIIrCI8kcKYa2YD7wu9Qj8";
if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("Ustaw zmienną środowiskową TMDB_TOKEN z Bearer tokenem z TMDb.");
    return;
}

await using var db = new MovieDbContext();
await db.Database.MigrateAsync();

using var api = new TmdbClient(token);
var service = new MovieService(db, api);

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1. Pobierz film z API po nazwie");
    Console.WriteLine("2. Pokaż wszystkie filmy z bazy");
    Console.WriteLine("3. Filtruj po ocenie >= X");
    Console.WriteLine("4. Sortuj po ocenie malejąco");
    Console.WriteLine("5. Dodaj film ręcznie");
    Console.WriteLine("0. Wyjście");
    Console.Write("Wybór: ");

    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Podaj nazwę filmu: ");
                var title = Console.ReadLine() ?? "";
                var movie = await service.GetOrFetchMovieAsync(title);
                Console.WriteLine(movie);
                break;

            case "2":
                var all = await service.GetAllAsync();
                all.ForEach(m => Console.WriteLine(m));
                break;

            case "3":
                Console.Write("Minimalna ocena: ");
                var min = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
                var filtered = await service.FilterByRatingAsync(min);
                filtered.ForEach(m => Console.WriteLine(m));
                break;

            case "4":
                var sorted = await service.SortByRatingDescAsync();
                sorted.ForEach(m => Console.WriteLine(m));
                break;

            case "5":
                Console.Write("Tytuł: ");
                var manualTitle = Console.ReadLine() ?? "";

                Console.Write("Opis: ");
                var overview = Console.ReadLine();

                Console.Write("Data premiery (yyyy-MM-dd, opcjonalnie): ");
                var dateText = Console.ReadLine();
                DateOnly? releaseDate = DateOnly.TryParse(dateText, out var d) ? d : null;

                Console.Write("Ocena: ");
                var rating = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

                Console.Write("Gatunki po przecinku: ");
                var genres = (Console.ReadLine() ?? "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                var added = await service.AddManualMovieAsync(manualTitle, overview, releaseDate, rating, genres);
                Console.WriteLine($"Dodano: {added}");
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Nieznana opcja.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Błąd: {ex.Message}");
    }
}
