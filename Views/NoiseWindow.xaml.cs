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

            LoadWordFile("D:\\VLab\\Resourses\\Шум.docx");
        }

        private void LoadWordFileButton_Click(object sender, RoutedEventArgs e)
        {
           
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu("123");
            menu.Show();
            this.Close();
        }


        //private void LoadWordFile(string filePath)
        //{
        //    DocumentViewer.Document = null;

        //    Application wordApp = new Application();
        //    Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Open(filePath);

        //    using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        wordDoc.SaveAs2(stream, WdSaveFormat.wdFormatXPS);
        //        stream.Position = 0;

        //        XpsDocument xpsDoc = new XpsDocument(stream);
        //        DocumentViewer.Document = xpsDoc.GetFixedDocumentSequence();
        //    }

        //    wordDoc.Close();
        //    wordApp.Quit();
        //}

        private void StartMeasurement_Click(object sender, RoutedEventArgs e)
        {
            // Обработчик события нажатия кнопки "Начать измерение"

            //// Получить значения введенных данных (ток, напряжение генератора, напряжение измерения)
            //double current = Convert.ToDouble(CurrentTextBox.Text);
            //double voltageGen = Convert.ToDouble(VoltageGenTextBox.Text);
            //double voltageMeas = Convert.ToDouble(VoltageMeasTextBox.Text);

            //// Выполнить расчеты и обработку данных в соответствии с вашими формулами и логикой
            //double resistance = voltageMeas / current;

            //// Отобразить результаты измерений в интерфейсе
            //MessageBox.Show($"Сопротивление тела: {resistance} кОм");

            // Добавьте код для сохранения результатов в протокол наблюдений
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
