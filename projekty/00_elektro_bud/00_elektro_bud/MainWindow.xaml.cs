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
            MiejsceWMagazynie m1 = new("B432", "C01", "08");
            MiejsceWMagazynie m2 = new("G002", "C01", "08");
            MiejsceWMagazynie m3 = new("E042", "E05", "99");
            Produkt p = new("3429842343223", "Pomidor", "Warzywa", m);
            Produkt p2 = new("300432", "Jablko", "Owoce", m1);
            Produkt p3 = new("6453543", "Sofa", "Meble", m2);
            Produkt p4 = new("111111102", "Komputer", "Elektronika", m3);
            WyswietlProdukty(ListaProduktow.lista);
            WyswietlInformacjeOProdukcie(null);
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
                if (pc.Key == przyciskProduktu) continue;
                if(pc.Value.Tlo)
                {
                    pc.Value.Tlo = false;
                }
            }
            kontrolkaProduktu.Tlo = !kontrolkaProduktu.Tlo;
            WyswietlInformacjeOProdukcie(obiektProduktu, !kontrolkaProduktu.Tlo);
        }

        private void WyswietlInformacjeOProdukcie(Produkt? p, bool czyWybrany = false)
        {
            if(p == null || czyWybrany)
            {
                txtBrakWybranego.Visibility = Visibility.Visible;
                rtgBrakWybranego.Visibility = Visibility.Visible;
                txtNazwa.Text = "";
                txtEAN.Text = "";
                txtKategoria.Text = "";
                txtSektor.Text = "";
                txtRegal.Text = "";
                txtPolka.Text = "";
                txtL1.Visibility = Visibility.Hidden;
                txtL2.Visibility = Visibility.Hidden;
                txtL3.Visibility = Visibility.Hidden;
                txtL4.Visibility = Visibility.Hidden;
                return;
            }
            txtNazwa.Text = p.nazwa;
            txtEAN.Text = p.kodEAN;
            txtKategoria.Text = p.kategoria;
            txtSektor.Text = "Sektor: " + p.miejscePrzechowania.sektor;
            txtRegal.Text = "Regał: " + p.miejscePrzechowania.regal;
            txtPolka.Text = "Półka: " + p.miejscePrzechowania.polka;

            txtL1.Visibility = Visibility.Visible;
            txtL2.Visibility = Visibility.Visible;
            txtL3.Visibility = Visibility.Visible;
            txtL4.Visibility = Visibility.Visible;

            txtBrakWybranego.Visibility = Visibility.Hidden;
            rtgBrakWybranego.Visibility = Visibility.Hidden;
        }

        private void wndGlowne_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            txtKatalogTytul.FontSize = wndGlowne.ActualWidth / 40;
            txtInformacjeTytul.FontSize = wndGlowne.ActualWidth / 40;
        }
    }
}