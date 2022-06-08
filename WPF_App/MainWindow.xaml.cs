using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_App
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonDostawy(object sender, RoutedEventArgs e)
        {
            Dostawy dostawy = new Dostawy();
            this.Visibility = Visibility.Hidden;
            dostawy.Show();

        }

        private void ButtonStanMagazynu(object sender, RoutedEventArgs e)
        {
            StanMagazynu stan = new StanMagazynu();
            this.Visibility = Visibility.Hidden;
            stan.Show();
        }

        private void ButtonDostawcy(object sender, RoutedEventArgs e)
        {
            Dostawcy dostawcy = new Dostawcy();
            this.Visibility = Visibility.Hidden;
            dostawcy.Show();
        }
        private void ButtonZamowienia(object sender, RoutedEventArgs e)
        {
            Zamowienia zamowienia= new Zamowienia();
            this.Visibility = Visibility.Hidden;
            zamowienia.Show();
        }
    }
}
