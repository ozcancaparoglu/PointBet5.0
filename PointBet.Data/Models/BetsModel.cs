using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public partial class BetsModel : EntityBaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public partial class BetsApiModel : ApiBaseModel
    {

        [JsonProperty("response")]
        public List<BetsModel> Bets { get; set; }
    }
}
