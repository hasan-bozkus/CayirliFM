using AutoMapper;
using CayirliFM.DtoLayer.Dtos.ContactDtos;
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
