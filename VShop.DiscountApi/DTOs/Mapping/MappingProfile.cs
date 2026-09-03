using AutoMapper;
using VShop.DiscountApi.Models;

namespace VShop.DiscountApi.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<CouponDTO, Coupon>().ReverseMap();
        }
    }
}
