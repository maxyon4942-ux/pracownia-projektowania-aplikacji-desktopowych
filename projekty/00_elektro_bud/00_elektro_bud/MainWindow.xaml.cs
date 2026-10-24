using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace _00_elektro_bud
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MiejsceWMagazynie m = new("A01", "C431", "43");
            Produkt p = new("34298423432", "Pomidor", "Warzywa", m);
            Produkt p2 = new("300432", "Jablko", "Owoce", m);
            Produkt p3 = new("6453543", "Sofa", "Meble", m);
            Produkt p4 = new("111111102", "Komputer", "Elektronika", m);
            WyswietlProdukty(ListaProduktow.lista);
        }

        private void txtWyszukaj_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            List<Produkt>? wyszukaneProdukty = ListaProduktow.Wyszukaj("nazwa", txtWyszukaj.Text);
            if (wyszukaneProdukty == null) return;
            itmKatalog.Items.Clear();
            WyswietlProdukty(wyszukaneProdukty);
        }

        private void WyswietlProdukty(List<Produkt> produkt)
        {
            itmKatalog.Items.Clear();
            foreach (Produkt p in produkt)
            {
                Label l = new();
                l.Content = p.nazwa;
                l.FontSize = 20;
                l.HorizontalAlignment = HorizontalAlignment.Center;
                itmKatalog.Items.Add(l);
            }
        }
    }
}