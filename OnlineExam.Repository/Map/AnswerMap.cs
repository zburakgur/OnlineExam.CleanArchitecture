using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Map
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            // Keys
            builder.HasKey(t => t.Id);

            // Table
            builder.ToTable("ANSWERS");

            // Properties
            builder.Property(t => t.Id).HasColumnName("ID").IsRequired();
            builder.Property(t => t.AssignmentId).HasColumnName("ASSIGNMENTID").IsRequired();
            builder.Property(t => t.QuestionId).HasColumnName("QUESTIONID").IsRequired();
            builder.Property(t => t.Code).HasColumnName("CODE").IsRequired();
        }
    }
}
