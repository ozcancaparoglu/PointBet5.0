using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class League : EntityBase
    {
        public int? CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public int? SeasonId { get; set; }

        [ForeignKey("SeasonId")]
        public virtual Season Season { get; set; }

        [Required]
        public int ApiId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(200)]
        public string Logo { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
