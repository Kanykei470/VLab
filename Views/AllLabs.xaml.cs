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
using VLab.Models;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for AllLabs.xaml
    /// </summary>
    public partial class AllLabs : Window
    {
        public AllLabs()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //MainMenu menu = new MainMenu("123");
            //menu.Show();
            //this.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            DustWindow dust = new DustWindow();
            dust.Show();
            Close();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            GasWindow dust = new GasWindow();
            dust.Show();
            Close();
        }
    }
}
