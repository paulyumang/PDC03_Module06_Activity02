using App10.Model;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Primitives;

namespace App10.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        
        public DatabaseContext() 
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Employee.db");
            optionsBuilder.UseSqlite($"Filename = {dbPath}");
        }
    }
}
