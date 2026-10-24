using System.Windows.Controls;
using System.ComponentModel;

namespace _00_elektro_bud.View.UserControls
{
    public partial class ProduktControl : UserControl, INotifyPropertyChanged 
    {
        public ProduktControl()
        {
            DataContext = this;
            InitializeComponent();
        }
        private string titleOne;
        public string  TitleOne
        {
            get { return titleOne; }
            set { titleOne = value; }
        }
        private string titleTwo;
        public string TitleTwo
        {
            get { return titleTwo; }
            set { titleTwo = value; }
        }
        private string nameOne;
        public string NameOne
        {
            get { return nameOne; }
            set { nameOne = value; }
        }
        private string nameTwo;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string NameTwo
        {
            get { return nameTwo; }
            set { nameTwo = value; }
        }



    }
}
