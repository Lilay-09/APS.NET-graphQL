using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain.Items
{
    [Table("products")]
    public class Product:BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("group_id")]
        [ForeignKey("Group")]
        public Guid GroupId { get; set; }
        public Group Group { get; set; } = null;
    }
}
