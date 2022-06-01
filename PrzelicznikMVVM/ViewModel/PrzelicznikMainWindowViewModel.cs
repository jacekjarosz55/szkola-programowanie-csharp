using PrzelicznikMVVM.BazaDanych.Context;
using PrzelicznikMVVM.BazaDanych.Model;
using PrzelicznikMVVM.BazaDanych.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WPFUtilities;

namespace PrzelicznikMVVM.ViewModel
{
    class PrzelicznikMainWindowViewModel : ObserverVM
    {

        ConverterRepository repo = ConverterRepository.Instance;


        public PrzelicznikMainWindowViewModel()
        {
            //AvailableTo = new List<Unit>();
            //AvailableFrom = new List<Unit>();
            AvailableTypes = repo.GetAllTypes();
      
            
        }

        #region private property fields
        private double? _inputValue;
        private double _result;
        private Unit _selectedTo;
        private Unit _selectedFrom;
        private UnitType _selectedType;
        private ICommand _calculateCommand;

        private List<Unit> _availableFrom;
        private List<Unit> _availableTo;
        private List<UnitType> _avaliableTypes;
        #endregion

        #region properties exposed to view
        public double? InputValue
        {
            get => _inputValue;
            set
            {
                _inputValue = value;
                OnPropertyChanged();
            } 
        }


        public double Result {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        #region selected items

        public Unit SelectedTo
        {
            get => _selectedTo;
            set
            {
                _selectedTo = value;
                OnPropertyChanged();
            }
        }

        public Unit SelectedFrom
        {
            get => _selectedFrom;
            set
            {
                _selectedFrom = value;
                AvailableTo = repo.GetUnitsConvertibleFrom(_selectedFrom);
                OnPropertyChanged();
            }
        }

        public UnitType SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
                AvailableFrom = repo.GetUnitsByType(_selectedType);
            }
        }
        #endregion

        #region lists
        
        public List<UnitType> AvailableTypes
        {
            get => _avaliableTypes;
            set
            {
                _avaliableTypes = value;
                OnPropertyChanged();
            }
        }


        public List<Unit> AvailableFrom {
            get => _availableFrom;
            set
            {
                _availableFrom = value;
                OnPropertyChanged();
            }
        }

        public List<Unit> AvailableTo
        {
            get => _availableTo;
            set
            {
                _availableTo = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region commands


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
        #endregion

        #endregion

        #region command methods

        public bool CanCalculateExecute(object ob) => _inputValue.HasValue && AvailableTo.Count > 0;
        
        public void OnCalculateCommand(object ob)
        {
            Converter current = repo.GetConverterByUnits(_selectedFrom, _selectedTo);
            Result = _inputValue.Value * current.Value;
            return;
        }
        #endregion
    }
}
