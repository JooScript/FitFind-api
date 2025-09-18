using AutoMapper;
using ECommerce.Bl.Dtos.Base;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Bl.Dtos.User;
using ECommerce.Domains.Base;
using ECommerce.Domains.Models;
using static ECommerce.Bl.Enums.Status.Status;

namespace ECommerce.Bl.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TbRefreshToken, RefreshTokenDto>().ReverseMap();
        CreateMap<TbAuditLog, AuditLogDto>().ReverseMap();
        CreateMap<TbProduct, ProductDto>().ReverseMap();
        CreateMap<TbSupportTicket, SupportTicketDto>().ReverseMap();

        CreateMap<BaseTable, BaseDto<enCurrentState>>()
            .ForMember(dest => dest.CurrentState, opt => opt.MapFrom(src => (enCurrentState)src.CurrentState))
            .ReverseMap()
            .ForMember(dest => dest.CurrentState, opt => opt.MapFrom(src => (int)src.CurrentState));

        CreateMap<BaseTable, BaseDto<enSupportTicketState>>()
    .ForMember(dest => dest.CurrentState, opt => opt.MapFrom(src => (enSupportTicketState)src.CurrentState))
    .ReverseMap()
    .ForMember(dest => dest.CurrentState, opt => opt.MapFrom(src => (int)src.CurrentState));

    }
}
