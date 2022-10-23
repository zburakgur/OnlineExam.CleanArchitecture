using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineExam.Api.Settings;
using OnlineExam.Api.Tests.Framework;
using OnlineExam.Application.UseCases;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.UseCases.Tests
{
    [TestClass()]
    public class ExamEnrollmentTests : TestClassBase
    {
        private IExamEnrollment _testClass;
        private QuestionsPath _questPath;

        [TestInitialize]
        public void SetUp()
        {
            _testClass = _serviceProvider.GetService<IExamEnrollment>();
            _questPath = _serviceProvider.GetService<QuestionsPath>();
        }

        [TestMethod()]
        public void ShowExamListTest()
        {
            var result = _testClass.ShowExamList(_questPath.Path).Result;
            Assert.AreNotEqual(result, default);
            Assert.AreNotEqual(result.Count, 0);
        }


        [TestMethod()]
        public void ShowQuestionListBelongToExamTest()
        {
            string examCode = "EXAM_001";
            Assert.AreNotEqual(_testClass.ShowQuestionListBelongToExam(examCode, _questPath.Path).Result.Count, 0);
        }
    }
}