using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace sync.Domain
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public string? UpdateUid { get; set; } 
        public string? CreateUid { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
