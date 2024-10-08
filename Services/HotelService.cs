using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.Models;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Services
{
    public class HotelService : IHotelService
    {
        private readonly ApplicationDbContext _context;

        public HotelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AuthenticateEmployeeAsync(string email, string password)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
        }

        public async Task<List<Room>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms.Where(r => r.Availability).ToListAsync();
        }

        public async Task<List<RoomType>> GetRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await _context.RoomTypes.FindAsync(id);
        }

        public async Task<RoomStatus> GetRoomsStatusAsync()
        {
            var totalRooms = await _context.Rooms.CountAsync();
            var occupiedRooms = await _context.Rooms.CountAsync(r => !r.Availability);
            return new RoomStatus
            {
                TotalRooms = totalRooms,
                OccupiedRooms = occupiedRooms,
                AvailableRooms = totalRooms - occupiedRooms
            };
        }


        public async Task<Guest> RegisterGuestAsync(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest;
        }
    }
}