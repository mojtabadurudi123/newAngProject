using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data
{
    public class StoreDBContext : DbContext
    {
        public string DbPath { get; }
        public StoreDBContext()
        {

        }
        public StoreDBContext(DbContextOptions options) : base(options)
        {

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "FirstAngularAppDB.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source=FirstAngularAppDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductBrands> ProductBrands { get; set; }
        public DbSet<ProductTypes> ProductTypes { get; set; }


    }

}