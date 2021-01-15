using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
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
        [JsonProperty("id")]
        public int ApiId { get; set; }

        [StringLength(200)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("founded")]
        public int? Founded { get; set; }

        [JsonProperty("national")]
        public bool National { get; set; }

        [StringLength(200)]
        [JsonProperty("logo")]
        public string Logo { get; set; }

        public ICollection<TeamStatisticModel> TeamStatistics { get; set; }
    }

    public class TeamApiResponse
    {
        [JsonProperty("team")]
        public TeamModel Team { get; set; }

        [JsonProperty("venue")]
        public VenueModel Venue { get; set; }
    }

    public class TeamApiModel : ApiBaseModel
    {
        [JsonProperty("response")]
        public List<TeamApiResponse> Response { get; set; }
    }
}