using AutoMapper;
using CayirliFM.DtoLayer.Dtos;
using CayirliFM.EntityLayer.Contrete;

namespace CayirliFM.UI.Map
{
    public class MappingRules : Profile
    {
        public MappingRules()
        {
            CreateMap<ReplyToContact, CreateReplyToContactDto>().ReverseMap();
        }
    }
}
