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

        //public DbSet<Subtask> Subtasks { get; set; } = null!;
        public TodoDbContext() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? password = Environment.GetEnvironmentVariable("TODOAPP_DB_PASSWORD");

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException("Database password is not set in evironment variable TODOAPP_DB_PASSWORT. " + "\n" + " Do it via:" + "\n" + "echo 'export TODOAPP_DB_PASSWORD=\"deinPasswortHier\"' >> ~/.bashrc" + "\n" + "source ~/.bashrc");
            }
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = $"server=localhost;port=3306;database=todoapp;user=todo;password={password}";

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }

           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("Todos");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.Title)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasIndex(t => new { t.IsDone, t.DueAt });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}