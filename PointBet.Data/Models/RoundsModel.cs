using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{

    public class RoundsModel : ApiBaseModel
    {
        [JsonProperty("response")]
        public List<string> Response { get; set; }
    }
}
