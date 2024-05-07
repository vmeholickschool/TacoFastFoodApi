using System.ComponentModel.DataAnnotations;

namespace TacoFastFoodAPI.Models
{
    public class Taco
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Single Cost { get; set; }

        public bool SoftShell { get; set; }

        public bool Chips { get; set; }
    }
}
