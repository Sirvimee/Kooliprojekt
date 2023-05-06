using FakeItEasy;
using FluentAssertions;
using GameHouse.Controllers;
using GameHouse.Data;
using GameHouse.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse.Tests.ControllerTests
{
    public class RoomsControllerTest
    {
        private RoomsController _roomsController;
        private IRoomService _roomService;
        private IGalleriesService _galleriesService;
        public RoomsControllerTest()
        {
            //Dependencies
            _roomService = A.Fake<IRoomService>();
            _galleriesService = A.Fake<IGalleriesService>();

            //SUT
            _roomsController = new RoomsController(_roomService, _galleriesService);
        }

        [Fact]
        public void RoomsController_Index_ReturnsSuccess()
        {
            //Arrange - What do i need to bring in?
            var rooms = A.Fake<IList<Room>>();
            A.CallTo(() => _roomService.List()).Returns(rooms);

            //Act - What am i testing?
            var result = _roomsController.Index();

            //Assert - Did it work?
            result.Should().BeOfType <Task<IActionResult>>();
        }

        [Fact]
        public void RoomsController_Details_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var room = A.Fake<Room>();
            A.CallTo(() => _roomService.Get(id)).Returns(room);
            
            //Act 
            var result = _roomsController.Details(id);

            //Assert
            result.Should().BeOfType<Task<IActionResult>>();

        }

    }
}
