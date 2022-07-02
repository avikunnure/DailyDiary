using System.ComponentModel.DataAnnotations;

namespace SavuDiary.Shared
{
    public class Supplier:Base
    {
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";

        [Required]
        [MinLength(7)]
        [MaxLength(13)]
        
        public string MobileNo { get; set; } = "";

        [EmailAddress]
        
        public string? EmailId { get; set; }


    }
}
