using AutoMapper;
using HotelAdmin.API.Controllers;
using HotelAdmin.API.Entities;
using HotelAdmin.API.Models.HotelDtos;
using HotelAdmin.API.Profiles;
using HotelAdmin.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

// These tests were written using ChatGPT3.5, and had to be debugged slightly before running properly
// They are also  are missing test assertions for common cases (invalid data), Update Hotel when 
// hotel is found, so definitely need to be further worked on in order to be a comprehensive testing solution

namespace HotelAdmin.UnitTests.ControllerTests;

public class HotelControllerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IHotelInfoRepository> _repositoryMock;
    private readonly HotelController _controller;
    
    public HotelControllerTests()
    {
        _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<HotelProfile>()));
        _repositoryMock = new Mock<IHotelInfoRepository>();
        _controller = new HotelController(_repositoryMock.Object, _mapper);
    }

    [Fact]
    public async Task GetHotels_ReturnsOkObjectResult_WithListOfHotelWithoutRoomsDto()
    {
        // Arrange
        var hotels = new List<Hotel>()
        {
            new Hotel { Id = 1, Name = "Hotel 1" },
            new Hotel { Id = 2, Name = "Hotel 2" }
        };
        _repositoryMock.Setup(repo => repo.GetHotelsAsync()).ReturnsAsync(hotels);

        // Act
        var result = await _controller.GetHotels();

        // Assert
        var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
        var hotelDtos = Assert.IsAssignableFrom<IEnumerable<HotelWithoutRoomsDto>>(okObjectResult.Value);
        Assert.Equal(2, hotelDtos.Count());
    }

    [Fact]
    public async Task GetHotelById_ReturnsNotFound_WhenHotelNotFound()
    {
        // Arrange
        _repositoryMock.Setup(repo => repo.GetHotelAsync(1, false)).ReturnsAsync((Hotel)null);

        // Act
        var result = await _controller.GetHotelById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task CreateHotel_ReturnsCreatedAtRouteResult_WithHotelDto()
    {
        // Arrange
        var hotelToCreate = new HotelToCreateDto { Name = "New Hotel" };
        var hotelToAdd = _mapper.Map<Hotel>(hotelToCreate);
        var createdHotel = new Hotel { Name = "New Hotel" };
        _repositoryMock.Setup(repo => repo.AddHotelAsync(hotelToAdd)).Returns(Task.CompletedTask);
        _repositoryMock.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);
        _repositoryMock.Setup(repo => repo.GetHotelAsync(1, false)).ReturnsAsync(createdHotel);

        // Act
        var result = await _controller.CreateHotel(hotelToCreate);

        // Assert
        var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
        var hotelDto = Assert.IsType<HotelDto>(createdAtRouteResult.Value);
        Assert.Equal(createdHotel.Id, hotelDto.Id);
    }

    [Fact]
    public async Task UpdateHotel_ReturnsNotFound_WhenHotelNotFound()
    {
        // Arrange
        var hotelToUpdate = new HotelToUpdateDto { Name = "Updated Hotel" };
        _repositoryMock.Setup(repo => repo.GetHotelAsync(1, true)).ReturnsAsync((Hotel)null);

        // Act
        var result = await _controller.UpdateHotel(hotelToUpdate, 1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task DeleteHotel_ReturnsNotFound_WhenHotelNotFound()
    {
        // Arrange
        _repositoryMock.Setup(repo => repo.GetHotelAsync(1, false)).ReturnsAsync((Hotel)null);

        // Act
        var result = await _controller.DeleteHotel(1);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
