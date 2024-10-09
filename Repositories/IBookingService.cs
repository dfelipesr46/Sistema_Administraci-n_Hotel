using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Repositories
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> SearchBookingsByIdentificationAsync(string identificationNumber);
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> CreateBookingAsync(BookingDto bookingDto);
        Task<bool> DeleteBookingAsync(int id);


    }
}
