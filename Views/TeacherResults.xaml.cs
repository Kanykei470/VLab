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
                DataGrid1.ItemsSource = dataTable.DefaultView;

                // Закройте соединение
                connection.Close();
            }
            DataGrid1.MouseDoubleClick += DataGrid1_MouseDoubleClick;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TeacherMenu menu = new TeacherMenu();
            menu.Show();
            this.Close();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string query = "UPDATE Results SET YourField = @NewValue WHERE YourCondition = @Condition";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@NewValue", newValue);
                    //command.Parameters.AddWithValue("@Condition", condition);

                    // Откройте подключение к базе данных
                    connection.Open();

                    // Выполните команду обновления
                    command.ExecuteNonQuery();

                    // Закройте подключение к базе данных
                    connection.Close();
                }
            }

        }



        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

      

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Логика для обработки двойного нажатия на первый DataGrid
            // Например, обновление данных или вывод другой таблицы во втором DataGrid
            // ...

            // Пример обновления данных во втором DataGrid
            DataGrid2.ItemsSource = GetOtherTableData().DefaultView;
            // Подставьте здесь свою логику получения данных для второго DataGrid
        }

        private DataTable GetOtherTableData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int id = 1;
                connection.Open();

                string query = "SELECT * FROM Levels_Of_Noise WHERE id_Levels_Of_Noise = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }



    }
}
