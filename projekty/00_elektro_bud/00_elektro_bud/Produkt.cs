using System;
using System.Collections.Generic;
using System.Text;

namespace _00_elektro_bud
{
    internal class Produkt
    {
        public string kodEAN;
        public string nazwa;
        public string kategoria;
        public MiejsceWMagazynie miejscePrzechowania;

        public Produkt(string kodEAN, string nazwa, string kategoria, MiejsceWMagazynie miejscePrzechowania)
        {
            this.kodEAN = kodEAN;
            this.nazwa = nazwa;
            this.kategoria = kategoria;
            this.miejscePrzechowania = miejscePrzechowania;
            ListaProduktow.lista.Add(this);
        } 
    }
}
