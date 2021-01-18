using Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class Fixtures : EntityBase
    {
        public int FixtureId { get; set; }

        [ForeignKey("FixtureId")]
        public virtual Fixture Fixture { get; set; }

        public int LeagueId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int Goals_Home { get; set; }
        public int Goals_Away { get; set; }
        public int Score_Halftime_Home { get; set; }
        public int Score_Halftime_Away { get; set; }
        public int Score_Fulltime_Home { get; set; }
        public int Score_Fulltime_Away { get; set; }
        public int Score_Extratime_Home { get; set; }
        public int Score_Extratime_Away { get; set; }
        public int Score_Penalty_Home { get; set; }
        public int Score_Penalty_Away { get; set; }
        //  public Events Events { get; set; }
    }
    public class Fixture : EntityBase
    {
        //public int ApiId { get; set; }
        //public string Referee { get; set; }
        //public string Timezone { get; set; }
        //public string Date { get; set; }
        //public long Timestamp { get; set; }
        //public Periods Periods { get; set; }
        //public int VenueId { get; set; }
        //public Status { get; set; }
    }
}

