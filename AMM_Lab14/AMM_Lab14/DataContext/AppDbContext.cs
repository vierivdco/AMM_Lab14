using AMM_Lab14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMM_Lab14.DataContext
{
    public class AppDbContext : DbContext
    {
        string DbPath = string.Empty;


        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }



        public AppDbContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }

    }
}