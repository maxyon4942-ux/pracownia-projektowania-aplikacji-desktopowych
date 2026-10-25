using System.Windows;
using System.Windows.Controls;
using Brushes = System.Windows.Media.Brushes;

namespace _00_elektro_bud.View.UserControls
{
    public partial class ProduktControl : UserControl
    {
        public ProduktControl()
        {
            DataContext = this;
            InitializeComponent();

            nazwaProduktu = "Produkt";
            kodEAN = "0000000000000";
        }

        private bool tlo;

        public bool Tlo
        {
            get { return tlo; }
            set { tlo = value;
            if(!tlo)
                {
                    rtgTlo.Visibility = Visibility.Hidden;
                    brdRamka.Visibility = Visibility.Hidden;
                } else
                {
                    rtgTlo.Visibility = Visibility.Visible;
                    brdRamka.Visibility = Visibility.Visible;
                }
            }
        }

        private string nazwaProduktu;
        public string NazwaProduktu
        {
            get { return nazwaProduktu; }
            set { nazwaProduktu = value;
                txtNazwa.Text = value;
            }
        }
        private string kodEAN;

        public string KodEAN
        {
            get { return kodEAN; }
            set { kodEAN = value;
                txtEAN.Text = value;
            }
        }

        private void wndProdukt_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            txtNazwa.FontSize = Math.Round(wndProdukt.ActualWidth / 20);
            txtEAN.FontSize = Math.Round(wndProdukt.ActualWidth / 16);
            txtNazwaTytul.FontSize = Math.Round(wndProdukt.ActualWidth / 40);
            txtEANTytul.FontSize = Math.Round(wndProdukt.ActualWidth / 40);
        }
    }
}
