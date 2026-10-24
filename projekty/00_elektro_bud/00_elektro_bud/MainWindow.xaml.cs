using System.Windows;

namespace _00_elektro_bud
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MiejsceWMagazynie m = new("A01", "C431", "43");
            Produkt p = new("34298423432", "Pomidor", "Warzywa", m);
        }
    }
}