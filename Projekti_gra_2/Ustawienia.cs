using System;
using System.IO;
using System.Text.Json;

namespace Projekti_gra_2
{
    // Klasa odpowiadająca za ustawienia użytkownika – zapisuje je w pliku JSON.
    public class Ustawienia
    {
        public string Jezyk { get; set; } = "PL";            // domyślnie polski
        public bool CzyPytacOZaklad { get; set; } = true;    // domyślnie pytamy o tryb zakładu

        private const string PlikUstawien = "ustawienia.json";

        // Wczytuje ustawienia z pliku (jeśli istnieje), w przeciwnym razie zwraca domyślne
        public static Ustawienia Wczytaj()
        {
            if (File.Exists(PlikUstawien))
            {
                string json = File.ReadAllText(PlikUstawien);
                return JsonSerializer.Deserialize<Ustawienia>(json) ?? new Ustawienia();
            }
            return new Ustawienia();
        }

        // Zapisuje ustawienia do pliku JSON
        public void Zapisz()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PlikUstawien, json);
        }
    }
}