# Zgadnij liczbę 2!

Gra polega na odgadnięciu wylosowanej liczby.

## Uruchomienie

Wymagany .NET 6.0 lub nowszy.

---

## Menu główne

1 - Nowa gra
2 - Hall of Fame (TOP5) – widoczne po rozegraniu przynajmniej jednej gry
3 - Ustawienia
4 - Wyjście

---

## Nowa gra – krok po kroku

### 1. Wybór poziomu

1 - Łatwy (1-50)
2 - Średni (1-100)
3 - Trudny (1-250)
0 - Powrót do menu

### 2. Wybór trybu

1 - Standard – zgadujesz stałą liczbę, możesz ustawić limit prób
2 - New Game Plus – liczba zmienia się co 6/7/8 strzałów (brak trybu zakładu)
0 - Powrót do menu

### 3. Tryb zakładu (tylko dla Standard)

1 - Ustaw limit prób (podaj liczbę)
2 - Graj bez limitu
0 - Powrót do menu

---

## W trakcie gry

- Widzisz numer próby
- Po błędnym strzale dostajesz losowy komunikat "za mało" lub "za dużo"
- W New Game Plus po 6/7/8 próbach liczba się zmienia

## Po wygranej

- Wpisz imię
- Wynik (próby + czas) zapisuje się w Hall of Fame

---

## Hall of Fame (TOP5)

- Wybierz poziom, żeby zobaczyć TOP5
- Sortowanie: najpierw liczba prób (mniej = lepiej), potem czas (krócej = lepiej)
- Wyniki z New Game Plus mają znacznik [NG+]

---

## Ustawienia

1 - Zmień język (wpisz PL lub EN)
2 - Włącz/wyłącz pytanie o tryb zakładu
3 - Wyczyść wszystkie wyniki (potwierdź t/n)
4 - Powrót

---

## Pliki

- ustawienia.json – zapis ustawień (język, tryb zakładu)
- wyniki.json – zapis rankingu

Pliki tworzą się same przy pierwszym uruchomieniu.