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
        }

        private bool tlo;

        public bool Tlo
        {
            get { return tlo; }
            set { tlo = value;
            if(!tlo)
                {
                    rtgTlo.Fill = Brushes.Transparent;
                } else
                {
                    rtgTlo.Fill = Brushes.Red;
                }
            }
        }

        private string nazwaProduktu;
        public string NazwaProduktu
        {
            get { return nazwaProduktu; }
            set { nazwaProduktu = value;
                txtNazwa.Content = value;
            }
        }
        private string kodEAN;

        public string KodEAN
        {
            get { return kodEAN; }
            set { kodEAN = value;
                txtEAN.Content = value;
            }
        }

        private void wndProdukt_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            txtNazwa.FontSize = Math.Round(wndProdukt.ActualWidth / 10);
            txtEAN.FontSize = Math.Round(wndProdukt.ActualWidth / 15);
            txtNazwaTytul.FontSize = Math.Round(wndProdukt.ActualWidth / 40);
            txtEANTytul.FontSize = Math.Round(wndProdukt.ActualWidth / 40);
        }
    }
}
