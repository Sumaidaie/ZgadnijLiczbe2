using System;
using System.Diagnostics;

namespace Projekti_gra_2
{
    // DZIEDZICZY po GraBazowa – wykorzystuje tę samą abstrakcyjną klasę bazową.
    public class GraNewGamePlus : GraBazowa
    {
        // Konstruktor – przekazuje parametry: trybZakladu = false, newGamePlus = true
        public GraNewGamePlus(int min, int max, string poziom, int coIlePrzelosuj)
            : base(min, max, poziom, false, 0, true, coIlePrzelosuj) { }

        // Implementacja metody abstrakcyjnej – logika z przelosowywaniem
        public override void PrzeprowadzRozgrywke()
        {
            int sekret = random.Next(minZakres, maxZakres + 1);
            int proby = 0;
            Stopwatch stoper = new Stopwatch();
            stoper.Start();

            while (true)
            {
                proby++;
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
                    ZakonczGre(true, stoper.Elapsed.TotalSeconds);
                    return;
                }
                else
                {
                    string komunikat = (strzal < sekret) ? LosowyKomunikat(true) : LosowyKomunikat(false);
                    Console.WriteLine(komunikat);
                }
                
                // ----- NOWOŚĆ: przelosowanie liczby co określoną liczbę prób -----
                // Dla łatwego co 6, średniego co 7, trudnego co 8.
                if (proby % coIlePrzelosuj == 0)
                {
                    sekret = random.Next(minZakres, maxZakres + 1);
                    Console.WriteLine(">>> UWAGA! Liczba zostala PRZELOSOWANA! <<<");
                }
            }
        }

        // Komunikaty – identyczne jak w standardowej grze (można by wydzielić, ale zostawiamy)
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
            int idx = new Random().Next(8);
            return zaMalo ? zaMaloKom[idx] : zaDuzoKom[idx];
        }
    }
}