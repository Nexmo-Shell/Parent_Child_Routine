using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_and_wpf.Model
{
    public class DatabaseCreator : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataFile.db");

        }

        public DbSet<DashBoard> DashBoards { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}
