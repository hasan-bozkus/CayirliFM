using AutoMapper;
using CayirliFM.DtoLayer.Dtos.ContactDtos;
using CayirliFM.DtoLayer.Dtos.StrategyDtos;
using CayirliFM.EntityLayer.Contrete;

namespace CayirliFM.UI.Map
{
    public class MappingRules : Profile
    {
        public MappingRules()
        {
            CreateMap<ReplyToContact, CreateReplyToContactDto>().ReverseMap();

            CreateMap<Strategy, ResultStrategyDto>().ReverseMap();
            CreateMap<Strategy, CreateStrategyDto>().ReverseMap();
            CreateMap<Strategy, ResultGetStrategyByIDDto>().ReverseMap();
            CreateMap<Strategy, UpdateStrategyDto>().ReverseMap();
        }
    }
}
