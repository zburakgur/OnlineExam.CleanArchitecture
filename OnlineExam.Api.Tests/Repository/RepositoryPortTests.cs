using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineExam.Api.Settings;
using OnlineExam.Api.Tests.Framework;
using OnlineExam.Domain.Entities;
using OnlineExam.Domain.Ports;
using OnlineExam.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Repository.Repository.Tests
{
    [TestClass()]
    public class RepositoryPortTests : TestClassBase
    {
        private IRepositoryPort _repositoryPort;
        private QuestionsPath _questPath;

        [TestInitialize]
        public void SetUp()
        {
            _repositoryPort = _serviceProvider.GetService<IRepositoryPort>();
            _questPath = _serviceProvider.GetService<QuestionsPath>();
        }

        [TestMethod()]
        public void CheckAdminTest()
        {
            Admin admin = new Admin()
            {
                UserName = "Admin",
                Password = "Password"
            };

            Assert.AreEqual(_repositoryPort.CheckAdmin(admin).Result, true);
        }

        [TestMethod()]
        public void CreateStudentTest()
        {
            Student student = new Student()
            {
                Name = "TestUserName",
                Surname = "TestUserSurname"
            };

            Assert.AreNotEqual(_repositoryPort.CreateStudent(student).Result, 0);
        }

        [TestMethod()]
        public void CheckAdminTest1()
        {
            Admin admin = new Admin()
            {
                UserName = "Admin",
                Password = "Password"
            };

            Assert.AreEqual(_repositoryPort.CheckAdmin(admin).Result, true);
        }

        [TestMethod()]
        public void GetStudentListTest()
        {
            Assert.AreNotEqual(_repositoryPort.GetStudentList().Result.Count, 0);
        }

        [TestMethod()]
        public void GetExamListTest()
        {
            var result = _repositoryPort.GetExamList(_questPath.Path).Result;
            Assert.AreNotEqual(result, default);
            Assert.AreNotEqual(result.Count, 0);
        }

        [TestMethod()]
        public void GetQuestionListWithExamCodeTest()
        {
            string examCode = "EXAM_001";
            Assert.AreNotEqual(_repositoryPort.GetQuestionListWithExamCode(examCode, _questPath.Path).Result.Count, 0);
        }

        [TestMethod()]
        public void CreateAssignmentTest()
        {
            Assignment assignment = new Assignment()
            {
                StudentId = 1,
                ExamCode = "EXAM_001",
                IsCompleted = false,
                Score = 0,
                Deadline = DateTime.Now.AddDays(7),
            };

            Assert.AreNotEqual(_repositoryPort.CreateAssignment(assignment), 0);
        }

        [TestMethod()]
        public void CreateAssignmentWithInvalidExamAndStudent()
        {
            Assignment assignment = new Assignment()
            {
                StudentId = 5555,
                ExamCode = "EXAM_001",
                IsCompleted = false,
                Score = 0,
                Deadline = DateTime.Now.AddDays(7),
            };

            Assert.ThrowsException<ArgumentException>(() => _repositoryPort.CreateAssignment(assignment));
        }

        [TestMethod()]
        public void CreateAssignmentWithSameStudentSameExam()
        {
            Assignment assignment = new Assignment()
            {
                StudentId = 1,
                ExamCode = "EXAM_001",
                IsCompleted = false,
                Score = 0,
                Deadline = DateTime.Now.AddDays(7),
            };

            Assert.ThrowsException<ArgumentException>(() => _repositoryPort.CreateAssignment(assignment));
        }

        [TestMethod()]
        public void GetAssignmentListWithStudentIdTest()
        {
            Assert.AreNotEqual(_repositoryPort.GetAssignmentListWithStudentId(1).Result.Count, 0);
        }

        [TestMethod()]
        public void GetExamListNotAssignedToStudentTest()
        {
            Assert.AreEqual(_repositoryPort.GetExamListNotAssignedToStudent(2, _questPath.Path).Result.Count, 0);
        }
    }
}