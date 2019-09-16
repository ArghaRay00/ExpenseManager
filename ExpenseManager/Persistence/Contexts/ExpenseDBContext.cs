using ExpenseManager.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExpenseManager.Persistence.Contexts
{
    public class ExpenseDBContext : DbContext
    {
        public ExpenseDBContext(DbContextOptions<ExpenseDBContext> options) : base(options)
        {
        }
        public virtual DbSet<ExpenseReport> ExpenseReport { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ExpenseManager;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseReport>().HasData(
                new ExpenseReport
                {
                    ItemId = 1,
                    ItemName = "carrot",
                    Amount = 30,
                    Category = "Food",
                    ExpenseDate = DateTime.Today
                }
            );

        }
    }
}
