using System.ComponentModel.DataAnnotations;
using HotelAdmin.API.Constants;

namespace HotelAdmin.API.Models.RoomDtos;

public class RoomToUpdateDto
{
    [Required(ErrorMessage = "You must provide a value for capacity")]
    public int Capacity { get; set; }
    public decimal PricePerNight { get; set; }
    public string? RoomNumber { get; set; }
    public RoomType? Type { get; set; }
    public string? Description { get; set; }
}