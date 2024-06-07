using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain.Items
{
    [Table("groups")]
    public class Group:BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; }
        [Column("description")]
        public string? Description { get; set; }

        [Column("category_id")]
        [ForeignKey("Category")]
        [Required]
        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
