using AutoMapper;
using HotelAdmin.API.Entities;
using HotelAdmin.API.Models.RoomDtos;

namespace HotelAdmin.API.Profiles;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        // Entity to Dto
        CreateMap<Room, RoomDto>();

        // Dto to Entity
        CreateMap<RoomToCreateDto, Room>();
        CreateMap<RoomToUpdateDto, Room>();
    }
}