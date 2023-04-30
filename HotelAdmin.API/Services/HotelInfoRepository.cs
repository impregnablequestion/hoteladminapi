using HotelAdmin.API.DbContexts;
using HotelAdmin.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelAdmin.API.Services;

public class HotelInfoRepository : IHotelInfoRepository
{
    private readonly HotelContext _context;

    #region Hotels
    public HotelInfoRepository(HotelContext hotelContext)
    {
        _context = hotelContext ?? throw new ArgumentNullException(nameof(hotelContext));
    }

    public async Task<IEnumerable<Hotel>> GetHotelsAsync()
    {
        return await _context.Hotels.OrderBy(h => h.Name).ToListAsync();
    }

    public async Task<Hotel?> GetHotelAsync(int hotelId, bool includeRooms)
    {
        if (includeRooms)
        {
            return await _context.Hotels
                .Include(h => h.Rooms)
                .Where(h => h.Id == hotelId)
                .FirstOrDefaultAsync();
        }
        
        return await _context.Hotels
            .Where(h => h.Id == hotelId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> HotelExistsAsync(int hotelId)
    {
        return await _context.Hotels.AnyAsync(h => h.Id == hotelId);
    }

    public async Task AddHotelAsync(Hotel hotel)
    {
        await _context.AddAsync(hotel);
    }

    public void DeleteHotelAsync(Hotel hotel)
    {
        _context.Remove(hotel);
    }
    #endregion

    #region Rooms
    public async Task<IEnumerable<Room>> GetRoomsForHotelAsync(int hotelId)
    {
        return await _context.Rooms
            .Where(r => r.HotelId == hotelId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Room>> GetRoomAsync(int hotelId, int roomId)
    {
        return await _context.Rooms
            .Where(r => r.HotelId == hotelId && r.Id == roomId)
            .ToListAsync();
    }

    public async Task AddRoomAsync(int hotelId, Room room)
    {
        var hotel = await GetHotelAsync(hotelId, false);
        hotel?.Rooms.Add(room);
    }

    public void DeleteRoomAsync(Room room)
    {
        _context.Rooms.Remove(room);
    }
    #endregion
    
    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}