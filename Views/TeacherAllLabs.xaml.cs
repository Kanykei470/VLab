using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
    /// Interaction logic for TeacherAllLabs.xaml
    /// </summary>
    public partial class TeacherAllLabs : Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        public TeacherAllLabs()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            WindowState = WindowState.Maximized;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT * FROM LabWorks";
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
        public void OpenCalendar_Click(object sender, RoutedEventArgs e)
        {
            // Показать или скрыть календарь при нажатии на кнопку
            calendar.Visibility = calendar.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        public void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обработка выбранных дат
            DateTime startDate = calendar.SelectedDates.FirstOrDefault();
            DateTime endDate = calendar.SelectedDates.LastOrDefault();

            start.Text = startDate.ToString();
            end.Text = endDate.ToString();

            // Используйте startDate и endDate в соответствии с вашей логикой
        }

        private void Upload_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TeacherMenu teacher = new TeacherMenu();
            teacher.Show();
            this.Close();
        }
    }


}
