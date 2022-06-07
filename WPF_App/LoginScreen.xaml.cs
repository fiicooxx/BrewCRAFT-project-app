using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WPF_App
{
    /// <summary>
    /// Logika interakcji dla klasy LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // --- Filip ---

            //SqlConnection connection = new SqlConnection
            //    (@"Data Source=...;Initial Catalog=...;Integrated Security=True");

            // --- Sebastian ---

            //SqlConnection connection = new SqlConnection
            //   (@"Data Source=...;Initial Catalog=...;Integrated Security=True");


        }
    }

}