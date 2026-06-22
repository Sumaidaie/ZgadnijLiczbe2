using Projekti_gra_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Projekti_gra_2
{
    // Odpowiada za przechowywanie, sortowanie, zapis i odczyt wyników.
    public class ZarzadcaWynikow
    {
        private List<Wynik> wszystkieWyniki = new List<Wynik>(); // lista wszystkich (ale w pliku tylko TOP5)
        private const string PlikWynikow = "wyniki.json";

        public ZarzadcaWynikow()
        {
            Wczytaj(); // przy starcie ładujemy wyniki z pliku
        }

        // Odczytywanie z pliku JSON (deserializacja)
        private void Wczytaj()
        {
            if (File.Exists(PlikWynikow))
            {
                string json = File.ReadAllText(PlikWynikow);
                wszystkieWyniki = JsonSerializer.Deserialize<List<Wynik>>(json) ?? new List<Wynik>();
            }
        }

        // Zapis do pliku JSON (serializacja)
        private void Zapisz()
        {
            string json = JsonSerializer.Serialize(wszystkieWyniki, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PlikWynikow, json);
        }

        // Dodaje nowy wynik, sortuje i zachowuje tylko TOP5 dla danego poziomu
        public void DodajWynik(Wynik nowy)
        {
            // Pobierz wszystkie wyniki dla tego samego poziomu
            var wynikiPoziomu = wszystkieWyniki.Where(w => w.Poziom == nowy.Poziom).ToList();
            wynikiPoziomu.Add(nowy);
            // Sortowanie: najpierw po liczbie prób (mniej = lepiej), potem po czasie (krócej = lepiej)
            var posortowane = wynikiPoziomu.OrderBy(w => w.Proby).ThenBy(w => w.CzasSekundy).Take(5).ToList();
            // Usuń stare wyniki dla tego poziomu i dodaj nową TOP5
            wszystkieWyniki.RemoveAll(w => w.Poziom == nowy.Poziom);
            wszystkieWyniki.AddRange(posortowane);
            Zapisz(); // natychmiastowy zapis
        }

        // Zwraca TOP5 dla wybranego poziomu (już posortowane według prób i czasu)
        public List<Wynik> PobierzTop5(string poziom)
        {
            return wszystkieWyniki.Where(w => w.Poziom == poziom)
                                  .OrderBy(w => w.Proby)
                                  .ThenBy(w => w.CzasSekundy)
                                  .ToList();
        }

        // Usuwa wszystkie wyniki (używane w ustawieniach)
        public void WyczyscWszystkie()
        {
            wszystkieWyniki.Clear();
            Zapisz(); // zapisuje pustą listę
        }

        // Sprawdza, czy istnieje jakikolwiek wynik (do ukrywania opcji TOP5 w menu)
        public bool CzySaJakiekolwiekWyniki()
        {
            return wszystkieWyniki.Count > 0;
        }
    }
}