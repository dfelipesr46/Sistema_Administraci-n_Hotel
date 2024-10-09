using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.Models;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Services
{
    public class RoomService
    {

        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }


        // En RoomService.cs
        public async Task<IEnumerable<Room>> GetOccupiedRoomsAsync()
        {
            return await _context.Rooms
                .Where(r => _context.Bookings.Any(b => b.RoomId == r.Id && b.EndDate > DateTime.Now))
                .ToListAsync();
        }


    }
}