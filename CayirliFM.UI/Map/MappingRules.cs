using AutoMapper;
using CayirliFM.DtoLayer.Dtos.AddressDtos;
using CayirliFM.DtoLayer.Dtos.ContactDtos;
using CayirliFM.DtoLayer.Dtos.SocialMediaAccountsDtos;
using CayirliFM.DtoLayer.Dtos.StrategyDtos;
using CayirliFM.DtoLayer.Dtos.WelcomeToOurSiteDto;
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

            CreateMap<Address, ResultAddressDto>().ReverseMap();
            CreateMap<Address, ResultGetAddressByIdDto>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();
            CreateMap<Address, UpdateAddressDto>().ReverseMap();

            CreateMap<SocialMediaAccounts, ResultSocialMediaAcconutDto>().ReverseMap();
            CreateMap<SocialMediaAccounts, ResultGetSocialMediaAccountDto>().ReverseMap();
            CreateMap<SocialMediaAccounts, CreateSocialMediaAcconutDto>().ReverseMap();
            CreateMap<SocialMediaAccounts, UpdateSocialMediaAccountDto>().ReverseMap();

            CreateMap<WelcomeToOurSite, ResultWelcomeToOurSiteDto>().ReverseMap();
            CreateMap<WelcomeToOurSite, ResultGetWelcomeToOurSiteDto>().ReverseMap();
            CreateMap<WelcomeToOurSite, CreateWelcomeToOurSiteDto>().ReverseMap();
            CreateMap<WelcomeToOurSite, UpdateWelcomeToOurSiteDto>().ReverseMap();
        }
    }
}
