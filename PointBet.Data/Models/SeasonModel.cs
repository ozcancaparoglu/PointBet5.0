using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System;
using System.Collections.Generic;

namespace PointBet.Data.Models
{
    public class SeasonModel : EntityBaseModel
    {
        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("start")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("end")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("current")]
        public bool Current { get; set; }

        public int CustomApiId { get; set; }
    }

    public class SeasonApiResponse
    {
        [JsonProperty("league")]
        public LeagueModel League { get; set; }

        [JsonProperty("country")]
        public CountryModel Country { get; set; }

        [JsonProperty("seasons")]
        public List<SeasonModel> Seasons { get; set; }
    }

    public class SeasonApiModel : ApiBaseModel
    {
        [JsonProperty("response")]
        public List<SeasonApiResponse> Response { get; set; }
    }
}