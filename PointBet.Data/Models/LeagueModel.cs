using Common.Entities;
using Newtonsoft.Json;
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
        [JsonProperty("id")]
        public int ApiId { get; set; }

        [Required]
        [StringLength(250)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [StringLength(50)]
        [JsonProperty("type")]
        public string Type { get; set; }

        [StringLength(200)]
        [JsonProperty("logo")]
        public string Logo { get; set; }

        public ICollection<TeamModel> Teams { get; set; }
    }
}
