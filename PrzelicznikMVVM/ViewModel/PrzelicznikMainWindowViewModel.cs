using PrzelicznikMVVM.BazaDanych.Context;
using PrzelicznikMVVM.BazaDanych.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WPFUtilities;

namespace PrzelicznikMVVM.ViewModel
{
    class PrzelicznikMainWindowViewModel : ObserverVM
    {


        public PrzelicznikMainWindowViewModel()
        {
            dbContext = new ConverterDbContext();
            UnitTypes = dbContext.UnitTypes.ToList();
            
        }


        private int? _inputValue;

        public int? InputValue
        {
            get => _inputValue;
            set
            {
                _inputValue = value;
                OnPropertyChanged();
            } 
        }






        private List<UnitType> _unitTypes;

        public List<UnitType> UnitTypes
        {
            get => _unitTypes;
            set
            {
                _unitTypes = value;
                OnPropertyChanged();
            }
        }


        private UnitType _selectedUnitType;
        public UnitType SelectedUnitType
        {
            get => _selectedUnitType;
            set
            {
                _selectedUnitType = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Units));
            }
        }
        private List<Unit> _units;
        public List<Unit> Units
        {
            get { return  }
            set { _units = value; OnPropertyChanged(); }
        }



        private Unit _selectedUnitTo;
        public Unit SelectedUnitTo
        {
            get => _selectedUnitTo;
            set
            {
                _selectedUnitTo = value;
                OnPropertyChanged();
            }
        }


        private Unit _selectedUnitFrom;
        public Unit SelectedUnitFrom
        {
            get => _selectedUnitFrom;
            set
            {
                _selectedUnitFrom = value;
                OnPropertyChanged();
            }
        }






        private ICommand _calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (_calculateCommand == null)
                {
                    _calculateCommand = new RelayCommand<object>(OnCalculateCommand, CanCalculateExecute);
                }
                return _calculateCommand;
            }
            set
            {
                _calculateCommand = value;
                OnPropertyChanged();
            }
        }

        public double Result { get; set; }



        public bool CanCalculateExecute(object ob) => _inputValue != null;
            //dbContext.Converters.Where(conv => conv.UnitFrom == _selectedUnitFrom && conv.UnitTo == _selectedUnitTo).Any();

        public void OnCalculateCommand(object ob)
        {
            return;


        }
    }
}
