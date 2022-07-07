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
using System.Data;

namespace WPF_App
{
    /// <summary>
    /// Logika interakcji dla klasy Zamowienia.xaml
    /// </summary>
    public partial class Zamowienia : Window
    {
        public Zamowienia()
        {
            InitializeComponent();
            FillComboBox();
        }

        SqlConnection connection = new SqlConnection(Helper.connection);

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

        // -------------------------------------------------- //
        public void FillComboBox()
        {
            // here we are going to fill combobox with data
            // in our case it is ID of order


            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "SELECT ID FROM Dostawy";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // assign datasource to the combobox using datatable
                comboid.ItemsSource = table.DefaultView;
                comboid.DisplayMemberPath = "ID";

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong :(");
            }
            finally
            {
                connection.Close();
            }
        }

        // -------------------------------------------------- //
        private void FullCombo(object sender, EventArgs e)
        {
            // here we are going to fill rest of records 
            // relying on our ID

            

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = $"SELECT * FROM Dostawy WHERE ID = {comboid.Text}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    string piwoID = sqlDataReader.GetInt32(1).ToString();
                    string DostawcaID = sqlDataReader.GetInt32(2).ToString();
                    string DataZamowienia = sqlDataReader.GetDateTime(3).ToString();
                    string Ilosc = sqlDataReader.GetInt32(4).ToString();
                    string Status = sqlDataReader.GetInt32(5).ToString();

                    txtpiwoid.Text = piwoID;
                    txtdostawcaid.Text = DostawcaID;
                    txtdata.Text = DataZamowienia;
                    txtilosc.Text = Ilosc;
                    txtstatus.Text = Status;
                }

                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        // -------------------------------------------------- //
        private void Btnrmv_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "DELETE FROM Dostawy WHERE ID=" + this.comboid.Text;
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully removed");
                Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Ej, co jest?");
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

        // -------------------------------------------------- //
        private void btnchng_Click(object sender, RoutedEventArgs e)
        {
            // here we are going to update status of our order 
            // relying on our ID

           

            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string query = "UPDATE Dostawy SET StatusID = 1 WHERE ID =" + this.comboid.Text;
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();


                string querryStan = "UPDATE StanMagazynu SET Ilosc = StanMagazynu.Ilosc + Dostawy.Ilosc FROM StanMagazynu JOIN Dostawy ON StanMagazynu.ID = Dostawy.PiwoID WHERE Dostawy.ID =" + this.comboid.Text;
                SqlCommand commandStan = new SqlCommand(querryStan, connection);
                commandStan.ExecuteNonQuery();
                MessageBox.Show("Zamówienie zrealizowane!");
                Refresh();
            }
            catch (Exception)
            {
                MessageBox.Show("Ooops...");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
