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
        public bool CanAddAlcoCommandExecute(object p) => true;
        public void OnAddAlcoCommandExecuted(object p)
        {
            AllAlco.Add(new Alco());
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
        public Alco SelectedAlco {
            get => _selectedAlco;
            set => Set(ref _selectedAlco, value);
        }
        #endregion
        #endregion
        public AdvancedPageViewModel()
        {

        }
    }
}
