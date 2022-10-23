using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace OnlineExam.Api.Tests.Framework
{
    public class DependencyResolverHelper
    {
        private readonly IHost _webHost;

        public DependencyResolverHelper(IHost webHost) => _webHost = webHost;

        public T GetService<T>()
        {
            var serviceScope = _webHost.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            try
            {
                var scopedService = services.GetRequiredService<T>();
                return scopedService;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
