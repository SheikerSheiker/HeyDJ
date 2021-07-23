using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using PartyMaker_NET_Core.Commands.Base;
using PartyMaker_NET_Core.Pages;
using PartyMaker_NET_Core.ViewModels.Base;

namespace PartyMaker_NET_Core.ViewModels
{

    internal class MainWindowViewModel : ViewModel
    {
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
        #region Переключение страниц
        public ICommand SwitchingModesCommand { get; }
        public bool CanSwitchingModesCommandExecute(object p) => true;
        public async void OnSwitchingModesCommandExecuted (object p)
        {
            await Task.Run(() =>
            {
                CurrentPage = ((bool) p) ? advancedPage : simplePage;
            });
        }
        #endregion
        #endregion

        #region Поля
        private readonly Page simplePage;
        private readonly Page advancedPage;
        #region Текущая страница
        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }
        #endregion
        //#region Кнопка переключателя настроек
        //private bool _setting = false;
        //public bool Setting
        //{
        //    get => _setting;
        //    set
        //    {
        //        Set(ref _setting, value);
        //    }
        //}
        //#endregion
        #endregion
        public MainWindowViewModel()
        {
            #region Инициализация комманд
            SaveProfileCommand = new LambdaCommand(OnSaveProfileCommandExecuted, CanSaveProfileCommandExecute);
            OpenProfileCommand = new LambdaCommand(OnOpenProfileCommandExecuted, CanOpenProfileCommandExecute);
            OpenReferenceWindowCommand = new LambdaCommand(OnOpenReferenceWindowCommandExecuted, CanOpenReferenceWindowCommandExecute);
            SwitchingModesCommand = new LambdaCommand(OnSwitchingModesCommandExecuted, CanSwitchingModesCommandExecute);
            #endregion

            simplePage = new SimplePage();
            advancedPage = new AdvancedPage();
            CurrentPage = simplePage;
        }
    }
}
