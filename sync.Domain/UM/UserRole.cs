using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain.UM
{
    [Table("user_roles")]
    public class UserRole
    {
        [Key]
        [Column("user_id")]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; } = null;

        [Key]
        [Column("role_id")]
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Role? Role { get; set; } = null;

    }
}
