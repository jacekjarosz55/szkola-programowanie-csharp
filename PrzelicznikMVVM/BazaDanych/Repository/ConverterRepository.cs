using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using PrzelicznikMVVM.BazaDanych.Context;
using PrzelicznikMVVM.BazaDanych.Model;



namespace PrzelicznikMVVM.BazaDanych.Repository
{
    class ConverterRepository
    {
        #region singleton instance
        private ConverterRepository() { }

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

        internal List<Unit> GetUnitsConvertibleFrom(Unit selectedFrom)
        {
            return _context.Converters.Join(_context.Units, x => x.UnitFromId, y => y.Id, (x, y) => y).ToList();
        }
    }
}
