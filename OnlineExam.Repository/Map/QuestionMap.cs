using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Repository.Map
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // Keys
            builder.HasKey(t => t.Id);

            // Table
            builder.ToTable("QUESTIONS");

            // Properties
            builder.Property(t => t.Id).HasColumnName("ID").IsRequired();
            builder.Property(t => t.ExamId).HasColumnName("EXAMID").IsRequired();
            builder.Property(t => t.Text).HasColumnName("TEXTT").IsRequired();
            builder.Property(t => t.A).HasColumnName("A").IsRequired();
            builder.Property(t => t.B).HasColumnName("B").IsRequired();
            builder.Property(t => t.C).HasColumnName("C").IsRequired();
            builder.Property(t => t.D).HasColumnName("D").IsRequired();
            builder.Property(t => t.TrueAnswer).HasColumnName("TRUEANSWER").IsRequired();
        }
    }
}
