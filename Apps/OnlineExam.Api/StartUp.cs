using Infrastructure.Engine;
using Infrastructure.Helpers;
using Infrastructure.Settings;
using OnlineExam.Api.Settings;
using OnlineExam.Application.UseCases;
using OnlineExam.Domain.UseCases;

namespace OnlineExam.Api
{
    public class StartUp
    {
        public static WebApplication BuildTheApp()
        {
            var builder = WebApplication.CreateBuilder(new string[] {});

            builder.Services.AddControllers();            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructure(builder.Configuration);

            // Add services to the container.
            builder.Services.AddScoped<IUserEnrollment, UserEnrollment>();
            builder.Services.AddScoped<IExamEnrollment, ExamEnrollment>();
            builder.Services.AddScoped<IAssignExamToStudent, AssignExamToStudent>();

            /* Settings */
            QuestionsPath questionsPath = new QuestionsPath();
            var settingSection = builder.Configuration.GetSection("QuestionsPath");
            settingSection.Bind(questionsPath);
            builder.Services.AddSingleton<QuestionsPath>(questionsPath);
            

            return builder.Build();
        }
    }
}
