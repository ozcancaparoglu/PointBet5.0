using Common.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PointBet.Data.Models.ApiCommon;

namespace PointBet.Data.Models
{
    public class VenueModel : EntityBaseModel
    {
        public int? CountryId { get; set; }
        public virtual CountryModel Country { get; set; }

        [Required]
        [JsonProperty("id")]
        public int ApiId { get; set; }

        [Required]
        [StringLength(250)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [StringLength(250)]
        [JsonProperty("city")]
        public string City { get; set; }

        [Required]
        [StringLength(25)]
        [JsonProperty("country")]
        public string CountryName { get; set; }

        [JsonProperty("capacity")]
        public int Capacity { get; set; }

        [StringLength(50)]
        [JsonProperty("surface")]
        public string Surface { get; set; }

        [StringLength(200)]
        [JsonProperty("image")]
        public string Image { get; set; }

        public int CustomApiId { get; set; }
    }

    public class VenueApiModel : ApiBaseModel
    {
        [JsonProperty("response")]
        public List<VenueModel> Venues { get; set; }
    }
}
