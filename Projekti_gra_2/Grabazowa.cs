using System;
using System.Diagnostics;

namespace Projekti_gra_2
{
    // KLASA ABSTRAKCYJNA – nie można utworzyć jej obiektu, tylko po niej dziedziczyć.
    // Zawiera wspólne pola i metody dla standardowej gry i New Game Plus.
    public abstract class GraBazowa
    {
        // Pola chronione (dostępne dla klas pochodnych)
        protected int minZakres;       // dolny zakres liczby do zgadnięcia
        protected int maxZakres;       // górny zakres
        protected string poziom;       // "latwy", "sredni", "trudny"
        protected Random random;       // generator losowych liczb
        protected bool trybZakladu;    // czy gra toczy się z limitem prób
        protected int limitProb;       // maksymalna liczba prób (jeśli trybZakladu = true)
        protected bool newGamePlus;    // czy to tryb New Game Plus
        protected int coIlePrzelosuj;  // co ile prób przelotować liczbę (6,7,8)

        // Właściwości publiczne (wynik gry)
        public int Proby { get; protected set; }          // liczba prób zużytych przez gracza
        public double CzasTrwania { get; protected set; } // czas gry w sekundach
        public bool Wygrana { get; protected set; }       // czy gracz wygrał?

        // ===== Konstruktor – ustawia wszystkie parametry gry =====
        public GraBazowa(int min, int max, string poziom, bool trybZakladu, int limitProb, bool newGamePlus, int coIlePrzelosuj)
        {
            this.minZakres = min;
            this.maxZakres = max;
            this.poziom = poziom;
            this.random = new Random();              // generator losowy
            this.trybZakladu = trybZakladu;
            this.limitProb = limitProb;
            this.newGamePlus = newGamePlus;
            this.coIlePrzelosuj = coIlePrzelosuj;
            Proby = 0;
            CzasTrwania = 0;
            Wygrana = false;
        }

        // ===== METODA ABSTRAKCYJNA – każda klasa pochodna MUSI ją zaimplementować =====
        // Dzięki temu wymuszamy, aby każdy tryb gry (Standard, NG+) miał własną logikę rozgrywki.
        public abstract void PrzeprowadzRozgrywke();

        // Metoda chroniona do aktualizacji wyniku (wspólna dla wszystkich gier)
        protected void ZakonczGre(bool sukces, double czas)
        {
            Wygrana = sukces;
            CzasTrwania = czas;
        }
    }
}