using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{

    public  class FixturesApiModel : ApiBaseModel
    {
        [JsonProperty("response")]
        public List<FixturesModel> Fixtures { get; set; }
    }


    public partial class FixturesModel : EntityBaseModel
    {
        [JsonProperty("fixture")]
        public Fixture Fixture { get; set; }    

        [JsonProperty("league")]
        public League_FixturesModel League { get; set; }

        [JsonProperty("teams")]
        public Teams_FixtureModel Teams { get; set; }

        [JsonProperty("goals")]
        public Goals Goals { get; set; }

        [JsonProperty("score")]
        public Score Score { get; set; }
        [JsonProperty("events")]
        public Events Events { get; set; }
    }
    public partial class Teams_FixtureModel
    {
        public Team_FixtureModel Home { get; set; }
        public Team_FixtureModel Away { get; set; }
    }
    public partial class Team_FixtureModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("winner")]
        public bool? Winner { get; set; }
    }
    public partial class Fixture
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("referee")]
        public string Referee { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("periods")]
        public Periods Periods { get; set; }

        [JsonProperty("venue")]
        public Venue_FixturesModel Venue { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public partial class Periods
    {
        [JsonProperty("first")]
        public long? First { get; set; }

        [JsonProperty("second")]
        public long? Second { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("long")]
        public string Long { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }

        [JsonProperty("elapsed")]
        public int? Elapsed { get; set; }
    }

    public partial class Venue_FixturesModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }

    public partial class League_FixturesModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("season")]
        public long Season { get; set; }

        [JsonProperty("round")]
        public string Round { get; set; }
    }


    public partial class Goals
    {
        [JsonProperty("home")]
        public int? Home { get; set; }

        [JsonProperty("away")]
        public int? Away { get; set; }
    }

    public partial class Score
    {
        [JsonProperty("halftime")]
        public Goals Halftime { get; set; }

        [JsonProperty("fulltime")]
        public Goals Fulltime { get; set; }

        [JsonProperty("extratime")]
        public Goals Extratime { get; set; }

        [JsonProperty("penalty")]
        public Goals Penalty { get; set; }
    }

    public class Events
    {
        [JsonProperty("time")]
        public Time Time { get; set; }
        [JsonProperty("team")]
        public Team_FixtureModel Team { get; set; }
        [JsonProperty("player")]
        public Player Player { get; set; }
        [JsonProperty("assist")]
        public Player Assist { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("detail")]
        public string Detail { get; set; }
        [JsonProperty("comments")]
        public string Comments { get; set; }
    }

    public class Time
    {
        [JsonProperty("elapsed")]
        public int Elapsed { get; set; }
        [JsonProperty("extra")]
        public object Extra { get; set; }
    }


    public class Player
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

 
}
