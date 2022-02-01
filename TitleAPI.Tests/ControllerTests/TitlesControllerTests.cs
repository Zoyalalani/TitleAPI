using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TitleAPI.Controllers;
using TitleAPI.Models;
using TitleAPI.Models.Context;
using Xunit;

namespace TitleAPITests
{
    public class TitlesControllerTests
    {
        private readonly TitleDbContext context;
        public TitlesControllerTests()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<TitleDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").UseInternalServiceProvider(serviceProvider);
            context = new TitleDbContext(builder.Options);
            context.AddRange(Enumerable.Range(1, 10).Select(t => new Title { TitleId = t }));
            context.SaveChanges();
        }
        [Fact]
        public async Task GetAllTasks()
        {
            // Arrange
            var controller = new TitlesController(context);
            //Act
            var result = await controller.GetAllTitles();
            //Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Title>>(result);
            Assert.Equal(10, model.Count());
        }


        [Fact]
        public async Task GetTitleById_NotFound_InvalidId()
        {
            // Arrange
            var controller = new TitlesController(context);

            //Act
            var result = await controller.GetTitle(100);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PutTitle_BadRequestWhenInvalidId()
        {
            // Arrange
            var controller = new TitlesController(context);

            //Act
            var result = await controller.PutTitle(100, new Title { TitleId = 100, TitleName = "Test"});

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutTitle_BadRequestWhenInvalidTitleUpdateRequest()
        {
            // Arrange
            var controller = new TitlesController(context);

            //Act
            var result = await controller.PutTitle(1, new Title { TitleId = 2, TitleName = "Test" });

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }


        [Fact]
        public async Task DeleteTitle_NotFoundWhenInvalidId()
        {
            // Arrange
            var controller = new TitlesController(context);

            //Act
            var result = await controller.DeleteTitle(100);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteTitle_NoContentWhenItemDeleted()
        {
            // Arrange
            var controller = new TitlesController(context);

            //Act
            var result = await controller.DeleteTitle(2);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

    }
}
