using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email_System.Repositories.Interfaces;
using Email_System.Services;
using FluentAssertions;
using Moq;

namespace EmailSystemUnitTesting
{
    public class UserServiceUnitTest
    {

        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IInboxRepository> _inboxRepositoryMock = new();
        private readonly Mock<IOutboxRepository> _outboxRepositoryMock = new();
        private readonly Mock<ITrashRepository> _rashRepositoryMock = new();
        private readonly UserService userService;

        public UserServiceUnitTest()
        {
            userService = new UserService(_userRepositoryMock.Object , _inboxRepositoryMock.Object , _outboxRepositoryMock.Object ,_rashRepositoryMock.Object);
        }
    }
}
