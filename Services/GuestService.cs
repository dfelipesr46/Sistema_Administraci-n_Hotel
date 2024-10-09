using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Services
{
    public class GuestService
    {
        private readonly ApplicationDbContext _context;

        public GuestService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await _context.Guests.ToListAsync();
        }


        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await _context.Guests.FindAsync(id);
        }


        public async Task<bool> DeleteGuestAsync(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null) return false;

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<Guest>> SearchGuestsAsync(string keyword)
        {
            return await _context.Guests
                .Where(g => g.FirstName.Contains(keyword) || g.Email.Contains(keyword) || g.LastName.Contains(keyword))
                .ToListAsync();
        }


        // En GuestService.cs
        public async Task<bool> UpdateGuestAsync(int id, UpdateGuestDto updateGuestDto)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null) return false;

            guest.FirstName = updateGuestDto.FirstName;
            guest.LastName = updateGuestDto.LastName;
            guest.Email = updateGuestDto.Email;
            guest.IdentificationNumber = updateGuestDto.IdentificationNumber;
            guest.PhoneNumber = updateGuestDto.PhoneNumber;
            guest.Birthdate = updateGuestDto.Birthdate;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}