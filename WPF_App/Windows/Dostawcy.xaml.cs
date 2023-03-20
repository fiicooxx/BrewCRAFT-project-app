﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
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
    /// Logika interakcji dla klasy Dostawcy.xaml
    /// </summary>
    public partial class Dostawcy : Window
    {
        public Dostawcy()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(Helper.connection);
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            
        }

        private void ButtonStronaGłówna(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void Odśwież_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                connection.Open();
                string query = "select ID, Nazwa, Miasto, Telefon, Email from Dostawcy ";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable("Dostawcy");
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
