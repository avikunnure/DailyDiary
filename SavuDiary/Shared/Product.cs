using SavuDiary.Shared;
using System.ComponentModel.DataAnnotations;

namespace SavuDiary.Shared
{
    public class Product:Base
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; } = "";
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = "";
        [Required]
        [DataType(DataType.Text)]
        [MinLength(1)]
        [MaxLength(10)]
        public string Code { get; set; } = "";
        [Required]

        public string Unit { get; set; } = "";

    }
}
