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
    /// Interaction logic for LoginScreen.xaml
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

            //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-FOQ5J3H;Initial Catalog=Magazyn;Integrated Security=True");

            // --- Sebastian ---

            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-A0MV0IO4;Initial Catalog=Magazyn;Integrated Security=True");
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                // runs a query on connected database
                string loginQuery = "SELECT (1) FROM DaneLogowania WHERE Login = @Login AND Haslo = @Haslo";
                SqlCommand command = new SqlCommand(loginQuery, connection);


                // declaring scalar variables
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Login", txtlogin.Text);
                command.Parameters.AddWithValue("@Haslo", passbox.Password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                // if the returned value equals 1 it means it matches the databsae record
                // --> then move to the next window
                if (count == 1)
                {
                    MainWindow BreweryControlPanel = new MainWindow();
                    BreweryControlPanel.Show();

                    // closing login screen
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid login or password!");
                }
            }
            catch (Exception ex)
            {
                //TODO: Messagebox icon
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // closes the app
                connection.Close();
            }
        }
    }

}