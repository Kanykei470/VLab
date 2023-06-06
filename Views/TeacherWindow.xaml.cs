using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        public TeacherWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fullname = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (VerifyUserCredentials(fullname, password))
            {
                var mainMenu = new MainMenu(fullname);
                mainMenu.Show();
                Close();
            }
            else if (fullname == "Имя" || string.IsNullOrEmpty(password))
            {
                ErrorTextBox.Content = "Пожалуйста, заполните все поля.";
            }
            else
            {
                ErrorTextBox.Content = "Неправильно были введены данные!";
            }

        }


        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string fullname = UserName.Text;
            string password = textBox2.Password;
            string email = Email.Text;
          



            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя и пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать как минимум 6 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool isValid = IsValidEmail(email);

            if (!isValid)
            {
                MessageBox.Show("Недействительный адрес электронной почты.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            RegistrationAction(fullname, password, email);

        }

        private bool VerifyUserCredentials(string fullname, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Teachers WHERE Full_Name = @fullname AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void RegistrationAction(string fullname, string password, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Teachers (Full_Name, Password, Email) VALUES " +
                                                    "(@fullname, @password, @email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);


                command.ExecuteNonQuery();

                MessageBox.Show("Преподаватель успешно зарегистрирован.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистка полей ввода
                UserName.Text = string.Empty;
                textBox2.Password = string.Empty;
                Email.Text = string.Empty;
 
            }
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[\w\.-]+@([\w-]+\.)+[\w-]{2,4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }


        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }


    }
}
