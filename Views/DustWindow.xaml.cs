using DocumentFormat.OpenXml.InkML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using VLab.Models;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for DustWindow.xaml
    /// </summary>
    public partial class DustWindow : Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        DispatcherTimer timer = new DispatcherTimer();

        public int count = 0;
        double weight = 0.001;
        Student student;
        public DustWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT * FROM Dust";
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
            Random random = new Random();
            Temp.Content = (random.Next(10, 30)).ToString();
            Weight.Content = 0.00;



        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            // Установите интервал таймера
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
          
           
            //}
            timer.Start();



            
            Filter.Background = Brushes.White;
            Filter.Name = "Filter"; // Устанавливаем идентификатор элемента
            // Добавляем canvas2 на страницу

            // Применяем анимацию к нужному канвасу
            ApplyAnimationToCanvas(Filter);

        }

        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Weight.Content = weight.ToString();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                Random random = new Random();

                // Генерация случайного размера кружка

                int diameter = random.Next(1, 6);

                // Создание Ellipse с заданным размером
                Ellipse ellipse = new Ellipse();
                ellipse.Width = diameter;
                ellipse.Height = diameter;
                ellipse.Fill = Brushes.SandyBrown;

                // Генерация случайных координат для размещения кружка
                double maxX = circlePanel.ActualWidth - diameter;
                double maxY = circlePanel.ActualHeight - diameter;

                double x = random.NextDouble() * maxX;
                double y = random.NextDouble() * maxY;

                // Установка позиции кружка на панели Canvas
                System.Windows.Controls.Canvas.SetLeft(ellipse, x);
                System.Windows.Controls.Canvas.SetTop(ellipse, y);

                // Добавление кружка на панель Canvas
                circlePanel.Children.Add(ellipse);
            }
            count++;
            Time.Content = count.ToString();
            weight = (count * 0.014);
        }
        private void ApplyAnimationToCanvas(System.Windows.Controls.Canvas canvas)
        {
            // Создаем анимацию цвета фона
            var colorAnimation = new ColorAnimation();
            colorAnimation.From = Colors.White;
            colorAnimation.To = Colors.Brown;
            colorAnimation.Duration = TimeSpan.FromSeconds(40);

            // Создаем трансляцию
            var brush = new SolidColorBrush(Colors.White);
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            // Применяем анимацию к указанному канвасу
            canvas.Background = brush;
        }
    }
}
