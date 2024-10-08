using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.Models;
using PruebaNET_DiegoFelipeSalamanca.Repositories;

namespace PruebaNET_DiegoFelipeSalamanca.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        /// <summary>
        /// Get all available rooms.
        /// </summary>
        /// <returns>List of available rooms.</returns>
        /// <response code="200">Returns the list of available rooms.</response>

        [HttpGet("rooms/available")]
        [ProducesResponseType(200)]

        public async Task<IActionResult> GetAvailableRooms()
        {
            var availableRooms = await _hotelService.GetAvailableRoomsAsync();
            return Ok(availableRooms);
        }


        /// <summary>
        /// Get all room types.
        /// </summary>
        /// <returns>List of room types.</returns>
        /// <response code="200">Returns the list of room types.</response>
        
        [HttpGet("room_types")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetRoomTypes()
        {
            var roomTypes = await _hotelService.GetRoomTypesAsync();
            return Ok(roomTypes);
        }

        [HttpGet("room_types/{id}")]
        public async Task<IActionResult> GetRoomType(int id)
        {
            var roomType = await _hotelService.GetRoomTypeByIdAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return Ok(roomType);
        }

        [HttpGet("rooms/status")]
        public async Task<IActionResult> GetRoomsStatus()
        {
            var status = await _hotelService.GetRoomsStatusAsync();
            return Ok(status);
        }

        [HttpPost("guest")]
        public async Task<IActionResult> RegisterGuest([FromBody] Guest guest)
        {
            var registeredGuest = await _hotelService.RegisterGuestAsync(guest);
            return CreatedAtAction(nameof(GetRoomType), new { id = registeredGuest.Id }, registeredGuest);
        }
    }


}