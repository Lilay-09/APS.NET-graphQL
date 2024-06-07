
using sync.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain.UM
{
    [Table("users")]
    public class User:BaseEntity
    {
        [MaxLength(50)]
        [Column("first_name")]
        [Required]
        public string? FirstName { get; set; }
        [Column("last_name")]
        [MaxLength(50)]
        public string? LastName { get; set; }
        [MaxLength(50)]
        [Column("email")]
        public string? Email { get; set; }
        [MaxLength(300)]
        [Column("password")]
        [Required]
        public string Paswword { get; set; }
        [MaxLength(30)]
        [Column("phone")]
        public string? Phone { get; set;}
        [MaxLength(60)]
        [Column("salt")]
        public byte? Salt { get; set; }

        [Column("branch_id")]
        public Guid? BranchId { get; set; }

    }
}
