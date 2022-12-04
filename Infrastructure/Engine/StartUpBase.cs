using System.Reflection;
using FluentValidation;
using Infrastructure.Helpers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Engine
{
    public static class StartUpBase
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            CommonHelper.GetAllInstancesOf<IConfigurationRegister>()?
                            .ForEach(x => x.Configure(services, configuration));

            CommonHelper.GetAllInstancesOf<IDynamicRegister>()?
                .ForEach(x => x.Configure(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
