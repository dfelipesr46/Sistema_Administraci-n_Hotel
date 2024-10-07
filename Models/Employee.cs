using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaNET_DiegoFelipeSalamanca.Models
{
    public class Employee
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "The first name is required.")]
        [Column("first_name")]
        [MaxLength(50, ErrorMessage = "The first name can't be longer than {1} characters.")]
        [MinLength(1, ErrorMessage = "The first name can't be shorter than {1} character.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "The last name is required.")]
        [Column("last_name")]
        [MaxLength(50, ErrorMessage = "The last name can't be longer than {1} characters.")]
        [MinLength(1, ErrorMessage = "The last name can't be shorter than {1} character.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "The email is required.")]
        [Column("email")]
        [MaxLength(255, ErrorMessage = "The email can't be longer than {1} characters.")]
        [MinLength(1, ErrorMessage = "The email can't be shorter than {1} character.")]
        [EmailAddress(ErrorMessage = "You must write a correct email format.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The identification number is required.")]
        [Column("identification_number")]
        [MaxLength(20, ErrorMessage = "The identification number can't be longer than {1} characters.")]
        [MinLength(1, ErrorMessage = "The identification number can't be shorter than {1} character.")]
        public string IdentificationNumber { get; set; }
        

        [Required(ErrorMessage = "The password is required.")]
        [Column("password")]
        [MaxLength(100, ErrorMessage = "The password can't be longer than {1} characters.")]
        [MinLength(8, ErrorMessage = "The password must be at least {1} characters long.")]
        public string Password { get; set; }
    }
}
