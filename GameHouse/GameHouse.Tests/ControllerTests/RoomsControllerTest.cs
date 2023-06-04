using GameHouse.Controllers;
using GameHouse.Data;
using GameHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GameHouse.Tests.Controllers
{
    public class RoomsControllerTests
    {
        private readonly RoomsController _controller;
        private readonly Mock<IRoomService> _roomServiceMock;
        private readonly Mock<IGalleriesService> _galleriesServiceMock;

        public RoomsControllerTests()
        {
            _roomServiceMock = new Mock<IRoomService>();
            _galleriesServiceMock = new Mock<IGalleriesService>();

            _controller = new RoomsController(_roomServiceMock.Object, _galleriesServiceMock.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewResultWithRooms()
        {
            // Arrange
            var rooms = new List<Room> { new Room { Id = 1, Name = "Room 1" }, new Room { Id = 2, Name = "Room 2" } };
            _roomServiceMock.Setup(s => s.List()).ReturnsAsync(rooms);

            // Act
            var result = await _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Room>>(viewResult.ViewData.Model);
            Assert.Equal(rooms, model);
        }

        [Fact]
        public async Task Details_WithId_ReturnsViewResultWithRoom()
        {
            // Arrange
            var room = new Room { Id = 1, Name = "Room 1" };
            _roomServiceMock.Setup(s => s.Get(1)).ReturnsAsync(room);

            // Act
            var result = await _controller.Details(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Room>(viewResult.ViewData.Model);
            Assert.Equal(room, model);
        }

        [Fact]
        public async Task Create_ReturnsViewResultWithRoom()
        {
            // Arrange
            var room = new Room { Name = "New Room" };
            _roomServiceMock.Setup(s => s.Save(room)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(room);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Room>(viewResult.ViewData.Model);
            Assert.Equal(room, model);
        }

        [Fact]
        public async Task Edit_WithId_RedirectsToIndex()
        {
            // Arrange
            var room = new Room { Id = 1, Name = "Updated Room" };
            _roomServiceMock.Setup(s => s.Update(room)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Edit(1, room);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public async Task Delete_WithId_RedirectsToIndex()
        {
            // Arrange
            _roomServiceMock.Setup(s => s.Delete(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteConfirmed(1);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }
    }
}
