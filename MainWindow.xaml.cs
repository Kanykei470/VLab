using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VLab.Views;

namespace VLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Server=DROPSOFJUPITER;Database=VirtualLab;Trusted_Connection=True;TrustServerCertificate=True;";

        public MainWindow()
        {
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Name FROM [Group]";
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



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fullname = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (VerifyUserCredentials(fullname, password))
            {
                var mainMenu = new MainMenu(fullname);
                mainMenu.Show();
            }
            else if (fullname=="Имя" || string.IsNullOrEmpty(password))
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
            int group = GetGroupIdFromDatabase(comboBox.Text);



            if (string.IsNullOrEmpty(fullname) || string.IsNullOrEmpty(password)|| comboBox.Text==null)
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
            RegistrationAction(fullname, password, email, group);

        }

        private int GetGroupIdFromDatabase(string groupName)
        {
            int groupId = 0;

            string query = "SELECT id_Group FROM [Group] WHERE Name = @GroupName";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GroupName", groupName);

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
                        throw new Exception("Не удалось получить идентификатор (id) для выбранной группы.");
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool VerifyUserCredentials(string fullname, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Students WHERE Full_Name = @fullname AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void RegistrationAction(string fullname, string password,string email, int group)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Students (Full_Name, Password, Email,id_Group) VALUES " +
                                                    "(@fullname, @password, @email, @group)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@fullname", fullname);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@group", group);

                command.ExecuteNonQuery();

                MessageBox.Show("Студент успешно зарегистрирован.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистка полей ввода
                UserName.Text = string.Empty;
                PasswordTextBox.Password = string.Empty;
                Email.Text = string.Empty;
                comboBox.SelectedItem = null;

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
    }
}
