using AutoMapper;
using HotelAdmin.API.Controllers;
using HotelAdmin.API.Entities;
using HotelAdmin.API.Models.RoomDtos;
using HotelAdmin.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotelAdmin.UnitTests.ControllerTests;

public class RoomControllerTests
{
    private readonly RoomController _roomController;
    private readonly Mock<IHotelInfoRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public RoomControllerTests()
    {
        _repositoryMock = new Mock<IHotelInfoRepository>();
        _mapperMock = new Mock<IMapper>();
        _roomController = new RoomController(_repositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetRoomsForHotel_ReturnsOkResult_WhenHotelExists()
    {
        // Arrange
        int hotelId = 1;
        var rooms = new List<Room>();
        var expectedRoomDtos = new List<RoomDto>();
        _repositoryMock.Setup(repo => repo.HotelExistsAsync(hotelId))
            .ReturnsAsync(true);
        _repositoryMock.Setup(repo => repo.GetRoomsForHotelAsync(hotelId))
            .ReturnsAsync(rooms);
        _mapperMock.Setup(mapper => mapper.Map<IEnumerable<RoomDto>>(rooms))
            .Returns(expectedRoomDtos);

        // Act
        var result = await _roomController.GetRoomsForHotel(hotelId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.Equal(expectedRoomDtos, okResult.Value);
    }

    [Fact]
    public async Task GetRoomsForHotel_ReturnsNotFoundResult_WhenHotelDoesNotExist()
    {
        // Arrange
        int hotelId = 1;
        _repositoryMock.Setup(repo => repo.HotelExistsAsync(hotelId))
            .ReturnsAsync(false);

        // Act
        var result = await _roomController.GetRoomsForHotel(hotelId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task GetRoom_ReturnsOkResult_WhenHotelAndRoomExist()
    {
        // Arrange
        int hotelId = 1;
        int roomId = 1;
        var room = new Room();
        var expectedRoomDto = new RoomDto();
        _repositoryMock.Setup(repo => repo.HotelExistsAsync(hotelId))
            .ReturnsAsync(true);
        _repositoryMock.Setup(repo => repo.GetRoomAsync(hotelId, roomId))
            .ReturnsAsync(room);
        _mapperMock.Setup(mapper => mapper.Map<RoomDto>(room))
            .Returns(expectedRoomDto);

        // Act
        var result = await _roomController.GetRoom(hotelId, roomId);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.Equal(expectedRoomDto, okResult.Value);
    }

    [Fact]
    public async Task GetRoom_ReturnsNotFoundResult_WhenHotelOrRoomDoesNotExist()
    {
        // Arrange
        int hotelId = 1;
        int roomId = 1;
        _repositoryMock.Setup(repo => repo.HotelExistsAsync(hotelId))
            .ReturnsAsync(false);

        // Act
        var result = await _roomController.GetRoom(hotelId, roomId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
    
