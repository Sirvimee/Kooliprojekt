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
    public class BookingControllerTest
    {
        private readonly BookingsController _bookingsController;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public BookingControllerTest()
        {
            _bookingService = A.Fake<IBookingService>();
            _roomService = A.Fake<IRoomService>();
            _bookingsController = new BookingsController(_bookingService, _roomService);
        }

        [Fact]
        public void BookingsController_Index_ReturnsSuccess()
        {
            //Arrange
            var bookings = A.Fake<IList<Booking>>();
            A.CallTo(() => _bookingService.List()).Returns(bookings);
            //Act
            var result = _bookingsController.Index();
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }

        [Fact]
        public void BookingsController_Details_ReturnsSuccess()
        {
            //Arrange
            var id = 1;
            var booking = A.Fake<Booking>();
            A.CallTo(() => _bookingService.Get(id)).Returns(booking);
            //Act
            var result = _bookingsController.Details(id);
            //Assert
            result.Should().BeOfType<Task<IActionResult>>();
        }
    }
}
