using HotelAdmin.API.Constants;
using HotelAdmin.API.Entities;

namespace HotelAdmin.API.Models.RoomDtos;

public class RoomDto
{
    // member fields corresponding to database
    public int Id { get; set; }
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public string? RoomNumber { get; set; }
    public RoomType? Type { get; set; }
    public string? Description { get; set; }
    public int HotelId { get; set; }
    
    // calculated fields & methods
    public decimal PriceToBook(int numOfNights) => numOfNights * PricePerNight;
    public string RoomType() => Type.ToString();
}