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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace UserConrols
{
    [ContentProperty("FileName")]
    /// <summary>
    /// Interaction logic for FileInputBox.xaml
    /// </summary>
    public partial class FileInputBox : UserControl
    {
        public FileInputBox()
        {
            InitializeComponent();
            TheTextBox.TextChanged += TheTextBox_TextChanged;

        }


        public static readonly DependencyProperty FileNameProperty=DependencyProperty.Register("FileName",typeof(string),typeof(FileInputBox));

        public static readonly RoutedEvent FileNameChangedEvent = EventManager.RegisterRoutedEvent("FileNameChanged",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileInputBox));

        private void TheTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(FileNameChangedEvent));
        }

        public string FileName
        {
            get { return (string) GetValue(FileNameProperty);}
            set { SetValue(FileNameProperty,value); }
        }

        //public event EventHandler<EventArgs> FileNameChanged;

        private void TheButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == true) // Result could be true, false, or null

            {
                this.FileName = d.FileName;
                //TheTextBox.Text = d.FileName;
            }
        }


        //Регистратор событий
        public event RoutedEventHandler FileNameChanged
        {
            add
            {
                this.AddHandler(FileNameChangedEvent, value);
            }
            remove
            {
                RemoveHandler(FileNameChangedEvent,value);
            }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
                throw new InvalidOperationException("You can't change Content!");
        }
    }
}
