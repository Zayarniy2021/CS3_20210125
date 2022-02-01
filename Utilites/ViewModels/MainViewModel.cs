using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Utilites.Commands;
using Utilites.ViewModels.Base;

namespace Utilites.ViewModels
{
    class MainViewModel: ViewModel
    {

        public MainViewModel()
        {
            MailSendCommand = new RelayCommand(OnMailSendCommandExecute, CanMailSendCommandExecute);
            CloseWindowCommand = new RelayCommand(OnCloseWindowCommandExecute, CanCloseWindowCommandExecute);
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
        #endregion

        #region Команды

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

    }
}
