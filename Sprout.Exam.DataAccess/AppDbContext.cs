using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sprout.Exam.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Employee>().HasData(
                    new Employee() { Id=1, FullName = "Fides Arianne Ramos", BirthDate = DateTime.Now, EmployeeTypeId = 1, TIN = "1234567890", IsDeleted = true },
                    new Employee() { Id=2, FullName = "Employee 2", BirthDate = DateTime.Now, EmployeeTypeId = 1, TIN = "2345678901", IsDeleted = false },
                    new Employee() { Id=3, FullName = "Employee 3", BirthDate = DateTime.Now, EmployeeTypeId = 2, TIN = "3456789012", IsDeleted = false },
                    new Employee() { Id=4, FullName = "Employee 4", BirthDate = DateTime.Now, EmployeeTypeId = 1, TIN = "4567890123", IsDeleted = false }
                );
        }
    }
}
