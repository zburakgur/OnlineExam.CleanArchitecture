using Infrastructure.Engine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Repository.Engine
{
    public class ContextConfigurationRegister : IConfigurationRegister
    {
        public void Configure(IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<ContextConfigurations>(f => LoadRepositoryConfigurations(configuration));
        }

        private ContextConfigurations LoadRepositoryConfigurations(IConfiguration configuration)
        {
            ContextConfigurations config = new ContextConfigurations();
            var section = configuration.GetSection("ConnectionStrings");
            section.Bind(config);

            return config;
        }
    }
}
