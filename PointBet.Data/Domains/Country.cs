using Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Domains
{
    public class Country : EntityBase
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(2)]
        public string Code { get; set; }

        [StringLength(200)]
        public string Flag { get; set; }

    }
}
