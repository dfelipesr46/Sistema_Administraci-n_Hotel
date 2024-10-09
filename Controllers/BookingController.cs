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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }



        [HttpGet("search/{identification_number}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> SearchBookingsByIdentification(string identification_number)
        {
            var bookings = await _bookingService.SearchBookingsByIdentificationAsync(identification_number);
            if (bookings == null || !bookings.Any())
            {
                return NotFound("No bookings found for the given identification number.");
            }
            return Ok(bookings);
        }



        [HttpGet("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound($"No booking found with ID {id}.");
            }
            return Ok(booking);
        }



        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booking = await _bookingService.CreateBookingAsync(bookingDto);
            return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, booking);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (!result)
            {
                return NotFound($"No booking found with ID {id}.");
            }
            return NoContent();
        }


        

    }
}