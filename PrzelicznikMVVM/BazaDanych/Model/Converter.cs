using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzelicznikMVVM.BazaDanych.Model
{
    class Converter
    {
        public int Id { get; set; }

        public int UnitFromId { get; set; }
        public Unit UnitFrom { get; set; }

        public int UnitToId { get; set; }
        public Unit UnitTo { get; set; }

        public double Value { get; set; }

        public Converter(Unit unitFrom, Unit unitTo, double value)
        {
            UnitFrom = unitFrom;
            UnitTo = unitTo;
            Value = value;
        }

        public Converter() { }
    }
}
