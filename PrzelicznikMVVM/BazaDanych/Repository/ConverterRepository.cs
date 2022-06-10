using System.Collections.Generic;
using System.Linq;
using PrzelicznikMVVM.BazaDanych.Context;
using PrzelicznikMVVM.BazaDanych.Model;



namespace PrzelicznikMVVM.BazaDanych.Repository
{
    class ConverterRepository
    {
        #region singleton instance
        private ConverterRepository() {   }

        static private ConverterRepository _instance;
        static public ConverterRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new ConverterRepository();
                return _instance;
            }
        }
        #endregion

        private ConverterDbContext _context = new ConverterDbContext();

        private void FillDatabase()
        {
            UnitType wagaType = new UnitType("Waga");
            UnitType dystansType = new UnitType("Dystans");
            UnitType walutaType = new UnitType("Waluta");

            Unit kilometr = new Unit("Kilometr", "km", dystansType);
            Unit mila = new Unit("Mila", "mil", dystansType);

            Unit kilogram = new Unit("Kilogram", "kg", wagaType);
            Unit funt = new Unit("Funt", "f", wagaType);

            Unit zloty = new Unit("Złoty", "PLN", walutaType);
            Unit dolar = new Unit("Dolar", "$", walutaType);
            
            
            _context.UnitTypes.Add(wagaType);
            _context.UnitTypes.Add(dystansType);
            _context.UnitTypes.Add(walutaType);

            _context.Units.Add(kilometr);
            _context.Units.Add(mila);

            _context.Units.Add(kilogram);
            _context.Units.Add(funt);

            _context.Units.Add(zloty);
            _context.Units.Add(dolar);

            _context.Converters.Add(new Converter(kilometr, mila, 0.621371192));
            _context.Converters.Add(new Converter(mila, kilometr, 1 / 0.621371192));

            _context.Converters.Add(new Converter(kilogram, funt, 2.20462262));
            _context.Converters.Add(new Converter(funt, kilogram, 1 / 2.20462262));
            
            _context.Converters.Add(new Converter(zloty, dolar, 0.23));
            _context.Converters.Add(new Converter(dolar, zloty, 1 / 0.23));


            _context.SaveChanges();
            System.Environment.Exit(-1);




        }



        public Converter GetConverterByUnits(Unit from, Unit to)
        {
            return _context.Converters.FirstOrDefault(converter => converter.UnitFrom == from && converter.UnitTo == to);
        }

        public List<Unit> GetUnitsByType(UnitType type)
        {
            return _context.Units.Where(unit => unit.Type == type).ToList();
        }

        public List<UnitType> GetAllTypes()
        {
            return _context.UnitTypes.ToList();
        }

        public List<Unit> GetUnitsConvertibleFrom(Unit selectedFrom)
        {
            return _context.Converters.Where(conv => conv.UnitFrom == selectedFrom).Select(conv => conv.UnitTo).ToList();
        }
    }
}
