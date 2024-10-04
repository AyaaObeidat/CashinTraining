using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email_System.Models;
using EmailSystemDtos.UserDtos;
using FluentAssertions;

namespace EmailSystemUnitTesting
{
    public class UserModelUnitTest
    {
        
        [Fact]
        public async Task Create_ValidUser_Test()
        {
            //Arrange
            var userCreateParameter = new UserCreateParameter
            {
                FullName = "Aya Obeidat",
                Email = "Aya@gmail.com",
                Password = "AyaOB3820!",
                Address = "Amman-Jordan"
            };

            //Act
            var user = User.Create(userCreateParameter.FullName , userCreateParameter.Email , userCreateParameter.Password , userCreateParameter.Address );

            //Assert

            user.Should().NotBeNull();
            user.Should().BeOfType<User>();

        }

        [Fact]
        public async Task Create_NotValidUser_Test()
        {
            //Arrange
            var userCreateParameter = new UserCreateParameter
            {
                FullName = "Aya Obeidat",
                Email = "Aya@gmail.com",
                Password = "AyaOB3820!",
                Address = ""
            };

            //Act & Assert

           await Assert.ThrowsAsync<ArgumentNullException>(() => Task.FromResult(User.Create(userCreateParameter.FullName, userCreateParameter.Email, userCreateParameter.Password, userCreateParameter.Address)));

        }


    }
}
