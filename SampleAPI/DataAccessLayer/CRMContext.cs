using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SampleAPI.Models;

namespace SampleAPI.DataAccessLayer
{
    public class CRMContext : DbContext
    {
        public CRMContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}