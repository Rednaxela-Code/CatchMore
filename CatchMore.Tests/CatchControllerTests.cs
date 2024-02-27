using Xunit;
using FluentAssertions;
using Web.Areas.Customer.Controllers;
using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.AspNetCore.Hosting;
using CatchMore.Models.ViewModels;

namespace CatchMore.Tests
{
    public class CatchControllerTests
    {
        [Fact]
        public void CreateAction_ReturnsRedirectOnSuccess()
        {
            //Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockWebHostEnv = new Mock<IWebHostEnvironment>();
            var controller = new CatchController(mockUnitOfWork.Object, mockWebHostEnv.Object);
            var model = new CatchVM
            {
                
            };

            //Act
            var result = controller.Create(model, null);

            //Assert
            result.Should().BeOfType<RedirectToActionResult>()
                  .Which.ActionName.Should().Be("Index");
        }
    }
}
