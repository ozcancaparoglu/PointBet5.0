using AutoMapper;
using PointBet.Data.Domains;
using PointBet.Data.Models;

namespace PointBet.Data.AutoMapperProfile
{
    public class MapperProfile : Profile
    {
        private readonly int depth = 5;

        public MapperProfile()
        {
            CreateMap<Country, CountryModel>().MaxDepth(depth).ReverseMap();
            CreateMap<League, LeagueModel>().MaxDepth(depth).ReverseMap();
            CreateMap<Season, SeasonModel>().MaxDepth(depth).ReverseMap();
            CreateMap<Team, TeamModel>().MaxDepth(depth).ReverseMap();
            CreateMap<TeamStatistic, TeamStatisticModel>().MaxDepth(depth).ReverseMap();
            CreateMap<User, UserModel>().MaxDepth(depth).ReverseMap();
            CreateMap<UserRole, UserRoleModel>().MaxDepth(depth).ReverseMap();
            CreateMap<Venue, VenueModel>().MaxDepth(depth).ReverseMap();
            CreateMap<BookMakers, BookMakersModel>().MaxDepth(depth).ReverseMap();
            CreateMap<Bets, BetsModel>().MaxDepth(depth).ReverseMap();
        }
    }
}
