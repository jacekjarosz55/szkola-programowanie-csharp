using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrzelicznikMVVM.BazaDanych.Model
{
    class Unit
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string CharRepresentation { get; set; }
        public double Value { get; set; }
        public int UnitMethodId { get; set; }
        public UnitMethod UnitMethod { get; set; }
    }
}
