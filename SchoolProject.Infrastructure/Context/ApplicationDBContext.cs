using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Entites.Views;
using System.Reflection;
namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDBContext:IdentityDbContext<User,ApplicationRole,string>
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public DbSet<User> User { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StudentSubject> StudentSubjects { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Instractor> instractors { get; set; }
        public DbSet<Ins_Subject> ins_subjects { get; set; }


        #region Views
        public DbSet<ViewDepartment> ViewDepartment {  get; set; }
        #endregion
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            //should key 32 char =128-bit
            _encryptionProvider = new GenerateEncryptionProvider("713c4c4aa4f7430e973c264926219e37");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

         modelBuilder.UseEncryption(_encryptionProvider);

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
            modelBuilder.Entity<ViewDepartment>()
                        .HasNoKey()
                        .ToView("ViewDepartment");

            base.OnModelCreating(modelBuilder);
        }
    }
}
