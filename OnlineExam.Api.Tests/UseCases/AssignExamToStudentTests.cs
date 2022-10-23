using OnlineExam.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineExam.Api.Tests.Framework;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;
using System;

namespace OnlineExam.Application.UseCases.Tests
{
    [TestClass()]
    public class AssignExamToStudentTests : TestClassBase
    {
        private IAssignExamToStudent _testClass;

        [TestInitialize]
        public void SetUp()
        {
            _testClass = _serviceProvider.GetService<IAssignExamToStudent>();
        }

        [TestMethod()]
        public void AssignTest()
        {
            Assignment assignment = new Assignment()
            {
                StudentId = 1,
                ExamId = 1,
                IsCompleted = false,
                Score = 0,
                Deadline = DateTime.Now.AddDays(7),
            };

            Assert.AreNotEqual(_testClass.CreateAssignment(assignment), 0);
        }

        [TestMethod()]
        public void AssignTestWithInvalidExamAndStudent()
        {
            Assignment assignment = new Assignment()
            {
                StudentId = 5555,
                ExamId = 5555,
                IsCompleted = false,
                Score = 0,
                Deadline = DateTime.Now.AddDays(7),
            };

            Assert.ThrowsException<ArgumentException>(() => _testClass.CreateAssignment(assignment));
        }

        [TestMethod()]
        public void AssignTestWithSameStudentSameExam()
        {
            Assignment assignment = new Assignment()
            {
                StudentId = 1,
                ExamId = 1,
                IsCompleted = false,
                Score = 0,
                Deadline = DateTime.Now.AddDays(7),
            };

            Assert.ThrowsException<ArgumentException>(() => _testClass.CreateAssignment(assignment));
        }

        [TestMethod()]
        public void ShowAssignmentBelongToStudentTest()
        {
            Assert.AreNotEqual(_testClass.ShowAssignmentBelongToStudent(1).Result.Count, 0);
        }
    }
}