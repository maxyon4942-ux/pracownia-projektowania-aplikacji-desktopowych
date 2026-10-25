using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace _00_elektro_bud
{
    static class ListaProduktow
    {
        public static List<Produkt> lista = new();

        public static void ZainicjujProdukty()
        {
            Produkt p = new("6967972467051", "Cement portlandzki Górażdże Premium Klasa 42,5 R", "Kable instalacyjne", new("A1", "R08", "12"));
            Produkt p1 = new("3429842343223", "Kabel zasilający YKY 5x10 mm²", "Kable energetyczne ziemne", new("A3", "R15", "01"));
            Produkt p2 = new("4517028459888", "Peszel giętki z pilotem PVC 20 mm", "Rury i peszle ochronne", new("C2", "R38", "22"));
            Produkt p3 = new("2091156949351", "Korytko PCV białe 40x40 mm", "Koryta i listwy elektroinstalacyjne", new("G3", "R01", "05"));
            Produkt p4 = new("5743127950974", "Wyłącznik nadprądowy B16 1-biegunowy", "Wyłączniki nadprądowe", new("A1", "R10", "15"));
            Produkt p5 = new("5576089450444", "Różnicówka 4P 40A 30mA AC", "Wyłączniki różnicowoprądowe", new("A2", "R02", "02"));
            Produkt p6 = new("8280193128136", "Rozdzielnica natynkowa 3x12 modułów", "Rozdzielnice", new("B1", "R04", "01"));
            Produkt p7 = new("5900760120306", "Ochronnik przepięć klasa B+C (T1+T2)", "Ograniczniki przepięć", new("C3", "R02", "03"));
        }
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
                if (tekstDoWyszukania.Contains(tekst.ToLower()))
                {
                    pLista.Add(p);
                }
            }
            return pLista;
        }
    }

}
