using Microsoft.EntityFrameworkCore;
using System;
using Data;
using Data.Classes;
using System.IO;
/// <summary>
/// този глас се грижи за създаването на базата данни с таблиците за events и organisations
/// </summary>
namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        
        private readonly string _databasePath;
        public DatabaseContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }
        public DatabaseContext()
        {
            var dbPath =
               Path.Combine(System.Environment.GetFolderPath
               (System.Environment.SpecialFolder.Personal), "eventsDB.db");
            _databasePath = dbPath;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath} ");
        }
    }
}
