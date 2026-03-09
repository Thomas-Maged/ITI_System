using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using ITI_Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;

namespace ITI_Entities.Data
{
    public class ITI_Context:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Student> course_Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=ITI_DB;Integrated Security=true;TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(k => k.CrsID);
                c.Property("Name").HasMaxLength(20);
            });

            modelBuilder.Entity<Course_Student>(cs =>
            {
                cs.HasKey(k => new { k.CrsID, k.StdID });

                cs.HasOne(s => s.Student)
                .WithMany(s => s.course_Students)
                .HasForeignKey(f => f.StdID);

                cs.HasOne(c => c.Course)
                .WithMany(c => c.course_Students)
                .HasForeignKey(f => f.CrsID);
                
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
