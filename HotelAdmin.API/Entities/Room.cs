using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelAdmin.API.Constants;

namespace HotelAdmin.API.Entities;

public class Room
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public int Capacity { get; set; }
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal PricePerNight { get; set; }
    public string? RoomNumber { get; set; }
    public RoomType? Type { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }
    public Hotel? Hotel { get; set; }
    public int HotelId { get; set; }

    public Room()
    {
        
    }

    public Room(int capacity, decimal pricePerNight)
    {
        Capacity = capacity;
        PricePerNight = pricePerNight;
    }
}