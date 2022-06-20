using System.ComponentModel.DataAnnotations;

namespace SavuDiary.Shared
{
    public class Customer:Base
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
        public string EmailId { get; set; } = "";

        [Required]       
        public long SequenceNo { get; set; }

    }
}
