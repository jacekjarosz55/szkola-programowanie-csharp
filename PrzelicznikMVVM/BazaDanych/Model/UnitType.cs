using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzelicznikMVVM.BazaDanych.Model
{
    class UnitType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UnitType(string name)
        {
            Name = name;
        }

        public UnitType() { }
    }
}
