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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Utilites
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

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(
            () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(2000);
                    System.Diagnostics.Debug.WriteLine("Письмо отправлено!");
                }
            }
            );
        }

        //private void FileInputBox_OnFileNameChanged(object sender, EventArgs e)
        //{
        //    //System.Diagnostics.Debug.WriteLine("File changed!");

        //}

        private void FileInputBox_OnFileNameChanged(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File changed! In Grid");
        }
    }
}
