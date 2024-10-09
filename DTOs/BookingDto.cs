using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_DiegoFelipeSalamanca.DTOs
{
    public class BookingDto
    {
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalCost { get; set; }
    }
}