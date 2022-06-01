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

        #region private property fields
        private int? _inputValue;
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
        public int? InputValue
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
                OnPropertyChanged();
                OnPropertyChanged(nameof(AvailableTo));
            }
        }

        public UnitType SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedFrom));
            }
        }
        #endregion

        #region lists
        public List<UnitType> AvaliableTypes => repo.GetAllTypes();
        public List<Unit> AvailableFrom => repo.GetUnitsByType(_selectedType);
        public List<Unit> AvailableTo => repo.GetUnitsConvertibleFrom(_selectedFrom);
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
            _result = _inputValue.Value * current.Value;
            return;
        }
        #endregion
    }
}
