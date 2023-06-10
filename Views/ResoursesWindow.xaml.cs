using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Windows.Input;
using VLab.Models;
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for ResoursesWindow.xaml
    /// </summary>
    public partial class ResoursesWindow : System.Windows.Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";
        public ResoursesWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT * FROM ViewOfMaterials";
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
            DataGrid.MouseDoubleClick += DataGrid_MouseDoubleClick;

        }

             

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //MainMenu menu = new MainMenu("123");
            //menu.Show();
            //this.Close();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Получить выбранную строку
            DataRowView selectedRow = (DataRowView)DataGrid.SelectedItem;

            // Проверить, что строка не является null
            if (selectedRow != null)
            {
               string filePath = selectedRow.Row["Material"].ToString();
                // Открыть файл в Microsoft Word
                LoadWordFile("D:\\VLab\\Resourses\\" + filePath);
            }
        }

        private void LoadWordFile(string filePath)
        {
            try
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
                {
                    Body body = wordDoc.MainDocumentPart.Document.Body;
                    string content = body.InnerText;
                    TextBox.Text = content;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка загрузки файла: " + ex.Message);
            }
        }


    }
}
