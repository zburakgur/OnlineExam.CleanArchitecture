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
    public class ExamMap : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            // Keys
            builder.HasKey(t => t.Id);

            // Table
            builder.ToTable("EXAMS");

            // Properties
            builder.Property(t => t.Id).HasColumnName("ID").IsRequired();
            builder.Property(t => t.Code).HasColumnName("CODE").IsRequired();
            builder.Property(t => t.Header).HasColumnName("HEADER").IsRequired();
            
        }
    }
}
