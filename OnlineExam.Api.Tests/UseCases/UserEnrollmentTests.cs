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
    public class UserEnrollmentTests : TestClassBase
    {
        private IUserEnrollment _testClass;

        [TestInitialize]
        public void SetUp()
        {
            _testClass = _serviceProvider.GetService<IUserEnrollment>();
        }

        [TestMethod()]
        public void CreateStudentTest()
        {
            Student student = new Student()
            {
                Name = "TestUserName",
                Surname = "TestUserSurname"
            };

            Assert.AreNotEqual(_testClass.CreateStudent(student).Result, 0);
        }

        [TestMethod()]
        public void CheckAdminTest()
        {
            Admin admin = new Admin()
            {
                UserName = "Admin",
                Password = "Password"
            };

            Assert.AreEqual(_testClass.CheckAdmin(admin).Result, true);
        }
    }
}