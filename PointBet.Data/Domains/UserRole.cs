using Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Domains
{
    public class UserRole : EntityBase
    {
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
    }
}