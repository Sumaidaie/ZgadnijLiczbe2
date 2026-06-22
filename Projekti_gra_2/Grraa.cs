using Projekti_gra_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Projekti_gra_2
{
    public class Gra
    {
       
        private Ustawienia ustawienia;           // przechowuje język i ustawienia zakładu
        private ZarzadcaWynikow zarzadcaWynikow; // zarządza Hall of Fame (TOP5)
        private Random random = new Random();    // generator liczb losowych

        // Słowniki z tekstami w dwóch językach (polski i angielski)
        private Dictionary<string, string> tekstyPL = new Dictionary<string, string>();
        private Dictionary<string, string> tekstyEN = new Dictionary<string, string>();

        //  Konstruktor – wczytuje ustawienia i przygotowuje teksty
        public Gra()
        {
            ustawienia = Ustawienia.Wczytaj();               // wczytaj zapisane ustawienia (lub domyślne)
            zarzadcaWynikow = new ZarzadcaWynikow();        // przygotuj zarządcę wyników
            InicjalizujTeksty();                            // załaduj wszystkie napisy (PL i EN)
        }

        // Inicjuje słowniki
        private void InicjalizujTeksty()
        {
            // ========== POLSKI ==========
            tekstyPL["witaj"] = "GRA 'ZGADNIJ LICZBE 2'";
            tekstyPL["nowa_gra"] = "1. Rozpocznij nowa gre";
            tekstyPL["top5"] = "2. Hall of Fame (TOP5)";
            tekstyPL["ustawienia"] = "3. Ustawienia";
            tekstyPL["wyjscie"] = "4. Wyjscie z gry";
            tekstyPL["wybierz"] = "       Twoj wybor: ";
            tekstyPL["nieprawidlowy"] = "Nieprawidlowy wybor. Sprobuj ponownie.";
            tekstyPL["brak_top5"] = "       Brak wynikow! Rozegraj najpierw gre.";

            // Menu wyników
            tekstyPL["menu_wynikow"] = "TABELA WYNIKOW - WYBIERZ POZIOM";
            tekstyPL["wyniki_latwy"] = "1. Wyniki dla poziomu LATWY (1-50)";
            tekstyPL["wyniki_sredni"] = "2. Wyniki dla poziomu SREDNI (1-100)";
            tekstyPL["wyniki_trudny"] = "3. Wyniki dla poziomu TRUDNY (1-250)";
            tekstyPL["wyniki_powrot"] = "4. Powrot do menu glownego";

            // Wybór poziomu
            tekstyPL["wybor_poziomu"] = "WYBOR POZIOMU TRUDNOSCI";
            tekstyPL["poziom_latwy"] = "1. Poziom LATWY     (1-50)";
            tekstyPL["poziom_sredni"] = "2. Poziom SREDNI    (1-100)";
            tekstyPL["poziom_trudny"] = "3. Poziom TRUDNY    (1-250)";

            // Tryb zakładu
            tekstyPL["tryb_zakladu_naglowek"] = "TRYB ZAKLADU";
            tekstyPL["czy_tryb_zakladu"] = "       Czy chcesz grac w trybie zakladu?";
            tekstyPL["tryb_zakladu_tak"] = "       1. Tak, ustaw maksymalna liczbe prob";
            tekstyPL["tryb_zakladu_nie"] = "       2. Nie, graj bez ograniczen";
            tekstyPL["podaj_limit"] = "       Podaj maksymalna liczbe prob: ";
            tekstyPL["nieprawidlowy_limit"] = "       Nieprawidlowa liczba! Ustawiam 10 prob.";

            // Wybór trybu gry
            tekstyPL["wybor_trybu"] = "WYBOR TRYBU GRY";
            tekstyPL["tryb_standard"] = "1. Standard (Zgadnij liczbe 1)";
            tekstyPL["tryb_newgameplus"] = "2. New Game Plus (co 6/7/8 strzalow liczba sie zmienia)";

            // Gra
            tekstyPL["proba_nr"] = "       Proba nr {0}";
            tekstyPL["podaj_liczbe"] = "       Podaj swoja liczbe: ";
            tekstyPL["gratulacje"] = "GRATULACJE! WYGRALES! O_o :0";
            tekstyPL["wylosowana"] = "       Wylosowana liczba: {0}";
            tekstyPL["liczba_prob"] = "       Liczba prob: {0}";
            tekstyPL["czas_gry"] = "       Czas gry: {0:F1} sekund";
            tekstyPL["podaj_imie"] = "\n       Podaj swoje imie: ";
            tekstyPL["wynik_zapisany"] = "\n       Wynik zapisany! Nacisnij Enter, aby kontynuowac ^_^";
            tekstyPL["przegrana_zaklad"] = "\n       PRZEGRALES :(  Przekroczyles maksymalna liczbe prob ({0})\n       Wylosowana liczba to: {1}";
            tekstyPL["przelosowano"] = ">>> UWAGA! Liczba zostala PRZELOSOWANA! <<<";
            tekstyPL["wroc_enter"] = "\n       Nacisnij Enter, aby powrocic do menu...";

            // Hall of Fame
            tekstyPL["hof_naglowek"] = "HALL OF FAME - WYBIERZ POZIOM";
            tekstyPL["hof_latwy"] = "1. Latwy (1-50)";
            tekstyPL["hof_sredni"] = "2. Sredni (1-100)";
            tekstyPL["hof_trudny"] = "3. Trudny (1-250)";
            tekstyPL["hof_powrot"] = "4. Powrot";
            tekstyPL["hof_tytul"] = "TOP 5 - POZIOM {0} ({1})";
            tekstyPL["hof_naglowek_tabeli"] = "       MIEJSCE | GRACZ          | PROBY | CZAS(s) | TRYB";
            tekstyPL["hof_wiersz"] = "       {0,6} | {1,-12} | {2,5} | {3,5:F1} | {4}";

            // Ustawienia
            tekstyPL["ustawienia_naglowek"] = "USTAWIENIA";
            tekstyPL["ustawienia_jezyk"] = "1. Jezyk / Language: {0}";
            tekstyPL["ustawienia_pytanie_zaklad"] = "2. Pytaj o tryb zakladu: {0}";
            tekstyPL["ustawienia_czysc_hof"] = "3. Wyczysc Hall of Fame (TOP5)";
            tekstyPL["ustawienia_powrot"] = "4. Powrot";
            tekstyPL["podaj_jezyk"] = "Podaj jezyk (PL/EN): ";
            tekstyPL["potwierdz_czyszczenie"] = "Czy na pewno wyczyscic wszystkie rekordy? (t/n): ";
            tekstyPL["rekordy_usuniete"] = "Rekordy usuniete.";
            tekstyPL["jezyk_zmieniony"] = "Jezyk zostal zmieniony na {0}.";
            tekstyPL["blad_jezyk"] = "Nieprawidlowy jezyk! Wybierz PL lub EN.";
            tekstyPL["zaklad_zmieniony"] = "Tryb zakladu zostal zmieniony na: {0}";
            tekstyPL["tak"] = "TAK";
            tekstyPL["nie"] = "NIE";
            tekstyPL["powrot"] = "0. Powrot do menu glownego";
            tekstyPL["blad_wybor_poziom"] = "Nieprawidlowy wybor! Wybierz 0, 1, 2 lub 3.";
            tekstyPL["blad_wybor_tryb"] = "Nieprawidlowy wybor! Wybierz 0, 1 lub 2.";
            tekstyPL["blad_wybor_zaklad"] = "Nieprawidlowy wybor! Wybierz 0, 1 lub 2.";
            tekstyPL["potwierdz_tak"] = "t";
            tekstyPL["potwierdz_nie"] = "n";

            // ========== ANGIELSKI ==========
            tekstyEN["witaj"] = "GUESS THE NUMBER GAME 2";
            tekstyEN["nowa_gra"] = "1. Start new game";
            tekstyEN["top5"] = "2. Hall of Fame (TOP5)";
            tekstyEN["ustawienia"] = "3. Settings";
            tekstyEN["wyjscie"] = "4. Exit";
            tekstyEN["wybierz"] = "       Your choice: ";
            tekstyEN["nieprawidlowy"] = "Invalid choice. Try again.";
            tekstyEN["brak_top5"] = "       No scores! Play a game first.";

            tekstyEN["menu_wynikow"] = "SCORE TABLE - SELECT LEVEL";
            tekstyEN["wyniki_latwy"] = "1. EASY level (1-50)";
            tekstyEN["wyniki_sredni"] = "2. MEDIUM level (1-100)";
            tekstyEN["wyniki_trudny"] = "3. HARD level (1-250)";
            tekstyEN["wyniki_powrot"] = "4. Back to main menu";

            tekstyEN["wybor_poziomu"] = "SELECT DIFFICULTY LEVEL";
            tekstyEN["poziom_latwy"] = "1. EASY     (1-50)";
            tekstyEN["poziom_sredni"] = "2. MEDIUM   (1-100)";
            tekstyEN["poziom_trudny"] = "3. HARD     (1-250)";

            tekstyEN["tryb_zakladu_naglowek"] = "BET MODE";
            tekstyEN["czy_tryb_zakladu"] = "       Do you want to play in bet mode?";
            tekstyEN["tryb_zakladu_tak"] = "       1. Yes, set max attempts";
            tekstyEN["tryb_zakladu_nie"] = "       2. No, play without limits";
            tekstyEN["podaj_limit"] = "       Enter max attempts: ";
            tekstyEN["nieprawidlowy_limit"] = "       Invalid number! Setting 10 attempts.";

            tekstyEN["wybor_trybu"] = "SELECT GAME MODE";
            tekstyEN["tryb_standard"] = "1. Standard (Guess number 1)";
            tekstyEN["tryb_newgameplus"] = "2. New Game Plus (number rerolls every 6/7/8 attempts)";

            tekstyEN["proba_nr"] = "       Attempt #{0}";
            tekstyEN["podaj_liczbe"] = "       Enter your number: ";
            tekstyEN["gratulacje"] = "CONGRATULATIONS! YOU WIN! O_o :0";
            tekstyEN["wylosowana"] = "       The number was: {0}";
            tekstyEN["liczba_prob"] = "       Attempts: {0}";
            tekstyEN["czas_gry"] = "       Game time: {0:F1} seconds";
            tekstyEN["podaj_imie"] = "\n       Enter your name: ";
            tekstyEN["wynik_zapisany"] = "\n       Score saved! Press Enter to continue ^_^";
            tekstyEN["przegrana_zaklad"] = "\n       YOU LOSE :( Max attempts exceeded ({0})\n       The number was: {1}";
            tekstyEN["przelosowano"] = ">>> WARNING! Number has been REROLLED! <<<";
            tekstyEN["wroc_enter"] = "\n       Press Enter to return to menu...";

            tekstyEN["hof_naglowek"] = "HALL OF FAME - SELECT LEVEL";
            tekstyEN["hof_latwy"] = "1. Easy (1-50)";
            tekstyEN["hof_sredni"] = "2. Medium (1-100)";
            tekstyEN["hof_trudny"] = "3. Hard (1-250)";
            tekstyEN["hof_powrot"] = "4. Back";
            tekstyEN["hof_tytul"] = "TOP 5 - LEVEL {0} ({1})";
            tekstyEN["hof_naglowek_tabeli"] = "       PLACE | PLAYER         | ATTEMPTS | TIME(s) | MODE";
            tekstyEN["hof_wiersz"] = "       {0,6} | {1,-12} | {2,5} | {3,5:F1} | {4}";

            tekstyEN["ustawienia_naglowek"] = "SETTINGS";
            tekstyEN["ustawienia_jezyk"] = "1. Language: {0}";
            tekstyEN["ustawienia_pytanie_zaklad"] = "2. Ask for bet mode: {0}";
            tekstyEN["ustawienia_czysc_hof"] = "3. Clear Hall of Fame (TOP5)";
            tekstyEN["ustawienia_powrot"] = "4. Back";
            tekstyEN["podaj_jezyk"] = "Enter language (PL/EN): ";
            tekstyEN["potwierdz_czyszczenie"] = "Are you sure to clear all records? (y/n): ";
            tekstyEN["rekordy_usuniete"] = "Records deleted.";
            tekstyEN["jezyk_zmieniony"] = "Language changed to {0}.";
            tekstyEN["blad_jezyk"] = "Invalid language! Choose PL or EN.";
            tekstyEN["zaklad_zmieniony"] = "Bet mode changed to: {0}";
            tekstyEN["tak"] = "YES";
            tekstyEN["nie"] = "NO";
            tekstyEN["powrot"] = "0. Back to main menu";
            tekstyEN["blad_wybor_poziom"] = "Invalid choice! Choose 0, 1, 2 or 3.";
            tekstyEN["blad_wybor_tryb"] = "Invalid choice! Choose 0, 1 or 2.";
            tekstyEN["blad_wybor_zaklad"] = "Invalid choice! Choose 0, 1 or 2.";
            tekstyEN["potwierdz_tak"] = "y";
            tekstyEN["potwierdz_nie"] = "n";
        }

        // Metoda pomocnicza do pobierania tekstu w odpowiednim języku
        private string T(string klucz, params object[] args)
        {
            string tekst = (ustawienia.Jezyk == "PL" && tekstyPL.ContainsKey(klucz)) ? tekstyPL[klucz] :
                           (tekstyEN.ContainsKey(klucz) ? tekstyEN[klucz] : klucz);
            return args.Length > 0 ? string.Format(tekst, args) : tekst;
        }

        // Przeciążenie bez argumentów
        private string T(string klucz) => T(klucz, new object[0]);

        //GŁÓWNE MENU (pętla)
        public void Uruchom()
        {
            while (true)
            {
                Console.Clear();
                Ramka(T("witaj"));
                Console.WriteLine(T("nowa_gra"));
                // Opcja TOP5 jest widoczna TYLKO jeśli istnieją jakieś wyniki (wymaganie z zadania)
                if (zarzadcaWynikow.CzySaJakiekolwiekWyniki())
                    Console.WriteLine(T("top5"));
                else
                    Console.WriteLine($"2. {T("brak_top5")}");
                Console.WriteLine(T("ustawienia"));
                Console.WriteLine(T("wyjscie"));
                Console.Write(T("wybierz"));
                string wybor = Console.ReadLine();

                if (wybor == "1") NowaGra();
                else if (wybor == "2" && zarzadcaWynikow.CzySaJakiekolwiekWyniki()) PokazTop5();
                else if (wybor == "3") MenuUstawien();
                else if (wybor == "4") return;
                else { Console.WriteLine(T("nieprawidlowy")); Thread.Sleep(1000); }
            }
        }

        // ===== EKRAN USTAWIEN (zmiana języka, czyszczenie TOP5, włącz/wyłącz pytanie o zakład) 
        private void MenuUstawien()
        {
            Console.Clear();
            Ramka(T("ustawienia_naglowek"));
            Console.WriteLine(T("ustawienia_jezyk", ustawienia.Jezyk));
            Console.WriteLine(T("ustawienia_pytanie_zaklad", ustawienia.CzyPytacOZaklad ? T("tak") : T("nie")));
            Console.WriteLine(T("ustawienia_czysc_hof"));
            Console.WriteLine(T("ustawienia_powrot"));
            Console.Write(T("wybierz"));   // <-- TUTAJ JEST ZMIANA (było "\nWybierz: ")
            string opcja = Console.ReadLine();

            switch (opcja)
            {
                case "1":
                    Console.Write(T("podaj_jezyk"));
                    string lang = Console.ReadLine().ToUpper();
                    if (lang == "PL" || lang == "EN")
                    {
                        ustawienia.Jezyk = lang;
                        ustawienia.Zapisz();
                        Console.WriteLine(T("jezyk_zmieniony", lang));
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine(T("blad_jezyk"));
                        Thread.Sleep(1000);
                    }
                    break;
                case "2":
                    ustawienia.CzyPytacOZaklad = !ustawienia.CzyPytacOZaklad;
                    ustawienia.Zapisz();
                    Console.WriteLine(T("zaklad_zmieniony", ustawienia.CzyPytacOZaklad ? T("tak") : T("nie")));
                    Thread.Sleep(1000);
                    break;
                case "3": // czyszczenie całej Hall of Fame (z potwierdzeniem)
                    Console.Write(T("potwierdz_czyszczenie"));
                    string odpowiedz = Console.ReadLine().ToLower();
                    if (odpowiedz == "t" || odpowiedz == "y")  
                    {
                        zarzadcaWynikow.WyczyscWszystkie();
                        Console.WriteLine(T("rekordy_usuniete"));
                        Thread.Sleep(1000);
                    }
                    break;
                case "4": return;
            }
        }

        // WYŚWIETLANIE TOP5 DLA WYBRANEGO POZIOMU
        private void PokazTop5()
        {
            while (true)
            {
                Console.Clear();
                Ramka(T("hof_naglowek"));
                Console.WriteLine(T("hof_latwy"));
                Console.WriteLine(T("hof_sredni"));
                Console.WriteLine(T("hof_trudny"));
                Console.WriteLine(T("hof_powrot"));
                Console.Write(T("wybierz"));
                string opcja = Console.ReadLine();
                string poziom = "", zakres = "";
                if (opcja == "1") { poziom = "latwy"; zakres = "1-50"; }
                else if (opcja == "2") { poziom = "sredni"; zakres = "1-100"; }
                else if (opcja == "3") { poziom = "trudny"; zakres = "1-250"; }
                else if (opcja == "4") return;
                else continue;

                var top = zarzadcaWynikow.PobierzTop5(poziom); // pobiera TOP5 dla danego poziomu
                Console.Clear();
                Ramka(T("hof_tytul", poziom.ToUpper(), zakres));
                if (top.Count == 0)
                    Console.WriteLine("       Brak wynikow dla tego poziomu!");
                else
                {
                    Console.WriteLine(T("hof_naglowek_tabeli"));
                    for (int i = 0; i < top.Count; i++)
                    {
                        // Dodajemy wyróżnienie [NG+] dla wyników z trybu New Game Plus
                        string trybOzn = top[i].CzyNewGamePlus ? "[NG+]" : "Std";
                        Console.WriteLine(T("hof_wiersz", i + 1, top[i].Imie, top[i].Proby, top[i].CzasSekundy, trybOzn));
                    }
                }
                Console.WriteLine(T("wroc_enter"));
                Console.ReadLine();
            }
        }

        //OZPOCZĘCIE NOWEJ GRY (tu zachodzi polimorfizm) 
        private void NowaGra()
        {
            // Wybór poziomu trudności (łatwy 1-50, średni 1-100, trudny 1-250) 
            int minZakres = 1, maxZakres = 50, coIlePrzelosuj = 6;
            string nazwaPoziomu = "latwy";
            bool poprawnyPoziom = false;

            while (!poprawnyPoziom)
            {
                Console.Clear();
                Ramka(T("wybor_poziomu"));
                Console.WriteLine(T("poziom_latwy"));
                Console.WriteLine(T("poziom_sredni"));
                Console.WriteLine(T("poziom_trudny"));
                Console.WriteLine(T("powrot"));  // <-- UŻYCIE T()
                Console.Write(T("wybierz"));
                string wybor = Console.ReadLine();

                if (wybor == "0")
                {
                    return;  // Powrót do menu głównego
                }

                switch (wybor)
                {
                    case "1": minZakres = 1; maxZakres = 50; nazwaPoziomu = "latwy"; coIlePrzelosuj = 6; poprawnyPoziom = true; break;
                    case "2": minZakres = 1; maxZakres = 100; nazwaPoziomu = "sredni"; coIlePrzelosuj = 7; poprawnyPoziom = true; break;
                    case "3": minZakres = 1; maxZakres = 250; nazwaPoziomu = "trudny"; coIlePrzelosuj = 8; poprawnyPoziom = true; break;
                    default:
                        Console.WriteLine(T("blad_wybor_poziom"));  // <-- UŻYCIE T()
                        Thread.Sleep(1000);
                        break;
                }
            }

            // Wybór trybu gry: Standard (Zgadnij liczbę 1) lub New Game Plus 
            bool czyNewGamePlus = false;
            bool poprawnyTryb = false;

            while (!poprawnyTryb)
            {
                Console.Clear();
                Ramka(T("wybor_trybu"));
                Console.WriteLine(T("tryb_standard"));
                Console.WriteLine(T("tryb_newgameplus"));
                Console.WriteLine(T("powrot"));  // <-- UŻYCIE T()
                Console.Write(T("wybierz"));
                string trybGry = Console.ReadLine();

                if (trybGry == "0")
                {
                    return;  // Powrót do menu głównego
                }

                if (trybGry == "1")
                {
                    czyNewGamePlus = false;
                    poprawnyTryb = true;
                }
                else if (trybGry == "2")
                {
                    czyNewGamePlus = true;
                    poprawnyTryb = true;
                }
                else
                {
                    Console.WriteLine(T("blad_wybor_tryb"));  // <-- UŻYCIE T()
                    Thread.Sleep(1000);
                }
            }

            // Tryb zakładu (tylko dla trybu standardowego i jeśli włączono w ustawieniach) 
            bool trybZakladu = false;
            int maxProb = 0;
            if (!czyNewGamePlus && ustawienia.CzyPytacOZaklad)
            {
                bool poprawnyZaklad = false;
                while (!poprawnyZaklad)
                {
                    Console.Clear();
                    Ramka(T("tryb_zakladu_naglowek"));
                    Console.WriteLine(T("czy_tryb_zakladu"));
                    Console.WriteLine(T("tryb_zakladu_tak"));
                    Console.WriteLine(T("tryb_zakladu_nie"));
                    Console.WriteLine(T("powrot"));  // <-- UŻYCIE T()
                    Console.Write(T("wybierz"));
                    string odp = Console.ReadLine();

                    if (odp == "0")
                    {
                        return;  // Powrót do menu głównego
                    }

                    if (odp == "1")
                    {
                        trybZakladu = true;
                        Console.Write(T("podaj_limit"));
                        if (!int.TryParse(Console.ReadLine(), out maxProb) || maxProb <= 0)
                        {
                            Console.WriteLine(T("nieprawidlowy_limit"));
                            maxProb = 10;
                            Thread.Sleep(1000);
                        }
                        poprawnyZaklad = true;
                    }
                    else if (odp == "2")
                    {
                        trybZakladu = false;
                        poprawnyZaklad = true;
                    }
                    else
                    {
                        Console.WriteLine(T("blad_wybor_zaklad"));  // <-- UŻYCIE T()
                        Thread.Sleep(1000);
                    }
                }
            }

            // ===== POLIMORFIZM =====
            // Zmienna typu abstrakcyjnego GraBazowa może przechowywać obiekt dowolnej klasy pochodnej.
            GraBazowa rozgrywka = null;

            if (czyNewGamePlus)
            {
                // Tworzymy grę w trybie New Game Plus
                rozgrywka = new GraNewGamePlus(minZakres, maxZakres, nazwaPoziomu, coIlePrzelosuj);
            }
            else
            {
                // Tworzymy grę standardową (może być z zakładem lub bez)
                rozgrywka = new GraStandardowa(minZakres, maxZakres, nazwaPoziomu, trybZakladu, maxProb);
            }

            // Wywołanie metody PrzeprowadzRozgrywke() – polimorficzne:
            // W zależności od rzeczywistego typu obiektu, wykona się odpowiednia wersja (standardowa lub NG+)
            rozgrywka.PrzeprowadzRozgrywke();

            // --- Obsługa po zakończeniu gry ---
            if (rozgrywka.Wygrana)
            {
                Console.Clear();
                Ramka(T("gratulacje"));
                Console.WriteLine(T("liczba_prob", rozgrywka.Proby));
                Console.WriteLine(T("czas_gry", rozgrywka.CzasTrwania));  // wyświetlamy czas rozgrywki
                Console.Write(T("podaj_imie"));
                string imie = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(imie)) imie = "Anonim";

                // Zapisujemy wynik (imię, próby, czas, poziom, informacja o trybie NG+)
                Wynik wynik = new Wynik(imie, rozgrywka.Proby, rozgrywka.CzasTrwania, nazwaPoziomu, czyNewGamePlus);
                zarzadcaWynikow.DodajWynik(wynik);
                Console.WriteLine(T("wynik_zapisany"));
            }
            else
            {
                // Przegrana (tylko w trybie zakładu – przekroczono limit prób)
                Console.WriteLine(T("przegrana_zaklad", maxProb, "?"));
                Console.WriteLine(T("wroc_enter"));
            }
            Console.ReadLine();
        }

        // Rysowanie ramki wokół tekstuto j
        private void Ramka(string tekst)
        {
            int szer = 60;
            string linia = new string('=', szer);
            Console.WriteLine(linia);
            int spacje = (szer - tekst.Length - 2) / 2;
            if (spacje < 0) spacje = 0;
            Console.WriteLine(new string(' ', spacje) + tekst);
            Console.WriteLine(linia);
        }
    }
}