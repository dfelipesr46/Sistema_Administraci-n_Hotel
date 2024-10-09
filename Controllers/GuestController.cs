using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_DiegoFelipeSalamanca.DTOs;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public
        GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }


        [HttpGet]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestService.GetAllGuestsAsync();
            return Ok(guests);
        }



        [HttpGet("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestService.GetGuestByIdAsync(id);
            if (guest == null)
            {
                return NotFound($"No guest found with ID {id}.");
            }
            return Ok(guest);
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var result = await _guestService.DeleteGuestAsync(id);
            if (!result)
            {
                return NotFound($"No guest found with ID {id}.");
            }
            return NoContent();
        }



        [HttpGet("search/{keyword}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> SearchGuests(string keyword)
        {
            var guests = await _guestService.SearchGuestsAsync(keyword);
            return Ok(guests);
        }



        // En GuestController.cs
        [HttpPut("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateGuest(int id, [FromBody] UpdateGuestDto updateGuestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _guestService.UpdateGuestAsync(id, updateGuestDto);
            if (!result)
            {
                return NotFound($"No guest found with ID {id}.");
            }
            return NoContent();
        }



        
    }
}