using AutoMapper;

namespace Repository.AutoMapperConfig
{
    public class MapperProfile : Profile
    {
        private readonly int depth = 5;

        public MapperProfile()
        {
            // CreateMap<CampaignService_Campaigns, CampaignModel>().MaxDepth(depth).ReverseMap();

        }
    }
}
