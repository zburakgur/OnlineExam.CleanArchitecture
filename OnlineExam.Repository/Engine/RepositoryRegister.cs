using Infrastructure.Engine;
using Microsoft.Extensions.DependencyInjection;
using OnlineExam.Domain.Ports;
using OnlineExam.Repository.Repository;

namespace OnlineExam.Repository.Engine
{
    public class RepositoryRegister : IDynamicRegister
    {
        public void Configure(IServiceCollection service)
        {
            service.AddScoped<IRepositoryPort, RepositoryPort>();         
        }
    }
}
