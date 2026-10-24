using System;
using System.Collections.Generic;
using System.Text;

namespace _00_elektro_bud
{
    internal class Produkt
    {
        private string kodEAN { get; }
        private string nazwa { get; }
        private string kategoria { get; }
        private MiejsceWMagazynie miejscePrzechowania { get; }

        public Produkt(string kodEAN, string nazwa, string kategoria, MiejsceWMagazynie miejscePrzechowania)
        {
            this.kodEAN = kodEAN;
            this.nazwa = nazwa;
            this.kategoria = kategoria;
            this.miejscePrzechowania = miejscePrzechowania;
        }     
    }
}
