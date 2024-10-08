using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Repositories
{
    public interface IRoomStatusService
    {
        Task<List<RoomStatus>> GetRoomStatusesAsync();
        Task<RoomStatus> GetRoomStatusByIdAsync(int id);
        Task<List<Room>> GetAvailableRoomsAsync();
    }
}