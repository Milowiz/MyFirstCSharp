using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using _05_ToDoManager.Models;

namespace _05_ToDoManager.Data
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }
        public TodoDbContext() {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "server=localhost;port=3306;database=todoapp;user=todo;password=Tomate15243;";

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("Todos");

                entity.HasKey(t => t.Id);

                entity.Property(t=> t.Title).IsRequired().HasMaxLength(200);

                entity.HasIndex(t => t.IsDone);
            });
        }
    }
}