using Microsoft.EntityFrameworkCore;

using PrzelicznikMVVM.BazaDanych.Model;

namespace PrzelicznikMVVM.BazaDanych.Context
{
    class ConverterDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            base.OnConfiguring(ob.UseSqlite(@"Data Source=Converter.db"));
        }
    }
} 
