using AutoMapper;
using MTGMVC.DTOs.Custom;
using MTGMVC.DTOs.Scryfall.Cards;

namespace MTGMVC.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ScryfallCardDto, CleanCardDto>();
    }
    }
}
