using System;
using System.Collections.Generic;
using System.Text;

namespace _00_elektro_bud
{
    internal class MiejsceWMagazynie
    {
        private string sektor;
        private string regal;
        private string polka;

        public MiejsceWMagazynie(string sektor, string regal, string polka)
        {
            this.sektor = sektor;
            this.regal = regal;
            this.polka = polka;
        }
    }
}
