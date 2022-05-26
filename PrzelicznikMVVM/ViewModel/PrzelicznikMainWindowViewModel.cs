using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using PrzelicznikMVVM.BazaDanych.Model;
using PrzelicznikMVVM.BazaDanych.Context;

using WPFUtilities;
using System.Linq;
using System.Windows.Input;

namespace PrzelicznikMVVM.ViewModel
{
    class PrzelicznikMainWindowViewModel : ObserverVM
    {
        private ConverterDbContext dbContext;
        

        public PrzelicznikMainWindowViewModel()
        {
            dbContext = new ConverterDbContext();
            _unitTypes = dbContext.UnitTypes.ToList();
            
        }

        #region lists
        private List<UnitType> _unitTypes;
        public List<UnitType> UnitTypes => _unitTypes;

        private List<Unit> _units;

        public List<Unit> UnitsFrom => _units;
        public List<Unit> UnitsTo => _units.Where(x => x.Id != SelectedUnitFrom.Id).ToList();

        #endregion

        #region selected units
        private Unit _selectedUnitFrom;
        public Unit SelectedUnitFrom {
            get => _selectedUnitFrom;
            set {
                _selectedUnitFrom = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UnitsTo));
            }
        }


        private Unit _selectedUnitTo;
        public Unit SelectedUnitTo
        {
            get => _selectedUnitTo;
            set
            {
                _selectedUnitTo = value; OnPropertyChanged();
            }
        }

        #endregion


        private ICommand _calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if(_calculateCommand == null)
                {
                    _calculateCommand = new RelayCommand<object>(OnCalculateCommand);
                }
                return _calculateCommand;
            } 
            set {
                _calculateCommand = value;
                OnPropertyChanged();
            }
        }

        public double Result { get; set; }

        private Converter AvaliableConverter
        {
            get => dbContext.Converters.Where(
                converter =>
                    converter.UnitFrom == SelectedUnitFrom 
                    && converter.UnitTo == SelectedUnitTo
                ).First();
        }

        public bool CanCalculateExecute(object ob) => AvaliableConverter != null;
        
        public void OnCalculateCommand(object ob)
        {
            if (AvaliableConverter == null) return;

            
        }
    }
}
