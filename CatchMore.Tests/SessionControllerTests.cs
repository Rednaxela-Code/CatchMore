using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Web.Areas.Customer.Controllers;

namespace CatchMore.Tests
{
    public class SessionControllerTests
    {

        [Fact]
        public void Index_ReturnsViewResult_WithListOfSessions()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var controller = new SessionController(mockUnitOfWork.Object);

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateAction_ReturnsRedirectOnSuccess()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockUserStore = Mock.Of<IUserStore<ApplicationUser>>();
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(mockUserStore, null, null, null, null, null, null, null, null);

            var user = new ApplicationUser() { Id = "f00", UserName = "f00", Email = "f00@example.com" };
            var tcs = new TaskCompletionSource<ApplicationUser>();
            tcs.SetResult(user);
            mockUserManager.Setup(x => x.FindByIdAsync("f00")).Returns(tcs.Task);

            //var mockUser = new Mock<UserManager<ApplicationUser>>();
            var controller = new SessionController(mockUnitOfWork.Object);
            var model = new Session
            {
                Id = 1,
                SessionName = "Test Session",
                Date = DateTime.Now.AddDays(-1),
                Latitude = 10,
                Longitude = 11,
                ApplicationUser = user,
                ApplicationUserId = user.Id,
            };

            //Act
            var result = controller.Create(model);

            //Assert
            result.Should().BeOfType<RedirectToActionResult>()
                  .Which.ActionName.Should().Be("Index");
        }
    }
}
