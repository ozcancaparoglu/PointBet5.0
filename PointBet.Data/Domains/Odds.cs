using Common.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class Odds : EntityBase
    {
        [JsonProperty("league")]
        public League League { get; set; }

        //[JsonProperty("fixture")]
        //public Fixture Fixture { get; set; }

        //[JsonProperty("update")]
        //public string Update { get; set; }

        //[JsonProperty("bookmakers")]
        //public List<Bookmaker_OddsModel> Bookmakers { get; set; }
    }
}
