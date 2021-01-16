using Common.Entities;
using Newtonsoft.Json;
using PointBet.Data.Models.ApiCommon;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PointBet.Data.Models
{
    public partial class BookMakersApiModel : ApiBaseModel
    {
       
        [JsonProperty("response")]
        public List<BookMakersModel> BookMakers { get; set; }
    }


    public partial class BookMakersModel : EntityBaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
