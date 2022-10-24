using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineExam.Api.Settings;
using OnlineExam.Api.Tests.Framework;

namespace OnlineExam.Application.Handlers.Tests
{
    [TestClass()]
    public class BusinessHandlerTest : TestClassBase
    {
        private IAssignExamToStudent _testClass;
        private QuestionsPath _questPath;

        [TestInitialize]
        public void SetUp()
        {
            _testClass = _serviceProvider.GetService<IAssignExamToStudent>();
            _questPath = _serviceProvider.GetService<QuestionsPath>();
        }

        [TestMethod()]
        public void HandleTest()
        {
            Assert.Fail();
        }
    }
}