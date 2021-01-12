using Common.Entities;
using System;

namespace PointBet.Data.Domains
{
    public class Season : EntityBase
    {
        public int Year { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Current { get; set; }
    }
}
