# Net_Lab1

Projekt **.NET 8** do ćwiczenia z **dyskretnym problemem plecakowym** (plecak 0-1). Rozwiązanie składa się z trzech podprojektów: aplikacji konsolowej, interfejsu graficznego **WinForms** oraz testów jednostkowych **MSTest**.

## Działanie

1. **Generowanie przedmiotów** — Dla podanej liczby `n` każdy przedmiot otrzymuje losową **wartość** i **masę** (wagę) z zakresu **1–10** (włącznie), z użyciem **ziarna** (seed) generatora, aby wyniki były odtwarzalne.
2. **Rozwiązanie problemu pakowania** — Przy zadanej **pojemności** przedmioty są sortowane malejąco według **wartość / waga**. Algorytm przechodzi po tej kolejności i dodaje przedmiot, jeśli się mieści; w przeciwnym razie go pomija.
3. **Wypisanie wyniku** — Indeksy wybranych przedmiotów oraz **suma wartości** i **suma masy**.

Podejście zachłanne jest szybkie i przejrzyste; **nie** gwarantuje rozwiązania optymalnego dla plecaka 0-1 w każdym przypadku (pełna optymalność w ogólności wymagałaby np. programowania dynamicznego lub metody podziału i ograniczeń).

## Wymagania

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- System Windows (wymagany dla projektu WinForms)

## Struktura rozwiązania

| Projekt | Typ | Opis |
| ------- | --- | ---- |
| `Net_Lab1` | Konsola | Biblioteka logiki + punkt wejścia CLI |
| `WinFormsApp` | WinForms (.NET 8-windows) | Interfejs graficzny z formularzem do wprowadzania danych i przyciskiem Solve |
| `Tests` | MSTest | Testy jednostkowe pokrywające logikę zachłanną |

## Uruchomienie (konsola)

Z katalogu `Net_Lab1/Net_Lab1/`:

```bash
dotnet run
```

Program poprosi o:

| Dane wejściowe | Znaczenie |
| -------------- | --------- |
| Liczba przedmiotów | Ile losowych przedmiotów wygenerować (`n`) |
| Ziarno (seed) | Ziarno generatora losowego (to samo ziarno → te same przedmioty) |
| Pojemność | Maksymalna dopuszczalna suma wag w plecaku |

## Uruchomienie (WinForms)

Z katalogu `Net_Lab1/WinFormsApp/`:

```bash
dotnet run
```

Formularz zawiera pola **N**, **Seed**, **Capacity** oraz przycisk **Solve** wyświetlający wynik w oknie tekstowym.

## Uruchomienie testów

Z katalogu `Net_Lab1/Tests/`:

```bash
dotnet test
```

Testy sprawdzają m.in.: wynik dla małej pojemności, brak wybranych przedmiotów przy pojemności 0, poprawność granic wartości i wag, a także znane ręcznie zbudowane przypadki z oczekiwanym wynikiem.

## Struktura plików (projekt główny)

| Plik | Rola |
| ---- | ---- |
| `Program.cs` | Punkt wejścia: odczyt danych, utworzenie `Problem`, wypisanie rozwiązania |
| `Problem.cs` | Generowanie przedmiotów oraz zachłanne pakowanie w `Solve(capacity)` |
| `Item.cs` | Przechowuje `value` i `weight` jednego przedmiotu |
| `Result.cs` | Indeksy wybranych przedmiotów i sumy |


