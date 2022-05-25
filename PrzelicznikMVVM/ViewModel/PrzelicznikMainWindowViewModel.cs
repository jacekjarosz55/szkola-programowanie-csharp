using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PrzelicznikMVVM.BazaDanych.Model;


using WPFUtilities;


namespace PrzelicznikMVVM.ViewModel
{
    class PrzelicznikMainWindowViewModel : ObserverVM
    {

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
