using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UsersAPI.Controllers;
using UsersAPI.Dtos;
using UsersAPI.Models;
using UsersAPI.Repositories;
using Xunit;

namespace UsersAPI.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public void GetUsers_Should_Return_Users()
        {
            var mockRepository = new Mock<IUsersRepository>();
            var controller = new UsersController(mockRepository.Object);

            var expectedUsers = new List<User>{
                new() { Id = 2, Name = "sol", Email = "solze369@gmail.com" },
            };

            mockRepository.Setup(repo => repo.GetUsers()).Returns(expectedUsers.AsQueryable());

            var result = controller.GetUsers();

            // Assertion
            var actualUsers = Assert.IsAssignableFrom<IEnumerable<UserDto>>(result);

            // Convert actualUsers to a list for easy comparison
            var actualUsersList = actualUsers.ToList();

            // Assert the contents of the lists
            Assert.Equal(expectedUsers.Count, actualUsersList.Count);
            for (int i = 0; i < expectedUsers.Count; i++)
            {
                Assert.Equal(expectedUsers[i].Id, actualUsersList[i].Id);
                Assert.Equal(expectedUsers[i].Name, actualUsersList[i].Name);
                Assert.Equal(expectedUsers[i].Email, actualUsersList[i].Email);
            }
        }

        [Fact]
        public async Task SendOTP_Should_Return_Success_Status()
        {
            // Arrange
            var mockRepository = new Mock<IUsersRepository>();
            var controller = new UsersController(mockRepository.Object);

            var userOtp = new UserOTP { Email = "solze369@gmail.com" };

            // Assume that the repository method returns successfully

            mockRepository
                .Setup(repo => repo.SendOTP(It.IsAny<UserOTP>()))
                .ReturnsAsync(new ApiResponseDto { Status = "success" });

            // Act
            var result = await controller.SendOTP(userOtp);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto>(okResult.Value);

            Assert.Equal("success", response.Status);
        }


        [Fact]
        public async Task SendOTP_Should_Return_Fail_Status()
        {
            // Arrange
            var mockRepository = new Mock<IUsersRepository>();
            var controller = new UsersController(mockRepository.Object);

            var userOtp = new UserOTP { Email = "fff" };

            // Assume that the repository method returns successfull
            mockRepository
       .Setup(repo => repo.SendOTP(It.IsAny<UserOTP>()))
       .ReturnsAsync(new ApiResponseDto { Status = "fail" });

            // Act
            var result = await controller.SendOTP(userOtp);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponseDto>(badRequestResult.Value);

            Assert.Equal("fail", response.Status);

        }
    }


}
