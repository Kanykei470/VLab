using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
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
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using Table = Microsoft.Office.Interop.Word.Table;

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
            //Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    string filePath = openFileDialog.FileName;
            //    MessageBox.Show(filePath);
            //    LoadWordFile(filePath);
            //}


            //Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            //openFileDialog.Filter = "Word Documents|*.docx";
            //if (openFileDialog.ShowDialog() == true)
            //{
            //    string filePath = openFileDialog.FileName;
            //    LoadWordFile(filePath);
            //}
        }


        private void LoadWordFile(string filePath)
        {
            //DataTable.Columns.Clear();
            //DataTable.Items.Clear();

            //Application wordApplication = new Application();
            //Microsoft.Office.Interop.Word.Document wordDocument = wordApplication.Documents.Open(filePath);

            //foreach (Table table in wordDocument.Tables)
            //{
            //    System.Windows.Documents.TableRow headerRow = (System.Windows.Documents.TableRow)table.Rows[1];
            //    if (headerRow != null)
            //    {
            //        foreach (Microsoft.Office.Interop.Word.Cell cell in headerRow.Cells)
            //        {
            //            string headerText = cell.Range.Text.Trim();
            //            DataTable.Columns.Add(new DataGridTextColumn { Header = headerText });
            //        }
            //    }

            //    for (int i = 2; i <= table.Rows.Count; i++)
            //    {
            //        System.Windows.Documents.TableRow row = (System.Windows.Documents.TableRow)table.Rows[i];
            //        List<string> rowData = new List<string>();

            //        foreach (Microsoft.Office.Interop.Word.Cell cell in row.Cells)
            //        {
            //            string cellText = cell.Range.Text.Trim();
            //            rowData.Add(cellText);
            //        }

            //        DataTable.Items.Add(rowData);
            //    }
            //}

            //wordDocument.Close();
            //wordApplication.Quit();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu("123");
            menu.Show();
            this.Close();
        }
    }
}
