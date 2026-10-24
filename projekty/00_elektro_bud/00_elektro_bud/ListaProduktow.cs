using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace _00_elektro_bud
{
    static class ListaProduktow
    {
        public static List<Produkt> lista = new();

        public static List<Produkt>? Wyszukaj(string metoda, string tekst)
        {
            if (lista.Count == 0) return null;
            List<Produkt> pLista = new();
            string tekstDoWyszukania;
            foreach(Produkt p in lista)
            {
                if (metoda == "nazwa") tekstDoWyszukania = p.nazwa.ToLower();
                else if (metoda == "EAN") tekstDoWyszukania = p.kodEAN.ToLower();
                else return null;
                if (p.nazwa.ToLower().Contains(tekst.ToLower()))
                {
                    pLista.Add(p);
                }
            }
            return pLista;
        }
    }

}
