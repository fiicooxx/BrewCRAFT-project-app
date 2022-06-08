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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_App
{
    /// <summary>
    /// Logika interakcji dla klasy StanMagazynu.xaml
    /// </summary>
    public partial class StanMagazynu : Window
    {
        public StanMagazynu()
        {
            InitializeComponent();
        }

        private void ButtonStronaGłówna(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void Odśwież_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-A0MV0IO4;Initial Catalog=Magazyn;Integrated Security=True");
            try
            {
                connection.Open();
                string query = "select ID, Nazwa, Rodzaj, PuszkaButelka, Ilosc from StanMagazynu ";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable("StanMagazynu");
                adapter.Fill(table);

                datagrid.ItemsSource = table.DefaultView;

                adapter.Update(table);

                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
