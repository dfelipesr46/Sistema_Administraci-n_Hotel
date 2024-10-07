using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaNET_DiegoFelipeSalamanca.Models
{
    public class Booking
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Column("roomId")]
        public int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; } 



        [Column("guestId")]
        public int GuestId { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; } 



        [Column("employeeId")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } 



        [Required(ErrorMessage = "The booking date is required.")]
        [Column("start_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The booking end date is required.")]
        [Column("end_date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EndDate { get; set; }

        [Column("total_cost")]
        public double TotalCost { get; set; }
    }
}
