using Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public class VenueModel : EntityBaseModel
    {
        public int? CountryId { get; set; }
        public virtual CountryModel Country { get; set; }

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
    }
}
