using GameHouse.Controllers;
using GameHouse.Data;
using GameHouse.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GameHouse.Tests
{
    public class BookingsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            // Arrange
            var bookingServiceMock = new Mock<IBookingService>();
            bookingServiceMock.Setup(service => service.List()).ReturnsAsync(new List<Booking>());

            var roomServiceMock = new Mock<IRoomService>();

            var controller = new BookingsController(bookingServiceMock.Object, roomServiceMock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Details_WithId_ReturnsViewResult()
        {
            // Arrange
            int bookingId = 1;
            var booking = new Booking { Id = bookingId };
            var bookingServiceMock = new Mock<IBookingService>();
            bookingServiceMock.Setup(service => service.Get(bookingId)).ReturnsAsync(booking);

            var roomServiceMock = new Mock<IRoomService>();

            var controller = new BookingsController(bookingServiceMock.Object, roomServiceMock.Object);

            // Act
            var result = await controller.Details(bookingId);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_RedirectsToIndex()
        {
            // Arrange
            var bookingServiceMock = new Mock<IBookingService>();
            bookingServiceMock.Setup(service => service.Save(It.IsAny<Booking>())).Returns(Task.CompletedTask);

            var roomServiceMock = new Mock<IRoomService>();

            var controller = new BookingsController(bookingServiceMock.Object, roomServiceMock.Object);
            var booking = new Booking 
            { 
                Id = 100,
                RoomId = 1,
                Time = "10:00 - 13:00",
                Date = DateTime.Now,
                ContactName = "Test",
                Email = "Test",
                Phone = 1111111
            };

            // Act
            var result = await controller.Create(booking);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Edit_WithId_ReturnsViewResult()
        {
            // Arrange
            int bookingId = 100;
            var booking = new Booking 
            {
                Id = 100,
                RoomId = 1,
                Time = "10:00 - 13:00",
                Date = DateTime.Now,
                ContactName = "Test",
                Email = "Test",
                Phone = 1111111
            };
            var bookingServiceMock = new Mock<IBookingService>();
            bookingServiceMock.Setup(service => service.Get(bookingId)).ReturnsAsync(booking);

            var roomServiceMock = new Mock<IRoomService>();

            var controller = new BookingsController(bookingServiceMock.Object, roomServiceMock.Object);

            // Act
            var result = await controller.Edit(bookingId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(booking, viewResult.Model);
        }

        [Fact]
        public async Task Delete_WithId_RedirectsToIndex()
        {
            // Arrange
            int bookingId = 100;
            var bookingServiceMock = new Mock<IBookingService>();
            bookingServiceMock.Setup(service => service.Delete(bookingId)).Returns(Task.CompletedTask);

            var roomServiceMock = new Mock<IRoomService>();

            var controller = new BookingsController(bookingServiceMock.Object, roomServiceMock.Object);

            // Act
            var result = await controller.DeleteConfirmed(bookingId);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
