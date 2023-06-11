using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using VLab.Models;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for GasWindow.xaml
    /// </summary>
    public partial class GasWindow : Window
    {
        public string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        Student student;
        DispatcherTimer timer = new DispatcherTimer();
        public int count = 0;

        private SolidColorBrush brush;
        private ColorAnimation colorAnimation;

        public GasWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Откройте соединение
                connection.Open();

                // Выполните SQL-запрос
                string sqlQuery = "SELECT * FROM Gas";
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

        }

        private void Button_Start(object sender, RoutedEventArgs e)
        {
            if (timer != null)
            {
                // Если таймер уже существует, останавливаем его
                timer.Stop();
            }
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();




            Filter.Background = Brushes.White;
            Filter.Name = "Filter"; // Устанавливаем идентификатор элемента
            ApplyAnimationToCanvas(Filter);

        }

        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            //Weight.Content = weight.ToString();

            //Random random = new Random();
            //Pressure.Content = random.Next(748, 760).ToString();

            //Air_Through_Rotameter.Content = random.Next(10, 1000).ToString();
            //Volume_Of_Air_Reduced_To_Standard.Content= random.Next(10, 1000).ToString();

            if (brush != null && colorAnimation != null)
            {
                Color currentColor = ((SolidColorBrush)brush).Color;
                // Остановка анимации
                brush.BeginAnimation(SolidColorBrush.ColorProperty, null);

                // Получение текущего значения цвета фона и его присвоение
                //Color currentColor = ((SolidColorBrush)brush).Color;
                brush = new SolidColorBrush(currentColor);
                Filter.Background = brush;
            }


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
            count++;
            Time.Content = count.ToString();
            //weight = (count * 0.014);
        }


        private void ApplyAnimationToCanvas(System.Windows.Controls.Canvas canvas)
        {
            colorAnimation = new ColorAnimation();
            colorAnimation.From = Colors.White;
            colorAnimation.To = Colors.Red;
            colorAnimation.Duration = TimeSpan.FromSeconds(30);

            brush = new SolidColorBrush(Colors.White);
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            Filter.Background = brush;
        }
    }
}
