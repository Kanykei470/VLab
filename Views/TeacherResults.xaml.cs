using Prism.Services.Dialogs;
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

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for TeacherResults.xaml
    /// </summary>
    public partial class TeacherResults : Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        public TeacherResults()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT * FROM TeacherResults";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                // Создайте объект SqlDataAdapter для извлечения данных из базы данных
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Создайте объект DataTable для хранения результирующих данных
                System.Data.DataTable dataTable = new System.Data.DataTable();

                // Заполните DataTable данными из базы данных
                adapter.Fill(dataTable);

                // Назначьте DataTable свойству ItemsSource вашего DataGrid
                DataGrid.ItemsSource = dataTable.DefaultView;

                // Закройте соединение
                connection.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TeacherMenu menu = new TeacherMenu();
            menu.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int id = 1;
                // Откройте соединение
                connection.Open();

                // Создайте команду SQL с параметром
                string query = "SELECT * FROM Levels_Of_Noise WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавьте параметр в команду
                    command.Parameters.AddWithValue("@id", id);

                    // Создайте адаптер данных для выполнения команды и получения результатов
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    // Создайте таблицу данных для хранения результатов
                    DataTable dataTable = new DataTable();
                    
                    // Заполните таблицу данными из адаптера
                    adapter.Fill(dataTable);

                    // Верните таблицу данных
                    
                    
                }
            }

        }
       



    }
}
