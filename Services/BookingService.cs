using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Models;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> SearchBookingsByIdentificationAsync(string identificationNumber)
        {
            return await _context.Bookings
                .Include(b => b.Guest)
                .Where(b => b.Guest.IdentificationNumber == identificationNumber)
                .ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
        .Include(b => b.Guest)
        .Include(b => b.Room)
        .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Booking> CreateBookingAsync(BookingDto bookingDto)
        {
            var booking = new Booking
            {
                GuestId = bookingDto.GuestId,
                RoomId = bookingDto.RoomId,
                EmployeeId = bookingDto.EmployeeId,
                StartDate = bookingDto.CheckInDate,
                EndDate = bookingDto.CheckOutDate,
                TotalCost = bookingDto.TotalCost,
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
