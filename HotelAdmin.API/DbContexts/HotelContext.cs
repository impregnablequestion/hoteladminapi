using HotelAdmin.API.Constants;
using HotelAdmin.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelAdmin.API.DbContexts;

public class HotelContext: DbContext
{
    public DbSet<Hotel> Hotels { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;

    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasData(
            new Hotel("Radisson Blue",
                "18 Dixon Avenue, Glasgow, G42 8LT",
                "Scotland",
                "+07307186731",
                "https://www.radisson.blue",
                "radissonblue@gmail.com")
            {
                Id = 1,
                City = "Glasgow"
            }
        );

        modelBuilder.Entity<Room>().HasData(
            new Room(4, 80.00m)
            {
                Id = 1,
                HotelId = 1,
                Type = RoomType.Family,
                Description = "Just a bog standard hotel room really!"
            }
        );
    }
}