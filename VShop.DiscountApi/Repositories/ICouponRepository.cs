using VShop.DiscountApi.DTOs;
using VShop.DiscountApi.Models;

namespace VShop.DiscountApi.Repositories
{
    public interface ICouponRepository
    {
        Task<CouponDTO> GetCouponByCode(string couponCode);
    }
}
