using Xunit;
using FluentAssertions;
using Web.Areas.Customer.Controllers;
using CatchMore.Models;
using CatchMore.DataAccess.Repository.IRepository;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace CatchMore.Tests
{
    public class SessionControllerTests
    {
        [Fact]
        public void CreateAction_ReturnsRedirectOnSuccess()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var controller = new SessionController(mockUnitOfWork.Object);
            var model = new Session
            {
                SessionName = "Test Session",
                Date = DateTime.Now,
                Latitude = 10,
                Longitude = 11,
            };

            //Act
            var result = controller.Create(model);

            //Assert
            result.Should().BeOfType<RedirectToActionResult>()
                  .Which.ActionName.Should().Be("Index");
        }
    }
}
