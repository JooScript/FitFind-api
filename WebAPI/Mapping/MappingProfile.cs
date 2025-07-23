using AutoMapper;
using ECommerce.DTO;
using ECommerce.Models;

namespace ECommerce.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<TbAttribute, AttributeDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbAddress, AddressDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbWishlist, WishlistDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbAttributeValue, AttributeValueDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbCategory, CategoryDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbShoppingCart, ShoppingCartDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbDiscountProductMapping, DiscountProductMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbDiscountCategoryMapping, DiscountCategoryMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbDiscount, DiscountDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbImage, ImageDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbAuditLog, AuditLogDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbCartItem, CartItemDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbCampaign, CampaignDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbCampaignProductMapping, CampaignProductMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbLanguage, LanguageDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbSupplier, SupplierDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbInventoryTransaction, InventoryTransactionDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbInvoice, InvoiceDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbOrderReturn, OrderReturnDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbSubscription, SubscriptionDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbTag, TagDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbTaxRate, TaxRateDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbTicketReply, TicketReplyDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbVariation, VariationDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbVariationAttributeMapping, VariationAttributeMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbWishlistItem, WishlistItemDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbUserActivity, UserActivityDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbProductCategoryMapping, ProductCategoryMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbOrderStatusHistory, OrderStatusHistoryDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbProduct, ProductDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbSupportTicket, SupportTicketDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbProductTagMapping, ProductTagMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbReview, ReviewDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbProductSupplier, ProductSupplierDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbOrderItem, OrderItemDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbPayment, PaymentDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbOrder, OrderDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbShipment, ShipmentDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbPaymentTransaction, PaymentTransactionDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbShipmentItemMapping, ShipmentItemMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbProductTranslationMapping, ProductTranslationMappingDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbSeoMetum, SeoMetumDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();
            CreateMap<TbMethod, MethodDTO>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id)).ReverseMap();


        }
    }
}