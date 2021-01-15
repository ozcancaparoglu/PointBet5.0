using Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class Venue : EntityBase
    {
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Required]
        public int ApiId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [Required]
        [StringLength(250)]
        public string City { get; set; }

        public int Capacity { get; set; }

        [StringLength(50)]
        public string Surface { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public int CustomApiId { get; set; }

    }
}
