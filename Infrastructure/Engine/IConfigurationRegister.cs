using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Engine
{
    public interface IConfigurationRegister
    {
        void Configure(IServiceCollection service, IConfiguration configuration);
    }
}
