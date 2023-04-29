using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelAdmin.API.Entities;

[Index(nameof(Name), IsUnique = true, Name = "Unique_Name")]
public class Hotel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Address { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Country { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    [Url]
    public string Website { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string? City { get; set; }

    public ICollection<Room> Rooms { get; set; } = new List<Room>();

    public Hotel()
    {
        
    }

    public Hotel(
        string name,
        string address,
        string country,
        string phoneNo,
        string website, 
        string email)
    {
        Name = name;
        Address = address;
        Country = country;
        PhoneNumber = phoneNo;
        Website = website;
        Email = email;
    }
}