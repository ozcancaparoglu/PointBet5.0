using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public class CountryModel : EntityBaseModel
    {
        [Required]
        [StringLength(100)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [StringLength(2)]
        [JsonProperty("code")]
        public string Code { get; set; }

        [StringLength(200)]
        [JsonProperty("flag")]
        public string Flag { get; set; }
    }

    public class CountryApiModel : ApiBaseModel
    {
        [JsonProperty(PropertyName = "response")]
        public List<CountryModel> Countries { get; set; }
    }

}
