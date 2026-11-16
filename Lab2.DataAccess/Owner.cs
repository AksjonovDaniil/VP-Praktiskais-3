using System.ComponentModel.DataAnnotations;

namespace Lab2.DataAccess
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Surname { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public List<Animal> Animals { get; set; } = new();
    }
}