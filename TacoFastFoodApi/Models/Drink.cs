using System.ComponentModel.DataAnnotations;

namespace TacoFastFoodAPI.Models
{
    public class Drink
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Single Cost { get; set; }

        public bool Slushie { get; set; }
    }
}

