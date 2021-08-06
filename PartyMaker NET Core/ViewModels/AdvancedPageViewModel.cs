using PartyMaker_NET_Core.Commands.Base;
using PartyMaker_NET_Core.Models;
using PartyMaker_NET_Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PartyMaker_NET_Core.ViewModels
{
    class AdvancedPageViewModel : ViewModel
    {
        #region Команды
        #region Добавление алкоголя
        public ICommand AddAlcoCommand { get; }
        private bool CanAddAlcoCommandExecute(object p) => AllAlco.Count <= 10;
        private void OnAddAlcoCommandExecuted(object p) => AllAlco.Add(new Alco());
        #endregion
        #region Удаление выбранного алкоголя
        public ICommand DeleteAlcoCommand { get; }
        private bool CanDeleteAlcoCommandExecute(object p) => SelectedAlco != null;
        private void OnDeleteAlcoCommandExecuted(object p)
        {
            if (AllAlco.Count != 1)
            {
                int nextSelect = AllAlco.IndexOf(SelectedAlco);
                AllAlco.Remove(SelectedAlco);
                if (nextSelect == AllAlco.Count)
                    nextSelect--;
                SelectedAlco = AllAlco[nextSelect];
            }
            else
                AllAlco.Remove(SelectedAlco);
        }
        #endregion
        #endregion

        #region Поля
        #region Виды алкоголя DataGrid
        ObservableCollection<Alco> _allAlco = new ObservableCollection<Alco>();
        public ObservableCollection<Alco> AllAlco
        {
            get => _allAlco;
        }
        #endregion
        #region Выбранный айтем у DataGrid для удаления
        private Alco _selectedAlco;
        public Alco SelectedAlco
        {
            get => _selectedAlco;
            set => Set(ref _selectedAlco, value);
        }
        #endregion
        #endregion

        public AdvancedPageViewModel()
        {
            #region Инициализация комманд
            AddAlcoCommand = new LambdaCommand(OnAddAlcoCommandExecuted, CanAddAlcoCommandExecute);
            DeleteAlcoCommand = new LambdaCommand(OnDeleteAlcoCommandExecuted, CanDeleteAlcoCommandExecute);
            #endregion
        }
    }
}
