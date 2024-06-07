using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain.Items
{
    [Table("categories")]
    public class Category:BaseEntity
    {
        [Column("name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Group>? Groups { get; set; } = null;
    }
}
