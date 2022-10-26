using Infrastructure.Engine;
using Infrastructure.Extensions;
using OnlineExam.Api.Settings;

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
            builder.Services.AddJwt(builder.Configuration);

            /* Settings */
            QuestionsPath questionsPath = new QuestionsPath();
            var settingSection = builder.Configuration.GetSection("QuestionsPath");
            settingSection.Bind(questionsPath);
            builder.Services.AddSingleton<QuestionsPath>(questionsPath);

            ApiSettings apiSettings = new ApiSettings();
            var apiSettingSection = builder.Configuration.GetSection("ApiSettings");
            apiSettingSection.Bind(apiSettings);
            builder.Services.AddSingleton<ApiSettings>(apiSettings);

            return builder.Build();
        }
    }
}
