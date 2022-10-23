using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestInitialize]
        public void SetUp()
        {
            _testClass = _serviceProvider.GetService<IExamEnrollment>();
        }

        [TestMethod()]
        public void CreateExamTest()
        {
            Exam exam = new Exam()
            {
                Code = "Exam001",
                Header = "Online Exam 001",
                Questions = new List<Question> {
                    new Question()
                    {
                        Text = "Test question 1",
                        A = "Answer 1",
                        B = "Answer 2",
                        C = "Answer 3",
                        D = "Answer 4",
                        TrueAnswer = "B"
                    },
                    new Question()
                    {
                        Text = "Test question 2",
                        A = "Answer 1",
                        B = "Answer 2",
                        C = "Answer 3",
                        D = "Answer 4",
                        TrueAnswer = "c"
                    },
                    new Question()
                    {
                        Text = "Test question 3",
                        A = "Answer 1",
                        B = "Answer 2",
                        C = "Answer 3",
                        D = "Answer 4",
                        TrueAnswer = "B"
                    },
                    new Question()
                    {
                        Text = "Test question 4",
                        A = "Answer 1",
                        B = "Answer 2",
                        C = "Answer 3",
                        D = "Answer 4",
                        TrueAnswer = "D"
                    },
                    new Question()
                    {
                        Text = "Test question 5",
                        A = "Answer 1",
                        B = "Answer 2",
                        C = "Answer 3",
                        D = "Answer 4",
                        TrueAnswer = "A"
                    }
                }
            };

            Assert.AreNotEqual(_testClass.CreateExam(exam).Result, 0);
        }

        [TestMethod()]
        public void GetExamWithIdTest()
        {
            var result = _testClass.GetExamWithId(1).Result;
            Assert.AreNotEqual(result, default);
            Assert.AreNotEqual(result.Questions.Count, 0);
        }
    }
}