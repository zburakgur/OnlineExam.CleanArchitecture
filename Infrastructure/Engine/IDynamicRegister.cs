using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Engine
{
    public interface IDynamicRegister
    {
        void Configure(IServiceCollection service);
    }
}