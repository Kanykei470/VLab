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
//using Microsoft.Office.Interop.Word;

namespace VLab.Views
{
    /// <summary>
    /// Interaction logic for ResoursesWindow.xaml
    /// </summary>
    public partial class ResoursesWindow : System.Windows.Window
    {
        public ResoursesWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void Upload_Btn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                MessageBox.Show(filePath);
                LoadWordFile(filePath);
            }
        }


        private void LoadWordFile(string filePath)
        {
            //Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc = word.Documents.Open(filePath);
            //string text = doc.Content.Text;
            //word.Quit();
            //MessageBox.Show(text);
            // Далее можно обработать текст или отобразить его в приложении
        }
    }
}
