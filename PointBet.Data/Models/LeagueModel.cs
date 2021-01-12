using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public class LeagueModel : EntityBaseModel
    {
        public int? CountryId { get; set; }
        public virtual CountryModel Country { get; set; }

        public int? SeasonId { get; set; }
        public virtual SeasonModel Season { get; set; }

        [Required]
        public int ApiId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(200)]
        public string Logo { get; set; }

        public ICollection<TeamModel> Teams { get; set; }
    }
}
