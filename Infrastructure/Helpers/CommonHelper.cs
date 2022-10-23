using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public static class CommonHelper
    {
        public static IEnumerable<Type> GetAllTypesOf<T>()
        {
            var platform = Environment.OSVersion.Platform.ToString();
            var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);

            return runtimeAssemblyNames.Select(Assembly.Load)
                    .SelectMany(a => a.ExportedTypes)
                    .Where(t => typeof(T).IsAssignableFrom(t));
        }

        public static List<T> GetAllInstancesOf<T>()
            => GetAllTypesOf<T>()?.Where(o => !o.IsInterface).Select(o => (T)Activator.CreateInstance(o)).ToList();
    }
}
