using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Drink_Water {
    public class DataContext : DbContext {

        public DbSet<DataB> User { get; set; }

        public DataContext() {

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            string connectionStringBuilder = new SqliteConnectionStringBuilder() {
                DataSource = "Drink_Water_DB.db"
            }.ToString();

            var connection = new SqliteConnection(connectionStringBuilder);
            optionsBuilder.UseSqlite(connection);
        }
    }

}
