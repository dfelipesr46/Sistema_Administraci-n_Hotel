using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaNET_DiegoFelipeSalamanca.Repositories;
using PruebaNET_DiegoFelipeSalamanca.Services;

namespace PruebaNET_DiegoFelipeSalamanca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {


        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }


        [HttpGet]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound($"No room found with ID {id}.");
            }
            return Ok(room);
        }


        // En RoomController.cs
        [HttpGet("occupied")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetOccupiedRooms()
        {
            var occupiedRooms = await _roomService.GetOccupiedRoomsAsync();
            return Ok(occupiedRooms);
        }


    }
}