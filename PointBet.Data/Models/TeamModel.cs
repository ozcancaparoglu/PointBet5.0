using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public class TeamModel : EntityBaseModel
    {
        public int? LeagueId { get; set; }
        public virtual LeagueModel League { get; set; }
        
        public int? VenueId { get; set; }
        public virtual VenueModel Venue { get; set; }
        
        [Required]
        public int ApiId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public int? Founded { get; set; }

        public bool National { get; set; }

        [StringLength(200)]
        public string Logo { get; set; }

        public ICollection<TeamStatisticModel> TeamStatistics { get; set; }
    }
}