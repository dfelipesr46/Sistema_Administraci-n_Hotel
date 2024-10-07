using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_DiegoFelipeSalamanca.Models
{
    public class Room
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The room number is required.")]
        [Column("room_number")]
        [MaxLength(10, ErrorMessage = "The room number can't be longer than {1} characters.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "The room type ID is required.")]
        [Column("room_type_id")]
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "The price per night is required.")]
        [Column("price_per_night")]
        [Range(0, double.MaxValue, ErrorMessage = "The price per night must be a positive value.")]
        public double PricePerNight { get; set; }

        [Column("availability")]
        public bool Availability { get; set; }

        [Required(ErrorMessage = "The max occupancy is required.")]
        [Column("max_occupancy")]
        [Range(1, int.MaxValue, ErrorMessage = "The max occupancy must be at least 1 person.")]
        public int MaxOccupancyPersons { get; set; }

        public ICollection<Booking> Bookings { get; set; }

    }
}
