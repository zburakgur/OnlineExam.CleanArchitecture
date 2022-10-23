using Infrastructure.Helpers;
using Infrastructure.Mapper;
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

            CommonHelper.GetAllInstancesOf<IMapperConfigure>()?
                .ForEach(x => AutoMapperConfiguration.Init(x.CreateMapperConfigure()));            

            return services;
        }
    }
}
