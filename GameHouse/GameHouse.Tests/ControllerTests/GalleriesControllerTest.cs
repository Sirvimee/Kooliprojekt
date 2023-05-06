using FakeItEasy;
using FluentAssertions;
using GameHouse.Controllers;
using GameHouse.Data;
using GameHouse.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse.Tests.ControllerTests
{
    public class GalleriesControllerTest
    {
        private readonly GalleriesController _galleriesController;
        private readonly IGalleriesService _galleriesService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRoomService _roomService;

        public GalleriesControllerTest()
        {
            _galleriesService = A.Fake<IGalleriesService>();
            _roomService = A.Fake<IRoomService>();
            _galleriesController = new GalleriesController(_galleriesService, _roomService, _webHostEnvironment);
        }

        [Fact]
        public async Task GalleriesController_Index_ReturnsSuccessAsync()
        {
            //Arrange
            int roomId = 123;
            var galleries = new List<Gallery> { new Gallery { Id = 1 }, new Gallery { Id = 2 } };
            A.CallTo(() => _galleriesService.Get(roomId)).Returns(galleries);

            //Act
            var result = _galleriesService.Get(roomId);

            //Assert
            var resultTask = _galleriesService.Get(roomId);
            resultTask.Should().NotBeNull();
            resultTask.Should().BeAssignableTo<Task<List<Gallery>>>();
            var res = await resultTask;
            res.Should().NotBeNull();
            res.Should().BeOfType<List<Gallery>>();
            res.Should().BeEquivalentTo(galleries);

        }


        [Fact]
        public void GalleriesController_Details_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var gallery = A.Fake<Gallery>();
            A.CallTo(() => _galleriesService.GetById(id)).Returns(gallery);
            //Act
            var result = _galleriesController.Details(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
