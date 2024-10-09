using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Repositories
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAllGuestsAsync();
        Task<Guest> GetGuestByIdAsync(int id);
        Task<bool> DeleteGuestAsync(int id);
        Task<IEnumerable<Guest>> SearchGuestsAsync(string keyword);
        Task<bool> UpdateGuestAsync(int id, UpdateGuestDto updateGuestDto);



    }
}