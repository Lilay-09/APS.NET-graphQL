using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sync.Domain
{
    public class BaseEntity:IBaseEntity
    {
        [Key]
        [Column("id")]
        [MaxLength(50)]
        public Guid Id { get; set; }
        [Column("update_uid")]
        [MaxLength(50)]
        public string? UpdateUid { get; set; }
        [Column("create_uid")]
        [MaxLength(50)]
        public string? CreateUid { get; set; }
        [Column("is_active")]
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
        [Column("created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTime? CreatedAt { get; set; }
         
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue("CURRENT_TIMESTAMP")]
        [Column("udpated_at")]
        public DateTime? UpdatedAt { get; set; }
        public BaseEntity()
        {
            this.IsActive = true;
            this.CreatedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}
