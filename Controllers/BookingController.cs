using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public async Task<IActionResult> SearchBookingsByIdentification(string identification_number)
        {
            var bookings = await _bookingService.SearchBookingsByIdentificationAsync(identification_number);
            if (bookings == null || !bookings.Any())
            {
                return NotFound("No bookings found for the given identification number.");
            }
            return Ok(bookings);
        }
    }
}