using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavuDiary.Shared
{
    public class RegisterUsers
    {
        [Required]
        public string UserName { get; set; } = "";
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        [MinLength(10)]
        [MaxLength(13)]
        
        public string MobileNo { get; set; } = "";
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = "";
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = "";

    }
}
