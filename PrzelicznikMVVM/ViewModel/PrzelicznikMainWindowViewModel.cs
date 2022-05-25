using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using PrzelicznikMVVM.BazaDanych.Model;
using PrzelicznikMVVM.BazaDanych.Context;

using WPFUtilities;
using System.Linq;

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
        private List<UnitType> _unitTypes;
        public List<UnitType> UnitTypes => _unitTypes;

        private List<Unit> _units;
        public List<Unit> UnitsTo => _units;
        public List<Unit> UnitsFrom =>  _units.Where




        private Unit _selectedUnitFrom;
        public Unit SelectedUnitFrom {
            get => _selectedUnitFrom;
            set {
                _selectedUnitFrom = value; OnPropertyChanged();
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



    }
}
