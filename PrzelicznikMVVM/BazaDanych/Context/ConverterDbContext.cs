using Microsoft.EntityFrameworkCore;

using PrzelicznikMVVM.BazaDanych.Model;

namespace PrzelicznikMVVM.BazaDanych.Context
{
    class ConverterDbContext : DbContext
    {
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Converter> Converters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            base.OnConfiguring(ob.UseSqlite(@"Filename=Converter.db"));
        }
    }
} 
