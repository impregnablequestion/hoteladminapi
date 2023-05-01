using AutoMapper;
using HotelAdmin.API.Entities;
using HotelAdmin.API.Models.RoomDtos;
using HotelAdmin.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HotelAdmin.API.Controllers;

[ApiController]
[Route("/api/hotels/{hotelId}/rooms/")]
public class RoomController : ControllerBase
{
    private readonly IHotelInfoRepository _repository;
    private readonly IMapper _mapper;

    public RoomController(IHotelInfoRepository hotelInfoRepository, IMapper mapper)
    {
        _repository = hotelInfoRepository ?? throw new ArgumentNullException(nameof(hotelInfoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomsForHotel(int hotelId)
    {
        if (!await _repository.HotelExistsAsync(hotelId))
        {
            return NotFound();
        }
        var roomsToReturn = await _repository.GetRoomsForHotelAsync(hotelId);
        return Ok(_mapper.Map<IEnumerable<RoomDto>>(roomsToReturn));
    }

    [HttpGet("{roomId}", Name = "GetRoom")]
    public async Task<ActionResult<RoomDto>> GetRoom(int hotelId, int roomId)
    {
        if (!await _repository.HotelExistsAsync(hotelId))
        {
            return NotFound();
        }

        var roomToReturn = await _repository.GetRoomAsync(hotelId, roomId);
        if (roomToReturn == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<RoomDto>(roomToReturn));
    }

    [HttpPost]
    public async Task<ActionResult<RoomDto>> CreateRoom(int hotelId, RoomToCreateDto roomToCreateDto)
    {
        if (!await _repository.HotelExistsAsync(hotelId))
        {
            return NotFound();
        }

        var roomEntity = _mapper.Map<Room>(roomToCreateDto);

        await _repository.AddRoomAsync(hotelId, roomEntity);
        await _repository.SaveChangesAsync();

        var createdRoom = _mapper.Map<RoomDto>(roomEntity);

        return CreatedAtRoute("GetRoom", new
            {
                hotelId,
                roomId = createdRoom.Id
            },
            createdRoom);
    }

    [HttpPut("{roomId}")]
    public async Task<ActionResult> UpdateRoom(int hotelId, int roomId, RoomToUpdateDto roomToUpdate)
    {
        if (!await _repository.HotelExistsAsync(hotelId))
        {
            return NotFound();
        }

        var roomEntity = await _repository.GetRoomAsync(hotelId, roomId);

        if (roomEntity == null)
        {
            return NotFound();
        }

        _mapper.Map(roomToUpdate, roomEntity);

        await _repository.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{roomId}")]
    public async Task<ActionResult> DeleteRoom(int hotelId, int roomId)
    {
        if (!await _repository.HotelExistsAsync(hotelId))
        {
            return NotFound();
        }
        
        var roomToDelete = await _repository.GetRoomAsync(hotelId, roomId);

        if (roomToDelete == null)
        {
            return NotFound();
        }

        _repository.DeleteRoom(roomToDelete);
        await _repository.SaveChangesAsync();
        
        return NoContent();
    }
}