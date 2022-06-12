using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavuDiary.Shared
{
    public class Base
    {   
        public Guid Id { get; set; }
        
        public bool IsActive { get; set; }=true;

    }
}
