using Infrastructure.Engine;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineExam.Repository.Engine
{
    public class ContextRegister : IDynamicRegister
    {
        public void Configure(IServiceCollection service)
        {
            service.AddScoped<IOnlineExamContext>(f => { return new OnlineExamContext(f.GetService<ContextConfigurations>().OnlineExam); });
            service.AddScoped(typeof(IOnlineExamRepository<,>), typeof(OnlineExamRepository<,>));
        }
    }
}
