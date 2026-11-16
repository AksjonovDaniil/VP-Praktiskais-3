using System.ComponentModel.DataAnnotations;

namespace Lab2.DataAccess
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Species { get; set; } = string.Empty;

        public int Age { get; set; }

        public int OwnerId { get; set; }

        public Owner? Owner { get; set; }

        public int VeterinarianId { get; set; }

        public Veterinarian? Veterinarian { get; set; }
    }
}