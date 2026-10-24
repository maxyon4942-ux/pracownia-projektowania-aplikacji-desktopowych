using _00_elektro_bud.View.UserControls;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace _00_elektro_bud
{
    public partial class MainWindow : Window
    {
        private string metodaWyszukiwania;
        Dictionary<Button, Produkt> dic = new();
        //dictionary łączące przycisk produktu z obiektem klasy produkt
        Dictionary<Button, ProduktControl> dic2 = new();
        //dictionary łączące kontrolke produktu z przyciskiem

        public MainWindow()
        {
            InitializeComponent();
            MiejsceWMagazynie m = new("A01", "C431", "43");
            Produkt p = new("3429842343223", "Pomidor", "Warzywa", m);
            Produkt p2 = new("300432", "Jablko", "Owoce", m);
            Produkt p3 = new("6453543", "Sofa", "Meble", m);
            Produkt p4 = new("111111102", "Komputer", "Elektronika", m);
            WyswietlProdukty(ListaProduktow.lista);
        }

        private void txtWyszukaj_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            List<Produkt>? wyszukaneProdukty = ListaProduktow.Wyszukaj(metodaWyszukiwania, txtWyszukaj.Text);
            if (wyszukaneProdukty == null) return;
            itmKatalog.Items.Clear();
            WyswietlProdukty(wyszukaneProdukty);
        }

        private void WyswietlProdukty(List<Produkt> produkty)
        {
            itmKatalog.Items.Clear();
            if (produkty.Count == 0)
            {
                txtBrakWyszukanych.Visibility = Visibility.Visible;
                rtgBrakWyszukanych.Visibility = Visibility.Visible;
            }
            else
            {
                txtBrakWyszukanych.Visibility = Visibility.Hidden;
                rtgBrakWyszukanych.Visibility = Visibility.Hidden;
            }
            dic.Clear(); 
            foreach (Produkt p in produkty)
            {
                Button b = new();
                b.Click += ProduktKlikniety;
                dic.Add(b, p);

                Grid grid = new();
                ProduktControl pc = new();
                dic2.Add(b, pc);

                pc.NazwaProduktu = p.nazwa;
                pc.KodEAN = p.kodEAN;
                pc.Margin = new Thickness(0, 10, 0, 10);
                grid.Children.Add(pc);
                grid.Children.Add(b);
                itmKatalog.Items.Add(grid);
            }
        }

        private void cmbTrybWyszukiwania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbTrybWyszukiwania.SelectedIndex)
            {
                case 0:
                    metodaWyszukiwania = "nazwa";
                    return;
                case 1:
                    metodaWyszukiwania = "EAN";
                    return;
                default:
                    return;
            }
        }

        private void ProduktKlikniety(object sender, RoutedEventArgs e)
        {
            Button? przyciskProduktu = sender as Button;
            if (przyciskProduktu == null) return;
            Produkt obiektProduktu = dic[przyciskProduktu];
            ProduktControl kontrolkaProduktu = dic2[przyciskProduktu];
            foreach(var pc in dic2)
            {
                if(pc.Value.Tlo)
                {
                    pc.Value.Tlo = false;
                }
            }
            kontrolkaProduktu.Tlo = !kontrolkaProduktu.Tlo;
            WyswietlInformacjeOProdukcie(obiektProduktu);
        }

        private void WyswietlInformacjeOProdukcie(Produkt p)
        {

        }

        private void wndGlowne_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            txtKatalogTytul.FontSize = wndGlowne.ActualWidth / 40;
            txtInformacjeTytul.FontSize = wndGlowne.ActualWidth / 40;
        }
    }
}