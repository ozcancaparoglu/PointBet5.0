namespace PointBet.Services.Helpers
{
    public class CacheStatics
    {
        /// <summary>
        /// All Countries
        /// </summary>
        public const string Countries = "countries";
        public const int CountriesCacheTime = 1440;

        /// <summary>
        /// All Seasons
        /// </summary>
        public const string Seasons = "seasons";
        public const int SeasonsCacheTime = 1440;

        /// <summary>
        /// All Leagues
        /// </summary>
        public const string Leagues = "leagues";
        public const int LeaguesCacheTime = 1440;

        /// <summary>
        /// All Teams
        /// </summary>
        public const string Teams = "teams";
        public const int TeamsCacheTime = 1440;

        /// <summary>
        /// All Venues
        /// </summary>
        public const string Venues = "venues";
        public const int VenuesCacheTime = 1440;
    }
}
