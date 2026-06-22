using Projekti_gra_2;
using System;
using System.Diagnostics;

namespace Projekti_gra_2
{
    // DZIEDZICZY po GraBazowa – przejmuje wszystkie pola i metody bazowe.
    public class GraStandardowa : GraBazowa
    {
        // Konstruktor – przekazuje parametry do konstruktora klasy bazowej.
        // Parametr newGamePlus ustawiamy na false, a coIlePrzelosuj na 0 (nieużywane).
        public GraStandardowa(int min, int max, string poziom, bool trybZakladu, int limitProb)
            : base(min, max, poziom, trybZakladu, limitProb, false, 0) { }

        // Implementacja abstrakcyjnej metody z klasy bazowej (POLIMORFIZM – nadpisujemy)
        public override void PrzeprowadzRozgrywke()
        {
            int sekret = random.Next(minZakres, maxZakres + 1); // losujemy liczbę
            int proby = 0;
            Stopwatch stoper = new Stopwatch();   // mierzymy czas od pierwszego strzału
            stoper.Start();

            while (true)
            {
                proby++;
                // Jeśli tryb zakładu i przekroczono limit – przegrana
                if (trybZakladu && proby > limitProb)
                {
                    ZakonczGre(false, stoper.Elapsed.TotalSeconds);
                    return;
                }

                Console.Write($"Próba #{proby}. Podaj liczbę ({minZakres}-{maxZakres}): ");
                if (!int.TryParse(Console.ReadLine(), out int strzal))
                {
                    Console.WriteLine("To nie liczba!");
                    continue;
                }

                if (strzal == sekret)
                {
                    stoper.Stop();
                    Proby = proby;
                    ZakonczGre(true, stoper.Elapsed.TotalSeconds); // wygrana, zapis czasu
                    return;
                }
                else
                {
                    // Losowy komunikat (za mało / za dużo)
                    string komunikat = (strzal < sekret) ? LosowyKomunikat(true) : LosowyKomunikat(false);
                    Console.WriteLine(komunikat);
                }
            }
        }

        // Pomocnicza metoda zwracająca losowy komunikat z ośmiu wariantów
        private string LosowyKomunikat(bool zaMalo)
        {
            string[] zaMaloKom = {
                "Za malo! Sprobuj wiekszej liczby.",
                "Ta liczba jest mniejsza od wylosowanej.",
                "Podnies troche!",
                "Dodaj troche wiecej.",
                "Sprobuj wiekszej wartosci.",
                "Celuj wyzejjj!",
                "Musisz zgadywac wyzsze liczby.",
                "Zimno , sprobuj jeszcze raz."
            };
            string[] zaDuzoKom = {
                "Za duzo! Sprobuj mniejszej liczby.",
                "Ta liczba jest wieksza od wylosowanej.",
                "Zmniejsz troche!",
                "Sprobuj mniejszej wartosci.",
                "Troszeczke mniej.",
                "Za wysokooo(Everest), zejdz nizej!",
                "Przesadziles, zmniejsz liczbe.",
                "To za duzOO, sprobuj mniej."
            };
            int idx = new Random().Next(8); // losujemy indeks 0-7
            return zaMalo ? zaMaloKom[idx] : zaDuzoKom[idx];
        }
    }
}