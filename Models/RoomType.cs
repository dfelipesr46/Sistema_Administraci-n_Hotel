using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaNET_DiegoFelipeSalamanca.Models
{
    public class RoomType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The room type name is required.")]
        [Column("name")]
        [MaxLength(50, ErrorMessage = "The room type name can't be longer than {1} characters.")]
        public string Name { get; set; }

        [Column("description")]
        [MaxLength(255, ErrorMessage = "The description can't be longer than {1} characters.")]
        public string Description { get; set; }
    }
}
