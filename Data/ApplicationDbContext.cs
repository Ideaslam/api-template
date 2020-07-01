using Domain.Entity.Common;
using Domain.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
 
using System.IO;
using System.Text;

namespace Data
{
  public   class ApplicationDbContext  : DbContext
    { 
        public ApplicationDbContext () : base()
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {

        }


        //public static DbContextOptions<ApplicationDbContext> GetDbContextOptions()
        //{
        //    IConfiguration configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        //    return new DbContextOptionsBuilder<ApplicationDbContext>()
        //          .UseSqlServer(new SqlConnection(configuration.GetConnectionString("EduraConnection"))).Options;
        //}

        //public ApplicationDbContext(DbContextOptions options) : base(GetDbContextOptions())
        //{

        //}

        protected override  void  OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        #region common
        public DbSet<AppResource>  appResources { get; set; }
        public DbSet<City> cities { get; set; }

        #endregion

        #region

        public DbSet<User> users { get; set; }
        #endregion


    }
}
