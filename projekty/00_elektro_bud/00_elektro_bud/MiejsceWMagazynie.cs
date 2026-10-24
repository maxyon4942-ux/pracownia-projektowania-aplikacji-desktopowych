using System;
using System.Collections.Generic;
using System.Text;

namespace _00_elektro_bud
{
    internal class MiejsceWMagazynie
    {
        public string sektor;
        public string regal;
        public string polka;

        public MiejsceWMagazynie(string sektor, string regal, string polka)
        {
            this.sektor = sektor;
            this.regal = regal;
            this.polka = polka;
        }
    }
}
