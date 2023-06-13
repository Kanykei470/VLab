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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Name FROM Gasses";
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



            string selectedValue = comboBox.SelectedItem.ToString(); // Получаем выбранное значение из комбобокса

            string query = "SELECT id_Gases FROM Gasses WHERE Name = @name"; // Замените YourTable на имя вашей таблицы
            int id;

           
            using (SqlConnection connection = new SqlConnection(connectionString)) // Замените connectionString на вашу строку подключения
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", selectedValue);

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out id))
                    {
                        // Шаг 2: Использование ID для извлечения названия из другой таблицы

                        string nameQuery = "SELECT Name FROM Gas_Colors WHERE id_Gas_Colors = @id"; // Замените AnotherTable на имя вашей другой таблицы
                        string name;

                        using (SqlCommand nameCommand = new SqlCommand(nameQuery, connection))
                        {
                            nameCommand.Parameters.AddWithValue("@id", id);

                            object nameResult = nameCommand.ExecuteScalar();
                            if (nameResult != null)
                            {
                                name = nameResult.ToString();
                                ApplyAnimationToCanvas(Filter, name);
                                ColorBefore.Content = "white";
                                ColorAfter.Content = name;
                                PDK.Content = CalculatePDK(id);
                            }
                        }
                    }
                }
            }


        }

        public int CalculatePDK(int id)
        {
            switch (id)
            {
                case 1: return 200;
                case 2: return 20;
                case 3: return 20;
                case 4: return 100;
                case 5: return 20;
                case 6: return 20;
                case 7: return 100;
                case 8: return 20;
                case 9: return 5;
                case 10: return 10;
                case 11: return 50;
                case 12: return 300;
                case 13: return 1;
                case 14: return 1000;
                default:return 0;
            }

        }


        private void Button_Stop(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Random random = new Random();
            Air.Content = random.Next(200, 400).ToString();
            C.Content = random.Next(10, 1000).ToString();




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
            
           

        }


        private void ApplyAnimationToCanvas(System.Windows.Controls.Canvas canvas,string colorName)
        {
            colorAnimation = new ColorAnimation();
            colorAnimation.From = Colors.White;
            string colors =  colorName;
            Color color = (Color)ColorConverter.ConvertFromString(colors); // Преобразуем строку в объект Color



            colorAnimation.To = color;
            colorAnimation.Duration = TimeSpan.FromSeconds(30);

            brush = new SolidColorBrush(Colors.White);
            brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);

            Filter.Background = brush;
        }

        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrEmpty(Temp.ToString()) || string.IsNullOrEmpty(Time.ToString()) ||
            //   string.IsNullOrEmpty(weight.ToString()) || string.IsNullOrEmpty(Pressure.ToString()) ||
            //   string.IsNullOrEmpty(Air_Through_Rotameter.ToString())
            //   )
            //{
            //    MessageBox.Show("Не все результаты получены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            //////ПРОВЕРКА ДАННЫХ НА ОГРАГИЧЕНИЯ
            //////if (string.IsNullOrEmpty(g63.Text) || string.IsNullOrEmpty(g125.Text) ||
            //////  string.IsNullOrEmpty(g250.Text) || string.IsNullOrEmpty(g500.Text) ||
            //////  string.IsNullOrEmpty(g1000.Text) || string.IsNullOrEmpty(g2000.Text) ||
            //////  string.IsNullOrEmpty(g4000.Text) || string.IsNullOrEmpty(g8000.Text)
            //////  )
            //////{
            //////    MessageBox.Show("Не все результаты получены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //////    return;
            //////}


            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    Random random = new Random();
            //    int temp1 = Convert.ToInt16(Temp.Content.ToString());
            //    double time = Convert.ToDouble(Time.Content.ToString());
            //    double weight2 = Convert.ToDouble(weight.ToString());
            //    double weight1 = Convert.ToDouble(0.00.ToString());
            //    double pressure1 = Convert.ToDouble(Pressure.Content.ToString());
            //    double Air_Through_Rotameter1 = Convert.ToDouble(Air_Through_Rotameter.Content.ToString());
            //    double Volume_Of_Air_Through_Filter = Air_Through_Rotameter1 * time;
            //    double Volume_Of_Air_Reduced_To_Standard1 = (Volume_Of_Air_Through_Filter * 273 * pressure1) / (760 * (273 + time) * 1000);
            //    double K = (weight2 - weight1) / Volume_Of_Air_Reduced_To_Standard1;
            //    double PDK = random.Next(0, 10);




            //    string query = "UPDATE Dust SET Temperature_in_room = @temp1, Barometric_Pressure = @pressure1," +
            //        "Filter_Weight_Before = @weight1, Filter_Weight_After = @weight2, " +
            //        "Air_Through_Rotameter = @Air_Through_Rotameter1, Measurement_Time = @time," +
            //        "Volume_Of_Air_Through_Filter = @Volume_Of_Air_Through_Filter, Volume_Of_Air_Reduced_To_Standard = @Volume_Of_Air_Reduced_To_Standard1," +
            //        "Dust_Concentration_In_Air = @K ," +
            //        "Max_Allowable_Concentration_Of_Dust = @PDK WHERE id_num_of_test = 1";

            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        try
            //        {
            //            connection.Open();
            //            // Устанавливаем значения параметров в запросе
            //            command.Parameters.AddWithValue("@temp1", temp1);
            //            command.Parameters.AddWithValue("@pressure1", pressure1);
            //            command.Parameters.AddWithValue("@weight1", weight1);
            //            command.Parameters.AddWithValue("@weight2", weight2);
            //            command.Parameters.AddWithValue("@Air_Through_Rotameter1", Air_Through_Rotameter1);
            //            command.Parameters.AddWithValue("@time", time);
            //            command.Parameters.AddWithValue("@Volume_Of_Air_Through_Filter", Volume_Of_Air_Through_Filter);
            //            command.Parameters.AddWithValue("@Volume_Of_Air_Reduced_To_Standard1", Volume_Of_Air_Reduced_To_Standard1);
            //            command.Parameters.AddWithValue("@K", K);
            //            command.Parameters.AddWithValue("@PDK", PDK);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }


            //        // Выполняем обновление данных
            //        command.ExecuteNonQuery();
            //        connection.Close();

            //        MessageBox.Show("Были произведены расчеты", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
    }
}
