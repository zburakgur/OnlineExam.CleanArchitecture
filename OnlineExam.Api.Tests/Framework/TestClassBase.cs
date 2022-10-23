using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Api.Tests.Framework
{
    public class TestClassBase
    {
        protected DependencyResolverHelper _serviceProvider;

        public TestClassBase()
        {
            _serviceProvider = new DependencyResolverHelper(StartUp.BuildTheApp());
        }
    }
}
