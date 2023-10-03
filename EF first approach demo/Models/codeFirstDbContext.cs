using EF_first_approach_demo.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace EF_first_approach_demo.Models
{
    public class codeFirstDbContext : DbContext
    {
        public codeFirstDbContext() : base("myConnection") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<codeFirstDbContext, Configuration>());
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }


    }
}


//enable-migrations -EnableAutomaticMigration:$True is a command for enabling auto database migration for changes in model schema of EF code first approach