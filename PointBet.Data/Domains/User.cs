using Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(500)]
        public string Username { get; set; }

        public byte[] Password { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPoint { get; set; }

        public int? UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }
    }
}
