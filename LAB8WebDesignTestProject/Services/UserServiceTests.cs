using Microsoft.VisualStudio.TestTools.UnitTesting;
using LAB7WebDesignTanelHelmik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using LAB7WebDesignTanelHelmik.Data.Entities;
using LAB7WebDesignTanelHelmik.Repositories;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace LAB7WebDesignTanelHelmik.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IUserRepository _userRepository;
        [SetUp]
        public void Setup()
        {
            _userRepository = A.Fake<IUserRepository>();
        }
        [Test]
        public void GetUserTest()
        {
            // Arrange 
            A.CallTo(() => _userRepository.GetUser(A<int>.Ignored)).Returns(new User
            {
                FirstName = "John"
            });
            // Act
            var UserService = new UserService(_userRepository);
            var user = UserService.GetUser(1);
            Assert.AreEqual("John", user.FirstName);
        }
        [TestFixture]
        public class TodoServiceTests
        {
            private ITodoRepository _TodoRespository;

            [SetUp]
            public void SetUp()
            {
                _TodoRespository = A.Fake<ITodoRepository>();
            }

            [Test]
            public void ShouldNotIndicateCheckupAlert()
            {
                // Arrange
                A.CallTo(() => _TodoRespository.GetTodo(A<int>.Ignored)).Returns(new Todo
                {
                    NextReminder = DateTime.Now.AddDays(29)
                });

                // Act (SUT)
                var TodoService = new TodoService(_TodoRespository);
                var TodoViewModel = TodoService.GetTodo(1);

                // Assert
                Assert.IsFalse(TodoViewModel.ReminderAlert);
            }

            [Test]
            public void ShouldIndicateCheckupAlert()
            {
                // Arrange
                A.CallTo(() => _TodoRespository.GetTodo(A<int>.Ignored)).Returns(new Todo
                {
                    NextReminder = DateTime.Now.AddDays(13)
                });

                // Act (SUT)
                var TodoService = new TodoService(_TodoRespository);
                var TodoViewModel = TodoService.GetTodo(1);

                // Assert
                Assert.IsTrue(TodoViewModel.ReminderAlert);
            }
        }
    }
}