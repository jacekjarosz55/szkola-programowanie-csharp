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

        private int _inputValue;
        private double _result;
        private Unit _selectedTo;
        private Unit _selectedFrom;
        private UnitType _selectedType;
        private ICommand _calculateCommand;


        public int InputValue
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
            }
        }

        public UnitType SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
            }
        }



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



        public bool CanCalculateExecute(object ob) => _inputValue != null;
        
        public void OnCalculateCommand(object ob)
        {
            return;


        }
    }
}
