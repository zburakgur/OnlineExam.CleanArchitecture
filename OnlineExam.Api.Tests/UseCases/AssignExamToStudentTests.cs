using OnlineExam.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineExam.Api.Tests.Framework;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.UseCases;
using System;
using OnlineExam.Api.Settings;

namespace OnlineExam.Application.UseCases.Tests
{
    [TestClass()]
    public class AssignExamToStudentTests : TestClassBase
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
        public void AssignTest()
        {
            Assignment assignment = new Assignment()
            {
                StudentId = 1,
                ExamCode = "EXAM_001",
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
                ExamCode = "EXAM_001",
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
                ExamCode = "EXAM_001",
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

        [TestMethod()]
        public void ShowExamListForStudentAssignmentTest()
        {
            Assert.AreEqual(_testClass.ShowExamListForStudentAssignment(2, _questPath.Path).Result.Count, 0);
        }
    }
}