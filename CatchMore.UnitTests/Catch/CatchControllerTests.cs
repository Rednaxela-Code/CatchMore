using CatchMore.DataAccess.Repository.IRepository;
using CatchMore.Models.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Customer.Controllers;
using Xunit;

namespace CatchMore.UnitTests.Catch
{
    public class CatchControllerTests
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CatchControllerTests(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [Fact]
        public void CreateAction_ReturnsRedirectOnSuccess()
        {
            // Arrange
            var controller = new CatchController(_unitOfWork, _webHostEnvironment);
            var model = new CatchVM()
            {
                
            }; // Prepare your model data

            // Act
            var result = controller.Create(model, null);

            // Assert
            result.Should().BeOfType<RedirectToActionResult>()
                  .Which.ActionName.Should().Be("Index");
        }
    }
}
