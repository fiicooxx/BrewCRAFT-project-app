using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logika interakcji dla klasy Dostawy.xaml
    /// </summary>
    public partial class Dostawy : Window
    {
        public Dostawy()
        {
            InitializeComponent();
        }

        private void ButtonStronaGłówna(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = string.Empty;
            box.Foreground = Brushes.Black;
            box.GotFocus -= TextBox_GotFocus;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "...";
                box.Foreground = Brushes.LightGray;
                box.GotFocus += TextBox_GotFocus;
            }
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            // --- Filip ---

            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-FOQ5J3H;Initial Catalog=Magazyn;Integrated Security=True");

            // --- Sebastian ---

            // SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-A0MV0IO4;Initial Catalog=Magazyn;Integrated Security=True");

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "INSERT INTO Dostawy VALUES("
                    + this.txtpiwoid.Text + ","
                    + this.txtdostawcaid.Text + ","
                    + "'" +this.txtdata.Text + "',"
                    + this.txtilosc.Text + ","
                    + this.txtstatus.Text + ")";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully added!");
                Refresh();
                        
            }
            catch (Exception)
            {
                MessageBox.Show("Make sure values are correct!");
            }
            finally
            {
                connection.Close();
            }
        }
        private void Refresh()
        {
            // method that refreshes window
            // updating or removing
            MainWindow refresh = new MainWindow();
            Application.Current.MainWindow = refresh;
            refresh.Show();
            this.Close();
        }
    }
}
