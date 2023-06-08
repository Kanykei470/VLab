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

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for TeacherMenu.xaml
    /// </summary>
    public partial class TeacherMenu : Window
    {
        public TeacherMenu()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_Materials(object sender, MouseButtonEventArgs e)
        {
            TeacherMaterials main = new TeacherMaterials();
            main.Show();
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TeacherAllLabs allLabs = new TeacherAllLabs();
            allLabs.Show();
            this.Close();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            TeacherAllStudents allStudents = new TeacherAllStudents();
            allStudents.Show();
            this.Close();
        }
    }
}
