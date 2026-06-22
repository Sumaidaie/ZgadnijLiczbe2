using Projekti_gra_2;
using System;

namespace Projekti_gra_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tworzymy obiekt głównej klasy gry i uruchamiamy menu
            Gra gra = new Gra();
            gra.Uruchom();
        }
    }
}