using System.ComponentModel.DataAnnotations;

namespace Papara_cohort.Models
{
    public class CustomerDto
    {
        [Required]
        [Range(1, 10000)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(18, 150)]
        public int Age { get; set; }
    }

    public class CustomerUpdateDto
    {
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Range(18, 150)]
        public int? Age { get; set; }
    }
}
