# Net_Lab2

Aplikacja konsolowa **.NET 8** będąca interaktywnym **katalogiem filmów**. Łączy dane z publicznego API [The Movie Database (TMDb)](https://www.themoviedb.org/) z lokalną bazą danych **SQLite** zarządzaną przez **Entity Framework Core 8**.

## Funkcjonalności

| Opcja | Opis |
| ----- | ---- |
| `1` Pobierz film z API po nazwie | Wyszukuje film w TMDb, pobiera szczegóły (ocena, opis, gatunki, data premiery) i zapisuje do lokalnej bazy |
| `2` Pokaż wszystkie filmy z bazy | Wypisuje wszystkie zapisane filmy |
| `3` Filtruj po ocenie ≥ X | Zwraca filmy z oceną co najmniej podanej wartości |
| `4` Sortuj po ocenie malejąco | Wypisuje filmy posortowane od najwyżej ocenianych |
| `5` Dodaj film ręcznie | Dodaje wpis bez pobierania z API (tytuł, opis, data premiery, ocena, gatunki) |
| `0` Wyjście | Kończy działanie programu |

## Technologie

- **.NET 8** — aplikacja konsolowa
- **Entity Framework Core 8** z providerem **SQLite** (`movies.db`)
- **System.Text.Json** — deserializacja odpowiedzi TMDb API
- **HttpClient** z nagłówkiem `Authorization: Bearer` do komunikacji z TMDb

## Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Token Bearer z konta [TMDb API](https://developer.themoviedb.org/docs/getting-started) (v4 Read Access Token)

## Konfiguracja tokenu

Token jest ładowany w następującej kolejności:

1. **Plik `.env`** w katalogu projektu *(zalecane — plik jest ignorowany przez git)*
2. **Zmienna środowiskowa** `TMDB_TOKEN` jako fallback

### Opcja 1 — plik `.env` (zalecana)

Skopiuj plik szablonowy i wpisz swój token:

```bash
cp .env.example .env
```

Zawartość pliku `.env`:

```
TMDB_TOKEN=twój_token_bearer_tutaj
```

> Plik `.env` jest wpisany do `.gitignore` i **nie zostanie zacommitowany**.  
> Nie usuwaj pliku `.env.example` — służy jako szablon dla innych użytkowników.

### Opcja 2 — zmienna środowiskowa

```powershell
# Windows (PowerShell)
$env:TMDB_TOKEN = "twój_token_bearer"
```

```bash
# Linux / macOS
export TMDB_TOKEN="twój_token_bearer"
```

Token Bearer uzyskasz po zalogowaniu na [TMDb API](https://developer.themoviedb.org/docs/getting-started) (v4 Read Access Token).

## Uruchomienie

Z katalogu projektu:

```bash
dotnet run
```

Przy pierwszym uruchomieniu EF Core automatycznie tworzy plik `movies.db` i stosuje migracje.

## Struktura projektu

| Ścieżka | Rola |
| ------- | ---- |
| `Program.cs` | Punkt wejścia: inicjalizacja bazy, pętla interaktywnego menu |
| `services/TmdbClient.cs` | Klient HTTP do TMDb API — wyszukiwanie i pobieranie szczegółów filmów |
| `services/MovieService.cs` | Warstwa serwisowa — orkiestracja EF Core i API: pobieranie, filtrowanie, sortowanie, ręczne dodawanie |
| `data/MovieDbContext.cs` | Kontekst EF Core; konfiguracja SQLite i relacji między encjami |
| `data/MovieEntity.cs` | Encje bazy danych: `MovieEntity`, `GenreEntity`, `MovieGenreEntity` (relacja wiele–do–wielu) |
| `models/TmdbDtos.cs` | Rekordy DTO do deserializacji odpowiedzi JSON z TMDb API |
| `Migrations/` | Migracje EF Core (wygenerowane automatycznie) |

## Kompilacja

```bash
dotnet build
```

## Migracje bazy danych

Aby dodać nową migrację (po zmianie modelu):

```bash
dotnet ef migrations add NazwaMigracji
dotnet ef database update
```

## Licencja

W repozytorium nie określono licencji; zasady użytkowania wynikają z wymagań zajęć lub organizacji.
