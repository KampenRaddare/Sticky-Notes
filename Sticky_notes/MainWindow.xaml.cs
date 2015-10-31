using System;
using System.Windows;
using System.Diagnostics;
using Microsoft.Win32;

namespace Sticky_notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createNew_Click(object sender, RoutedEventArgs e)
        {
            // Opens new sticky
            MainWindow main = new MainWindow();

            main.Show();
        }

        private void CloseAll_Click(object sender, RoutedEventArgs e)
        {
            // Closes all stickies
            Environment.Exit(1);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Saves file (If you would want to)
            SaveFileDialog save = new SaveFileDialog();

            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            save.Filter = "Text File|*.txt";
            save.Title = "Save your sticky note as a text file.";
            save.ShowDialog();

            if (save.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)save.OpenFile();
                using (System.IO.StreamWriter write = new System.IO.StreamWriter(fs))
                {
                    write.Write(MainCanvas.Text);
                }

                fs.Close();
                MessageBox.Show("Your file has been saved.");
            }
        }
    }
}
