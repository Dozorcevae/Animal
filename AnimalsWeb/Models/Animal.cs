using System.ComponentModel.DataAnnotations;

namespace AnimalsWeb.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Class { get; set; }

        [Range(0.5, 100)]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Species { get; set; }

        [Range(0.5, 300)]
        public double Weight {  get; set; }
    }
}

