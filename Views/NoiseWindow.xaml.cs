using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System.Windows.Xps.Packaging;
using System.Data.SqlClient;
using System.Diagnostics;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using VLab.Models;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for NoiseWindow.xaml
    /// </summary>
    public partial class NoiseWindow : System.Windows.Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        Student student;
        private TeacherResults teacherResults = new TeacherResults();

        public NoiseWindow(Student student)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT * FROM Levels_Of_Noise";
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

            this.student = student;


            LoadWordFile("D:\\VLab\\Resourses\\ИССЛЕДОВАНИЕ ПРОИЗВОДСТВЕННОГО ШУМА.docx");
        }



        private void LoadWordFile(string filePath)
        {
            //try
            //{
            //    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            //    {
            //        Body body = wordDoc.MainDocumentPart.Document.Body;
            //        string content = body.InnerText;
            //        TextBox.Text = content;
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show("Ошибка загрузки файла: " + ex.Message);
            //}
            //string filePath = "путь_к_вашему_файлу.docx";

            // Открыть файл в новом окне
            //Process.Start("WINWORD.EXE", filePath);
            ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
            startInfo.UseShellExecute = true;
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            Process.Start(startInfo);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu(student);
            menu.Show();
            this.Close();
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement2.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaElement2.Stop();
        }

        private void NameOfFile_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;
            int sliderValue = (int)slider.Value;
            g63.Text = sliderValue.ToString();

        }

        private void g125_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;

            int sliderValue = (int)slider.Value;
            g125.Text = sliderValue.ToString();
        }

        private void g250_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;

            int sliderValue = (int)slider.Value;
            g250.Text = sliderValue.ToString();
        }

        private void g500_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;

            int sliderValue = (int)slider.Value;
            g500.Text = sliderValue.ToString();
        }

        private void g8000_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;

            int sliderValue = (int)slider.Value;
            g8000.Text = sliderValue.ToString();
        }

        private void g4000_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;

            int sliderValue = (int)slider.Value;
            g4000.Text = sliderValue.ToString();
        }

        private void g2000_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;

            int sliderValue = (int)slider.Value;
            g2000.Text = sliderValue.ToString();
        }

        private void g1000_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Grid parentPanel = (Grid)textBox.Parent;
            Slider slider = volumeSlider2;

            int sliderValue = (int)slider.Value;
            g1000.Text = sliderValue.ToString();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int volume = (int)e.NewValue;
            mediaElement2.Volume = volume;
            //MessageBox.Show(mediaElement2.Volume.ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrEmpty(g63.Text) || string.IsNullOrEmpty(g125.Text) ||
                string.IsNullOrEmpty(g250.Text) || string.IsNullOrEmpty(g500.Text) ||
                string.IsNullOrEmpty(g1000.Text) || string.IsNullOrEmpty(g2000.Text) ||
                string.IsNullOrEmpty(g4000.Text) || string.IsNullOrEmpty(g8000.Text)
                )
            {
                MessageBox.Show("Не все результаты получены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //ПРОВЕРКА ДАННЫХ НА ОГРАГИЧЕНИЯ
            //if (string.IsNullOrEmpty(g63.Text) || string.IsNullOrEmpty(g125.Text) ||
            //  string.IsNullOrEmpty(g250.Text) || string.IsNullOrEmpty(g500.Text) ||
            //  string.IsNullOrEmpty(g1000.Text) || string.IsNullOrEmpty(g2000.Text) ||
            //  string.IsNullOrEmpty(g4000.Text) || string.IsNullOrEmpty(g8000.Text)
            //  )
            //{
            //    MessageBox.Show("Не все результаты получены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int g63Value = Convert.ToInt16(g63.Text);
                int g125Value = Convert.ToInt16(g125.Text);
                int g250Value = Convert.ToInt16(g250.Text);
                int g500Value = Convert.ToInt16(g500.Text);
                int g1000Value = Convert.ToInt16(g1000.Text);
                int g2000Value = Convert.ToInt16(g2000.Text);
                int g4000Value = Convert.ToInt16(g4000.Text);
                int g8000Value = Convert.ToInt16(g8000.Text);

                int lvlDBA = (g63Value + g125Value + g250Value + g500Value + g1000Value + g2000Value + g4000Value + g8000Value) / 8;

                string query = "UPDATE Levels_Of_Noise SET [63_lvl] = @g63Value, [125_lvl] = @g125Value," +
                                                           "[250_lvl] = @g250Value, [500_lvl] = @g500Value, " +
                                                           "[1000_lvl] = @g1000Value, [2000_lvl] = @g2000Value," +
                                                           "[4000_lvl] = @g4000Value, [8000_lvl] = @g8000Value, Level_Of_DBA = @lvlDBA WHERE id_Levels_Of_Noise = 1";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    // Устанавливаем значения параметров в запросе
                    command.Parameters.AddWithValue("@g63Value", g63Value);
                    command.Parameters.AddWithValue("@g125Value", g125Value);
                    command.Parameters.AddWithValue("@g250Value", g250Value);
                    command.Parameters.AddWithValue("@g500Value", g500Value);
                    command.Parameters.AddWithValue("@g1000Value", g1000Value);
                    command.Parameters.AddWithValue("@g2000Value", g2000Value);
                    command.Parameters.AddWithValue("@g4000Value", g4000Value);
                    command.Parameters.AddWithValue("@g8000Value", g8000Value);
                    command.Parameters.AddWithValue("@lvlDBA", lvlDBA);


                    // Выполняем обновление данных
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Были произведены расчеты", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            Charts.IsEnabled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string name = student.FullName; // Заданное имя, для которого нужно получить id
            int id = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_Students FROM Students WHERE Full_Name = @name";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    // Выполнение запроса и получение результата
                    object result = command.ExecuteScalar();

                    // Преобразование результата к нужному типу (например, int)
                    if (result != null && result != DBNull.Value)
                    {
                        id = Convert.ToInt32(result);
                        // Использование полученного id
                    }

                }
            }
            int labwork = 1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "INSERT INTO Results (id_Student, id_LabWork) VALUES (@id, @labwork)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@labwork", labwork);



                command.ExecuteNonQuery();

                MessageBox.Show("Результаты были отправлены", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT * FROM Levels_Of_Noise";
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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            int g63Value = Convert.ToInt16(g63.Text);
            int g125Value = Convert.ToInt16(g125.Text);
            int g250Value = Convert.ToInt16(g250.Text);
            int g500Value = Convert.ToInt16(g500.Text);
            int g1000Value = Convert.ToInt16(g1000.Text);
            int g2000Value = Convert.ToInt16(g2000.Text);
            int g4000Value = Convert.ToInt16(g4000.Text);
            int g8000Value = Convert.ToInt16(g8000.Text);
            ChartValues<ObservablePoint> chartData = new ChartValues<ObservablePoint>
            {
                new ObservablePoint(63 ,g63Value),
                new ObservablePoint(125 ,g125Value),
                new ObservablePoint(250 ,g250Value),
                new ObservablePoint(500 ,g500Value),
                new ObservablePoint(1000 ,g1000Value),
                new ObservablePoint(2000 ,g2000Value),
                new ObservablePoint(4000 ,g4000Value),
                new ObservablePoint(8000 ,g8000Value),
            };

            // Создание графика
            CartesianChart chart = new CartesianChart
            {
                Series = new LiveCharts.SeriesCollection
                {
                    new LineSeries { Values = chartData }
                }
            };

            // Создание окна
            System.Windows.Window chartWindow = new System.Windows.Window
            {
                Title = "График",
                Content = chart,
                Width = 600,
                Height = 400
            };

            // Открытие выплывающего окна
            chartWindow.ShowDialog();

        } 
      
    }

}