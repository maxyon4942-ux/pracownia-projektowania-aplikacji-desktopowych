using System.Windows;

namespace login
{   
    public partial class MainWindow : Window
    {
        //TODO - przeczytaj dokumentacje data bindings
        public string login { get; set; }
        private string pass { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(login);
        }
    }
}