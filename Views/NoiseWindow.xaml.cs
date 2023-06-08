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

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for NoiseWindow.xaml
    /// </summary>
    public partial class NoiseWindow : System.Windows.Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        
        public NoiseWindow()
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

           
            LoadWordFile("D:\\VLab\\Resourses\\Шум.docx");
        }

        private void LoadWordFileButton_Click(object sender, RoutedEventArgs e)
        {
           
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
            MainMenu menu = new MainMenu("123");
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
            mediaElement2.Volume = volume/1000;
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
            // Откройте соединение
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
