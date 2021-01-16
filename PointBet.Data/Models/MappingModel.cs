using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public partial class MappingApiModel : ApiBaseModel
    {
        [JsonProperty("response")]
        public List<MappingModel> Mapping { get; set; }
    }


    public partial class MappingModel : EntityBaseModel
    {
        [JsonProperty("league")]
        public League_Mapping League { get; set; }

        [JsonProperty("fixture")]
        public Fixture_Mapping Fixture { get; set; }

        [JsonProperty("update")]
        public string Update { get; set; }
    }

    public partial class Fixture_Mapping
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
    }

    public partial class League_Mapping
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("season")]
        public long Season { get; set; }
    }
}
