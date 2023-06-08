using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Word;
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
using VLab.Models;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for TeacherMaterials.xaml
    /// </summary>
    public partial class TeacherMaterials : System.Windows.Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";
        public TeacherMaterials()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT id_Materials,Name,Material FROM Materials";
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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Description FROM LabWorks";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string groupName = reader.GetString(0);
                    comboBox.Items.Add(groupName);
                }

                reader.Close();
            }
        }

        private void Update_Btn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)DataGrid.SelectedItems[0];
            DataRow dataRow = selectedRow.Row;
            Material material = new Material
            {
                // Инициализируйте свойства вашей модели данных на основе значений в dataRow
                Name = dataRow["Name"].ToString(),
                Material1 = dataRow["Material"].ToString(),
                IdMaterials = (short)Convert.ToInt32(dataRow["id_Materials"])
            };

            // Далее используйте объект material по вашему усмотрению

            int selectedId = material.IdMaterials;// Предположим, что у вас есть поле Id в модели данных


            string query = "DELETE FROM Materials WHERE id_Materials = @selectedId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@selectedId", selectedId);
                connection.Open();
                command.ExecuteNonQuery();
            }


        }

        private void Update_Btn_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT id_Materials,Name,Material FROM Materials";
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

        private void Upload_Btn_Click(object sender, RoutedEventArgs e)
        {
            string nameOfFile = NameOfFile.Text;
            string pathf = Path.Text;
            int group = GetGroupIdFromDatabase(comboBox.Text);



            if (string.IsNullOrEmpty(nameOfFile) || string.IsNullOrEmpty(pathf) || comboBox.Text == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
         
           
            RegistrationAction(nameOfFile, pathf, group);
        }

        private void RegistrationAction(string fullname, string pathf, int group)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Materials (Name,Material ,id_LabWork) VALUES " +
                                                    "(@fullname, @pathf,@group)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname);
                command.Parameters.AddWithValue("@pathf", pathf);
                command.Parameters.AddWithValue("@group", group);

                command.ExecuteNonQuery();

                MessageBox.Show("Файл успешно загружен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистка полей ввода
                NameOfFile.Text = string.Empty;
                Path.Text = string.Empty;
              comboBox.SelectedItem = null;

            }
        }

        private int GetGroupIdFromDatabase(string description)
        {
            int groupId = 0;

            string query = "SELECT id_LabWork FROM LabWorks WHERE Description = @description";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@description", description);

                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out groupId))
                    {
                        // Успешно получен идентификатор (id) для выбранной группы
                        return groupId;
                    }
                    else
                    {
                        // Обработка ошибки, если идентификатор (id) не был получен
                        // Можно выбрать подходящий вариант, например, выбросить исключение или вернуть значение по умолчанию
                        MessageBox.Show("Не удалось получить идентификатор (id) для выбранной группы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return groupId;
                    }
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TeacherMenu menu = new TeacherMenu();
            menu.Show();
            this.Close();
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
                //LoadWordFile("D:\\VLab\\Resourses\\" + filePath);
                LoadWordFile(filePath);
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

        private void Path_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.docx";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Path.Text=filePath;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Clear();
        }
    }
}
