using Bill_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bill_API.DataLayers
{
    public class BillingDbContext:DbContext
    {
        public BillingDbContext(DbContextOptions<BillingDbContext> options) : base(options)
        {

        }

        #region Database Sets
        public DbSet<Users> Users { get; set; }
        #endregion

        #region different approach 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new BillingEntityConfiguration());
        //}
        #endregion
    }
}
