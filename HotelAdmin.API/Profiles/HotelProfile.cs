using AutoMapper;
using HotelAdmin.API.DbContexts;
using HotelAdmin.API.Entities;
using HotelAdmin.API.Models.HotelDtos;

namespace HotelAdmin.API.Profiles;

public class HotelProfile : Profile
{
    public HotelProfile()
    {
        // from hotel to dto
        CreateMap<Hotel, HotelDto>();
        CreateMap<Hotel, HotelWithoutRoomsDto>();
        
        //from dto to hotel
        CreateMap<HotelToCreateDto, Hotel>();
        CreateMap<HotelToUpdateDto, Hotel>();
    }
}