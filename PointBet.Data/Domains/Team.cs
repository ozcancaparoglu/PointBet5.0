using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class Team : EntityBase
    {
        public int? LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public virtual League League { get; set; }

        public int? VenueId { get; set; }

        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }

        [Required]
        public int ApiId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int? Founded { get; set; }

        public bool National { get; set; }

        [StringLength(200)]
        public string Logo { get; set; }

        public ICollection<TeamStatistic> TeamStatistics { get; set; }
    }
}
