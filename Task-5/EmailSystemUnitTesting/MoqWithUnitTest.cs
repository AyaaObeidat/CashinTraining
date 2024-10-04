using Email_System.Models;
using Email_System.Repositories.Interfaces;
using Email_System.Services;
using EmailSystemDtos.UserDtos;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSystemUnitTesting
{
    public class MoqWithUnitTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IInboxRepository> _inboxRepositoryMock = new();
        private readonly Mock<IOutboxRepository> _outboxRepositoryMock = new();         
        private readonly Mock<ITrashRepository> _rashRepositoryMock = new();
        private readonly UserService _userService;

        public MoqWithUnitTest()
        {
            _userService = new UserService(_userRepositoryMock.Object, _inboxRepositoryMock.Object, _outboxRepositoryMock.Object, _rashRepositoryMock.Object);
        }
       

        [Fact]
        public async Task GetAllUsers_Test_OnUserService()
        {
            var users = new List<User>();
            users.Add(User.Create("Ayaa Obeidat", "Ayaa@gmail.com", "Ayaa1234!", "Jordan-Amman"));
            users.Add(User.Create("Rahma Obeidat", "Rahma@gmail.com", "Rahma1234!", "Jordan-Amman"));

            _userRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(users));

            var result = await _userService.GetAllAsync();

            result.Should().NotBeNull();
            result.Count.Should().Be(2);

        }

        [Fact]
        public async Task GetUserById_UserFound_Test_OnUserService()
        {
            var user = User.Create("Ayaa Obeidat", "Ayaa@gmail.com", "Ayaa1234!", "Jordan-Amman");
            user.Id = new Guid();

            var userGetByParameter = new UserGetByParameter
                { Id = user.Id};

            _userRepositoryMock.Setup(x => x.GetByIdAsync(user.Id)).Returns(Task.FromResult(user));

            var result = await _userService.GetByIdAsync(userGetByParameter);

            Assert.Equal(result.FullName, user.FullName);

        }



        [Fact]
        public async Task GetUserById_UserNotFound_Test_OnUserService()
        {
            var user = User.Create("Ayaa Obeidat", "Ayaa@gmail.com", "Ayaa1234!", "Jordan-Amman");
            var user1 = User.Create("Rah Obeidat", "Rah@gmail.com", "Rah12345!", "Jordan-Amman");

            user.Id = new Guid();
            user1.Id = new Guid();

            var userGetByParameter = new UserGetByParameter
            { Id = user.Id };

            _userRepositoryMock.Setup(x => x.GetByIdAsync(user1.Id));

            var result = await _userService.GetByIdAsync(userGetByParameter);

           await Assert.ThrowsAsync<ArgumentException>(() => _userService.GetByIdAsync(userGetByParameter));


        }
    }
}
