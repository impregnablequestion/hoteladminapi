using AutoMapper;
using HotelAdmin.API.DbContexts;
using HotelAdmin.API.Entities;
using HotelAdmin.API.Models.HotelDtos;
using HotelAdmin.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAdmin.API.Controllers;

[ApiController]
[Route("/api/hotels")]
public class HotelController : ControllerBase
{
    private readonly IHotelInfoRepository _repository;
    private readonly IMapper _mapper;
    
    public HotelController(IHotelInfoRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
    {
        var hotelsToReturn = await _repository.GetHotelsAsync();
        return Ok(_mapper.Map<IEnumerable<HotelWithoutRoomsDto>>(hotelsToReturn));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotelById(int id, bool includeRooms = false)
    {
        var hotelToReturn = await _repository.GetHotelAsync(id, includeRooms);

        if (hotelToReturn == null)
        {
            return NotFound();
        }

        return includeRooms
            ? Ok(_mapper.Map<HotelDto>(hotelToReturn))
            : Ok(_mapper.Map<HotelWithoutRoomsDto>(hotelToReturn));
    }
    
    //TODO: Fix post route so that CreatedAtRoute returns properly.
    
    // currently it will save the resource but won't return proper confirmation and direction to that resource

    [HttpPost]
    public async Task<ActionResult<HotelDto>> CreateHotel(HotelToCreateDto hotelToCreate)
    {
        var hotelToAdd = _mapper.Map<Hotel>(hotelToCreate);
        await _repository.AddHotelAsync(hotelToAdd);
        await _repository.SaveChangesAsync();

        var createdHotel = _mapper.Map<HotelDto>(hotelToAdd);

        return CreatedAtRoute(
        "GetHotelById",
        new { Id = createdHotel.Id },
            createdHotel);
    }
}