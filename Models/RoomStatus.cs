using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_DiegoFelipeSalamanca.Models
{
    public class RoomStatus
    {
        public int Id {get; set;}
        public int TotalRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int AvailableRooms { get; set; }
    }
}