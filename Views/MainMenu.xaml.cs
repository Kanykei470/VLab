using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        Student student;
        public MainMenu(Student student)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            this.student = student;

        }
       

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            //user.Equals(name);
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            Information info = new Information();
            info.Show();
            Close();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            Question help = new Question();
            help.Show();
            Close();

        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
            Close();
        }

        private void materials_Click(object sender, RoutedEventArgs e)
        {
            ResoursesWindow resourses = new ResoursesWindow();
            resourses.Show();
            Close();
        }

        private void labs_Click(object sender, RoutedEventArgs e)
        {
            AllLabs labs = new AllLabs(student);
            labs.Show();
            Close();
        }

        private void Border_noise(object sender, MouseButtonEventArgs e)
        {
            //this.student = student;
            NoiseWindow noise = new NoiseWindow(student);
            noise.Show();
            Close();
        }

        private void Border_lights(object sender, MouseButtonEventArgs e)
        {
            //this.student = student;
            IlluminationWindow lights = new IlluminationWindow(student);
            lights.Show();
            Close();
        }

        private void Border_microclimat(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_electrisity(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
