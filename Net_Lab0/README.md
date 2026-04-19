# Net_Lab0

Prosta aplikacja konsolowa **.NET 8** demonstrująca klasyczny algorytm **FizzBuzz**.

## Działanie

Program prosi użytkownika o podanie liczby całkowitej `n`, a następnie iteruje po liczbach od **1 do `n - 1`** (wyłącznie) i dla każdej wypisuje:

| Warunek | Wypisywany tekst |
| ------- | ---------------- |
| Podzielna przez 3 i przez 5 | `FizzBuzz` |
| Podzielna przez 3 | `Fizz` |
| Podzielna przez 5 | `Buzz` |
| Pozostałe | Sama liczba |

## Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Uruchomienie

Z katalogu projektu:

```bash
dotnet run
```

Program poprosi o:

| Dane wejściowe | Znaczenie |
| -------------- | --------- |
| Liczba (`n`) | Górna granica pętli (wyłącznie — iteracja od 1 do `n - 1`) |

## Struktura projektu

| Plik | Rola |
| ---- | ---- |
| `Program.cs` | Punkt wejścia oraz klasa `FizzBuzz` z logiką wypisywania |
| `Lab0.csproj` | Definicja projektu .NET 8 |
| `Lab0.sln` | Plik rozwiązania Visual Studio |

