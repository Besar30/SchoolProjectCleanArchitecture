using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Data.Configurations
{
    internal class Studentconfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x=>x.NameAr).HasMaxLength(200);
            builder.Property(x=>x.phone).HasMaxLength(500);
        }
    }
}
