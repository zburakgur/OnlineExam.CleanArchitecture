using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Repository.Map
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Keys
            builder.HasKey(t => t.Id);

            // Table
            builder.ToTable("STUDENTS");

            // Properties
            builder.Property(t => t.Id).HasColumnName("ID").IsRequired();
            builder.Property(t => t.Name).HasColumnName("NAME").IsRequired();
            builder.Property(t => t.Surname).HasColumnName("SURNAME").IsRequired();
        }
    }
}
