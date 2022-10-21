using CrudOperations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperations.DataAccess
{
    public class CrudOperationsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // TO DO : Con. String json dan okunacak
            optionsBuilder.UseSqlServer("Server=localhost; Database=CrudOperationsDb;uid=sa;pwd=1234");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
