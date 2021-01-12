using Common.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointBet.Data.Domains
{
    public class TeamStatistic : EntityBase
    {
        public int? TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }

        public int? LeagueId { get; set; }
        [ForeignKey("LeagueId")]
        public virtual League League { get; set; }

        [StringLength(100)]
        public string Form { get; set; }

        #region Fixture

        public int HomePlayed { get; set; }
        public int AwayPlayed { get; set; }

        public int HomeWin { get; set; }
        public int AwayWin { get; set; }

        public int HomeDraw { get; set; }
        public int AwayDraw { get; set; }

        public int HomeLose { get; set; }
        public int AwayLose { get; set; }

        #endregion

        #region Goals

        public int HomeGoalsFor { get; set; }
        public int AwayGoalsFor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HomeGoalsForAverage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AwayGoalsForAverage { get; set; }

        public int HomeGoalsAgainst { get; set; }
        public int AwayGoalsAgainst { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HomeGoalsAgainstAverage { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal AwayGoalsAgainstAverage { get; set; }

        public int HomeCleanSheet { get; set; }
        public int AwayCleanSheet { get; set; }

        public int HomeFailedToScore { get; set; }
        public int AwayFailedToScore { get; set; }

        #endregion

        #region Biggest

        public int BiggestWinStreak { get; set; }
        public int BiggestDrawStreak { get; set; }
        public int BiggestLoseStreak { get; set; }

        [StringLength(10)]
        public string BiggestHomeWin { get; set; }
        [StringLength(10)]
        public string BiggestAwayWin { get; set; }

        [StringLength(10)]
        public string BiggestHomeLose { get; set; }
        [StringLength(10)]
        public string BiggestAwayLose { get; set; }

        public int BiggestHomeGoalFor { get; set; }
        public int BiggestHomeGoalAgainst { get; set; }

        public int BiggestAwayGoalFor { get; set; }
        public int BiggestAwayGoalAgainst { get; set; }

        #endregion



    }
}
