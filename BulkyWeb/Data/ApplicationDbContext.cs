﻿using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        internal readonly object Categories;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category>MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name = "Action", DisplayOrder = 1},
                new Category { Id=2,Name="SciFi", DisplayOrder = 2},
                new Category { Id = 3, Name = "History", DisplayOrder = 3}
                );
        }
    }
}
