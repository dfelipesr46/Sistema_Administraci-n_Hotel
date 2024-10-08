using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.Models;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Services
{
    public class RoomStatusService : IRoomStatusService
    {
        private readonly ApplicationDbContext _context;

        public RoomStatusService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoomStatus>> GetRoomStatusesAsync()
        {
            return await _context.RoomStatuses.ToListAsync();
        }

        public async Task<RoomStatus> GetRoomStatusByIdAsync(int id)
        {
            return await _context.RoomStatuses.FindAsync(id);
        }

        public async Task<List<Room>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms
                .Where(r => r.Availability) // Filtrar solo habitaciones disponibles
                .ToListAsync();
        }
    }
}
