using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDBContext:IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentSubject> StudentSubjects { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Instractor> instractors { get; set; }
        public DbSet<Ins_Subject> ins_subjects { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<DepartmetSubject>()
                .HasKey(x => new{x.SubID, x.DID});

            modelBuilder.Entity<Ins_Subject>()
                           .HasKey(x => new { x.SubId, x.InsId });

            modelBuilder.Entity<StudentSubject>()
                          .HasKey(x => new { x.StudID, x.SubID });

            modelBuilder.Entity<Instractor>()
                .HasOne(x=>x.Supervisor)
                .WithMany(x=>x.Instractors)
                .HasForeignKey(x=>x.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
