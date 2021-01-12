using Common.Entities;
using PointBet.Data.Models.ApiCommon;
using System;

namespace PointBet.Data.Models
{
    public class SeasonModel : EntityBaseModel
    {
        public int Year { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Current { get; set; }
    }

    public class SeasonApiModel : ApiBaseModel
    {

    }
}