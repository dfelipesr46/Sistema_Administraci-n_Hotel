using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Repositories
{
    public interface IHotelService
    {
        Task<Employee> AuthenticateEmployeeAsync(string email, string password);
        Task<List<Room>> GetAvailableRoomsAsync();
        Task<List<RoomType>> GetRoomTypesAsync();
        Task<RoomType> GetRoomTypeByIdAsync(int id);
        Task<RoomStatus> GetRoomsStatusAsync();
        Task<Guest> RegisterGuestAsync(Guest guest);
    }
}