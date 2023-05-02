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

    public List<Room> CreateRooms()
    {
        var result = new List<Room>();
        for (var i = 1; i < 20; i++)
        {
            Random rnd = new Random();
            
            var room = new Room(rnd.Next(1, 6), 80.00m)
            {
                Id = i,
                HotelId = 1,
                Type = RoomType.Double,
                Description = "Auto-created Room for Radisson"
            };
            result.Add(room);
        }
        
        for (var i = 20; i < 30; i++)
        {
            Random rnd = new Random();
            
            var room = new Room(rnd.Next(1, 6), 80.00m)
            {
                Id = i,
                HotelId = 2,
                Type = RoomType.Double,
                Description = "Auto-created Room for Yotel"
            };
            result.Add(room);
        }
        
        for (var i = 30; i < 45; i++)
        {
            Random rnd = new Random();
            
            var room = new Room(rnd.Next(1, 6), 80.00m)
            {
                Id = i,
                HotelId = 3,
                Type = RoomType.Double,
                Description = "Auto-created Room for Hilton"
            };
            result.Add(room);
        }
        
        return result;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>().HasData(
            new Hotel("Radisson Blue",
                "18 Argyle Street, Glasgow, G42 8LT",
                "Scotland",
                "+0913839409",
                "https://www.radisson.blue",
                "radissonblue@gmail.com")
            {
                Id = 1,
                City = "Glasgow"
            },
            new Hotel("Yotel",
                    "12 O'Connell Street, Dublin, D1",
                    "Ireland",
                    "+0837481739",
                    "www.yotel.com",
                    "yotel@gmail.com")
            {
                Id = 2,
                City = "Dublin"
            },
            new Hotel("Hilton London",
                "4 Oxford Street, London SW14",
                "United Kingdom",
                "+0038291039901",
                "www.hilton.com",
                "hilton@gmail.com")
            {
                Id = 3,
                City = "London"
            }
        );

        modelBuilder.Entity<Room>().HasData(
            CreateRooms()
        );
    }
}