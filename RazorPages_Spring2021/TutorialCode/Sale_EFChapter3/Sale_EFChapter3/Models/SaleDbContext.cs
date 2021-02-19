using Microsoft.EntityFrameworkCore;
using Sale_EFChapter3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sale_RazorPagesApp.Models
{
    public class SaleDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SaleDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
       
    }
}
