using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using Label = System.Windows.Controls.Label;

namespace _00_elektro_bud
{
    public partial class MainWindow : Window
    {
        private string metodaWyszukiwania;
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
            MessageBox.Show(metodaWyszukiwania);
            List<Produkt>? wyszukaneProdukty = ListaProduktow.Wyszukaj(metodaWyszukiwania, txtWyszukaj.Text);
            if (wyszukaneProdukty == null) return;
            itmKatalog.Items.Clear();
            WyswietlProdukty(wyszukaneProdukty);
        }

        private void WyswietlProdukty(List<Produkt> produkt)
        {
            itmKatalog.Items.Clear();
            foreach (Produkt p in produkt)
            {
                Grid grid = new();
                ColumnDefinition c = new();
                c.Width = new GridLength(1, GridUnitType.Star);
                ColumnDefinition c1 = new();
                c1.Width = new GridLength(1, GridUnitType.Star);
                grid.ColumnDefinitions.Add(c);
                grid.ColumnDefinitions.Add(c1);
                Label l = new();
                l.Content = p.nazwa;
                l.FontSize = 20;
                l.HorizontalAlignment = HorizontalAlignment.Center;
                Label l2 = new();
                l2.Content = p.kodEAN;
                l2.FontSize = 20;
                l2.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetColumn(l, 0);
                Grid.SetColumn(l2, 1);
                grid.Children.Add(l);
                grid.Children.Add(l2);
                itmKatalog.Items.Add(grid);
            }
        }

        private void cmbTrybWyszukiwania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbTrybWyszukiwania.SelectedIndex)
            {
                case 0:
                    metodaWyszukiwania = "nazwa";
                    MessageBox.Show("a");
                    return;
                case 1:
                    metodaWyszukiwania = "EAN";
                    MessageBox.Show("b");
                    return;
                default:
                    return;
            }
        }
    }
}