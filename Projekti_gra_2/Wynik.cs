using System;

namespace Projekti_gra_2
{
    // Przechowuje wszystkie informacje o jednym rozegranym i wygranym meczu.
    public class Wynik
    {
        // Właściwości (automatyczne) – enkapsulacja: dostęp publiczny, ale wewnętrznie to pola.
        public string Imie { get; set; }
        public int Proby { get; set; }
        public double CzasSekundy { get; set; }
        public string Poziom { get; set; }          // "latwy", "sredni", "trudny"
        public bool CzyNewGamePlus { get; set; }    // true = tryb New Game Plus, false = standard

        // PUSTY KONSTRUKTOR – wymagany do deserializacji JSON (odczyt z pliku)
        public Wynik() { }

        // Konstruktor używany w grze – od razu ustawia wszystkie dane
        public Wynik(string imie, int proby, double czas, string poziom, bool newGamePlus)
        {
            Imie = imie;
            Proby = proby;
            CzasSekundy = czas;
            Poziom = poziom;
            CzyNewGamePlus = newGamePlus;
        }
    }
}