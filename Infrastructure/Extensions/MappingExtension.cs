using Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class MappingExtension
    {
        public static TOut ToModel<TIn, TOut>(this TIn entity)
            where TIn : class
            where TOut : class
        {
            return (entity != null) ? AutoMapperConfiguration.Mapper.Map<TIn, TOut>(entity) : default(TOut);
        }
    }
}
