using HotelAdmin.API.DbContexts;
using HotelAdmin.API.Entities;

namespace HotelAdmin.API.Services;

public interface IHotelInfoRepository
{
    
    // hotels
    
    Task<IEnumerable<Hotel>> GetHotelsAsync();

    Task<Hotel?> GetHotelAsync(int hotelId, bool includeRooms);

    Task<bool> HotelExistsAsync(int hotelId);

    Task AddHotelAsync(Hotel hotel);

    void DeleteHotel(Hotel hotel);
    
    // rooms 
    
    Task<IEnumerable<Room>> GetRoomsForHotelAsync(int hotelId);

    Task<Room?> GetRoomAsync(int hotelId, int roomId);

    Task AddRoomAsync(int hotelId, Room room);

    void DeleteRoom(Room room);
    
    // save changes to context

    Task<bool> SaveChangesAsync();
}