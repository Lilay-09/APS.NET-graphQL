using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain.UM
{
    [Table("roles")]
    public class Role:BaseEntity
    {
        [Required]
        [Column("name")]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Column("description")]
        [MaxLength(250)]
        public string? Description { get; set; }

    }
}
