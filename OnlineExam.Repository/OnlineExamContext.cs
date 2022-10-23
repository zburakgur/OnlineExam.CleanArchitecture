using Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Repository.Map;

namespace OnlineExam.Repository
{
    public class OnlineExamContext : SqLiteContext, IOnlineExamContext
    {
        public OnlineExamContext(string connection) : base(connection)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AdminMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new ExamMap());
            modelBuilder.ApplyConfiguration(new AnswerMap());
            modelBuilder.ApplyConfiguration(new AssignmentMap());
        }
    }
}
