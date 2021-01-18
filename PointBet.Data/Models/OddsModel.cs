using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{

    public class OddsModel : ApiBaseModel
    {
       
        [JsonProperty("response")]
        public List<OddsListModel> Odds { get; set; }
    }

    public partial class OddsListModel : EntityBaseModel
    {
        [JsonProperty("league")]
        public League_OddsModel League { get; set; }

        [JsonProperty("fixture")]
        public Fixture_OddsModel Fixture { get; set; }

        [JsonProperty("update")]
        public string Update { get; set; }

        [JsonProperty("bookmakers")]
        public List<Bookmaker_OddsModel> Bookmakers { get; set; }
    }

    public partial class Bookmaker_OddsModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("bets")]
        public List<Bet_OddsModel> Bets { get; set; }
    }

    public partial class Bet_OddsModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<ValueElement> Values { get; set; }
    }

    public partial class ValueElement
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("odd")]
        public string Odd { get; set; }
    }

    public partial class Fixture_OddsModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public partial class League_OddsModel
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
    }
}
