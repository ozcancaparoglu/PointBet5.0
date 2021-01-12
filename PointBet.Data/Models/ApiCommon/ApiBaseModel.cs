using Newtonsoft.Json;
using System.Collections.Generic;

namespace PointBet.Data.Models.ApiCommon
{
    public abstract class ApiBaseModel 
    {
        [JsonProperty("get")]
        public string Get { get; set; }

        [JsonProperty("errors")]
        public List<object> Errors { get; set; }

        [JsonProperty("results")]
        public long Results { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }

    public partial class Paging
    {
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
