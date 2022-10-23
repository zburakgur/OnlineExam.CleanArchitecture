using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Map
{
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            // Keys
            builder.HasKey(t => t.Id);

            // Table
            builder.ToTable("ASSIGNMENTS");

            // Properties
            builder.Property(t => t.Id).HasColumnName("ID").IsRequired();
            builder.Property(t => t.StudentId).HasColumnName("STUDENTID").IsRequired();
            builder.Property(t => t.ExamId).HasColumnName("EXAMID").IsRequired();
            builder.Property(t => t.IsCompleted).HasColumnName("ISCOMPLETED").IsRequired();
            builder.Property(t => t.Score).HasColumnName("SCORE").IsRequired();
            builder.Property(t => t.CompletedDate).HasColumnName("COMPLETEDDATE");
            builder.Property(t => t.Deadline).HasColumnName("DEADLINE").IsRequired();
        }
    }
}
