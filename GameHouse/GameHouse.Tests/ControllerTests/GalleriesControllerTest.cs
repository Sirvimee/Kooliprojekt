using GameHouse.Controllers;
using GameHouse.Data;
using GameHouse.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GameHouse.Tests.Controllers
{
    public class GalleriesControllerTests
    {
        private readonly GalleriesController _controller;
        private readonly Mock<IGalleriesService> _galleriesServiceMock;
        private readonly Mock<IRoomService> _roomServiceMock;
        private readonly Mock<IWebHostEnvironment> _environmentMock;

        public GalleriesControllerTests()
        {
            _galleriesServiceMock = new Mock<IGalleriesService>();
            _roomServiceMock = new Mock<IRoomService>();
            _environmentMock = new Mock<IWebHostEnvironment>();

            _controller = new GalleriesController(
                _galleriesServiceMock.Object,
                _roomServiceMock.Object,
                _environmentMock.Object
            );
        }

        [Fact]
        public async Task Index_ReturnsViewResultWithGalleries()
        {
            // Arrange
            var roomId = 1;
            var galleries = new List<Gallery> { new Gallery { Id = 1, RoomId = roomId }, new Gallery { Id = 2, RoomId = roomId } };
            _galleriesServiceMock.Setup(s => s.Get(roomId)).ReturnsAsync(galleries);

            // Act
            var result = await _controller.Index(roomId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Gallery>>(viewResult.ViewData.Model);
            Assert.Equal(galleries, model);
        }

        [Fact]
        public async Task Details_WithId_ReturnsViewResultWithGallery()
        {
            // Arrange
            var galleryId = 1;
            var gallery = new Gallery { Id = galleryId };
            _galleriesServiceMock.Setup(s => s.GetById(galleryId)).ReturnsAsync(gallery);

            // Act
            var result = await _controller.Details(galleryId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Gallery>(viewResult.ViewData.Model);
            Assert.Equal(gallery, model);
        }

        [Fact]
        public void Create_WithRoomId_ReturnsViewResultWithGallery()
        {
            // Arrange
            var roomId = 1;

            // Act
            var result = _controller.Create(roomId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Gallery>(viewResult.ViewData.Model);
            Assert.Equal(roomId, model.RoomId);
        }

        [Fact]
        public async Task Edit_WithId_ReturnsViewResultWithGallery()
        {
            // Arrange
            var galleryId = 1;
            var gallery = new Gallery { Id = galleryId };
            _galleriesServiceMock.Setup(s => s.GetById(galleryId)).ReturnsAsync(gallery);

            // Act
            var result = await _controller.Edit(galleryId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Gallery>(viewResult.ViewData.Model);
            Assert.Equal(gallery, model);
        }

        [Fact]
        public async Task Delete_WithId_ReturnsViewResultWithGallery()
        {
            // Arrange
            var galleryId = 1;
            var gallery = new Gallery { Id = galleryId };
            _galleriesServiceMock.Setup(s => s.GetById(galleryId)).ReturnsAsync(gallery);

            // Act
            var result = await _controller.Delete(galleryId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Gallery>(viewResult.ViewData.Model);
            Assert.Equal(gallery, model);
        }
    }
}
