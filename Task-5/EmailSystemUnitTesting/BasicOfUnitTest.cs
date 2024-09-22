using Email_System.Models;
using Email_System.Services;
using EmailSystemDtos.UserDtos;
using FluentAssertions;
namespace EmailSystemUnitTesting
{
    public class BasicOfUnitTest
    {


        [Fact]
        public void Test_Number1()
        {
            //Arrange
            int x = 8; int y = 9;
            int z;
            //Act
            z = y - x;
            //Assert
            z.Should().Be(1);
            z.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Test_String1()
        {
            //Arrange
            string str = "";
            //Act
            str = "Hello";
            //Assert
            str.Should().NotBeNullOrEmpty().And.StartWith("H");
        }
        [Fact]
        public void Test_String2()
        {
            //Arrange
            string str = "";
            //Act
            str = "Hello";
            //Assert
            str.Should().BeOfType<string>();
        }
        [Fact]
        public void Test_Boolean()
        {
            //Arrange
            bool first;
            //Act
            first = true;
            //Assert
            first.Should().BeTrue();
            first.Should().NotBe(false);
        }

        [Fact]
        public void Test_Number2()
        {
            //Arrange
            int x = 6;
            //Act
            //Assert
            x.Should().BePositive();
            x.Should().BeGreaterThanOrEqualTo(3);
            x.Should().BeInRange(4, 7);
            x.Should().NotBeInRange(7, 9);
        }
    }
}