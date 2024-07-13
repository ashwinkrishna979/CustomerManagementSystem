using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMS.CoreBusiness.Models
{
    public class Customer
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            [Required]
            public required string Name { get; set; }
            [Required]
            public required string Email { get; set; }
            [Required]
            public required string Phone { get; set; }
        }
}