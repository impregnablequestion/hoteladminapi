using HotelAdmin.API.Entities;

namespace HotelAdmin.API.Models.HotelDtos;

public class HotelDto
{
    // member fields corresponding to database
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? City { get; set; }
    public ICollection<Room> Rooms { get; set; } = new List<Room>();
    
    //calculated fields
    public int NumberOfRooms => Rooms.Count;
}