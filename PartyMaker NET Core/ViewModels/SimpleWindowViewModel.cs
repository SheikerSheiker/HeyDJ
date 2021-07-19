using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using PartyMaker_NET_Core.Commands.Base;
using PartyMaker_NET_Core.ViewModels.Base;

namespace PartyMaker_NET_Core.ViewModels
{

    internal class SimpleWindowViewModel : ViewModel
    {
        #region Метод проверки открыто ли окно
        public static bool IsWindowOpen<T>(string name = "") where T : Window
        {
            return string.IsNullOrEmpty(name)
               ? Application.Current.Windows.OfType<T>().Any()
               : Application.Current.Windows.OfType<T>().Any(w => w.Name.Equals(name));
        }
        #endregion
        #region Команды
        #region Сохранение профиля
        public ICommand SaveProfileCommand { get; }
        public bool CanSaveProfileCommandExecute(object p) => true;
        public async void OnSaveProfileCommandExecuted(object p)
        {
            await Task.Run(() =>
            {
                SaveFileDialog ofd = new SaveFileDialog
                {
                    FileName = "Profile",
                    DefaultExt = ".text",
                    Filter = "Text documents (.txt)|*.txt"
                };
                ofd.ShowDialog();

                StreamWriter f = new StreamWriter(ofd.FileName);
                //Сюды добавить сохранение профиля
                f.Close();
            });
        }
        #endregion
        #region Открытие профиля
        public ICommand OpenProfileCommand { get; }
        public bool CanOpenProfileCommandExecute(object p) => true;
        public async void OnOpenProfileCommandExecuted(object p)
        {
            await Task.Run(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Text documents (.txt)|*.txt"
                };
                ofd.ShowDialog();
                if (ofd.FileName != "") // проверка на выбор файла
                {
                    StreamReader f = new StreamReader(ofd.FileName);
                    try
                    {
                        //А сюды добавить чтение
                        f.Close();
                    }
                    catch (Exception)
                    {
                        //Сюда добавить восстановление предыдущих значений, если входные данные не верны
                        MessageBox.Show("Неверный формат входных данных!");
                    }
                }
            });
        }
        #endregion
        #region Открытие окна справки
        public ICommand OpenReferenceWindowCommand { get; }
        public bool CanOpenReferenceWindowCommandExecute(object p) => true;
        public async void OnOpenReferenceWindowCommandExecuted(object p)
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Reference refer = new Reference();
                    refer.Show();
                });
            });
        }
        #endregion
        #endregion

        public SimpleWindowViewModel()
        {
            #region Инициализация комманд
            SaveProfileCommand = new LambdaCommand(OnSaveProfileCommandExecuted, CanSaveProfileCommandExecute);
            OpenProfileCommand = new LambdaCommand(OnOpenProfileCommandExecuted, CanOpenProfileCommandExecute);
            OpenReferenceWindowCommand = new LambdaCommand(OnOpenReferenceWindowCommandExecuted, CanOpenReferenceWindowCommandExecute);
            #endregion
        }
    }
}
