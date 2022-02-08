using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Utilites.Commands;
using Utilites.ViewModels.Base;

namespace Utilites.ViewModels
{
    class MainViewModel: ViewModel, IDataErrorInfo
    {

        public MainViewModel()
        {
            MailSendCommand = new RelayCommand(OnMailSendCommandExecute, CanMailSendCommandExecute);
            CloseWindowCommand = new RelayCommand(OnCloseWindowCommandExecute, CanCloseWindowCommandExecute);
            ClosingCommand = new RelayCommand(OnClosingCommandExecute, CanClosingCommandExecute);
        }

        #region Свойства

        private string _FromSelectedItem;

        public string FromSelectedItem
        {
            get => _FromSelectedItem;
            set
            {
                Set(ref _FromSelectedItem, value);
                System.Diagnostics.Debug.WriteLine(value);
            }
        }


        private string _Title = "Mail Sender. Created by Ivanov (C)";

        public string Title
        {
            get => _Title;

            set
            {
                Set(ref _Title, value);
            }
        }

        private string _From = "mail@yandex.ru";

        public string From
        {
            get => _From;

            set
            {
                //if (value.Length > 10) throw new ArgumentOutOfRangeException("Превышена длина строки");
                Set(ref _From, value);
            }
        }

        private string _To = "mail2@yandex.ru";

        public string To
        {
            get => _To;

            set
            {
                if (value.Contains("!")) throw new ArgumentException("!!!!");
                else
                    Set(ref _To, value);
            }
        }

        private string _Group = "Group1";

        public string Group
        {
            get => _Group;

            set
            {
                Set(ref _Group, value);
            }
        }
        #endregion

        #region Команды

        #region Closing

        public ICommand ClosingCommand { get; }

        private void OnClosingCommandExecute(object o)
        {
            System.Diagnostics.Debug.WriteLine("Closing "+DateTime.Now);
        }

        private bool CanClosingCommandExecute(object p) => true;

        #endregion

        #region Mail Send

        public ICommand MailSendCommand { get; }

        private void OnMailSendCommandExecute(object o)
        {
            //Обращение к бизнес логике по выполнению действия
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

        private bool CanMailSendCommandExecute(object p) => true;

        #endregion


        #region Close Window Command

        public ICommand CloseWindowCommand { get; }

        private void OnCloseWindowCommandExecute(object o)
        {
            //Обращение к бизнес логике по выполнению действия
            Application.Current.Shutdown();
        }

        private bool CanCloseWindowCommandExecute(object p) => true;

        #endregion
        #endregion

        public string this[string columnName]
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("IDataError");
                Error=String.Empty;
                switch (columnName)
                {
                    case "Group":
                        if (Group.Length == 0 || Group.Length > 10) Error = "Длина группы";
                        break;
                    case "From":
                        if (From.Length > 10) Error = "Длина отправителя более 10";
                        break;
                }

                return Error;
            }
        }

        public string Error { get; private set; }
    }
}
