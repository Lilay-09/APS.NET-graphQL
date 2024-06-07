using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain.UM
{

    [Table("permissions")]
    public class Permission:BaseEntity
    {
        [MaxLength(50)]
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        [MaxLength(250)]
        public string? Description {get;set;}
    }
}
