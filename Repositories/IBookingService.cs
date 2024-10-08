using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Repositories
{
    public interface IBookingService
    {
        // Otros métodos ya definidos

        Task<IEnumerable<Booking>> SearchBookingsByIdentificationAsync(string identificationNumber);
    }
}
