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
using System.Threading;

namespace WPF_With_Async
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

        private void btnButton_Click(object sender, RoutedEventArgs e)
        {
            Task<int> tsk=Task<int>.Factory.StartNew(
                () =>
                {
                    Thread.Sleep(10000);
                    return 0;
                }
            
            );
            tbText.Text = tsk.Result.ToString();
            System.Diagnostics.Debug.WriteLine(tsk.Result);
        }

        private async void btnButton_Click2(object sender, RoutedEventArgs e)
        {
            tbText.Text = "Start";
            var res = await  Task<int>.Run(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        this.Dispatcher.Invoke(()=>tbText.Text = i.ToString());
                        Thread.Sleep(1000);
                    }

                    return 10;
                }
            );

            tbText.Text = res.ToString();
            //this.Dispatcher.Invoke(()=> tbText.Text = res.ToString());
            System.Diagnostics.Debug.WriteLine(res);
        }
    }
}
