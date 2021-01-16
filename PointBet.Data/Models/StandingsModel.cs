using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public class StandingsApiModel : ApiBaseModel
    {
        [JsonProperty("response")]
        public List<StandingsModel> Standings { get; set; }
    }
    public class StandingsModel : EntityBaseModel
    {
        [JsonProperty("league")]
        public LeagueStanding League { get; set; }
    }

    public partial class LeagueStanding : EntityBaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("season")]
        public int Season { get; set; }

        [JsonProperty("standings")]
        public List<List<Standing>> Standings { get; set; }
    }

    public partial class Standing
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("team")]
        public TeamStanding Team { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("goalsDiff")]
        public int GoalsDiff { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        [JsonProperty("form")]
        public string Form { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("all")]
        public All All { get; set; }

        [JsonProperty("home")]
        public All Home { get; set; }

        [JsonProperty("away")]
        public All Away { get; set; }

        [JsonProperty("update")]
        public string Update { get; set; }
    }

    public partial class All
    {
        [JsonProperty("played")]
        public int Played { get; set; }

        [JsonProperty("win")]
        public int Win { get; set; }

        [JsonProperty("draw")]
        public int Draw { get; set; }

        [JsonProperty("lose")]
        public int Lose { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }
    }

    public partial class Goals
    {
        [JsonProperty("for")]
        public int For { get; set; }

        [JsonProperty("against")]
        public int Against { get; set; }
    }

    public partial class TeamStanding
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }
    }
}
