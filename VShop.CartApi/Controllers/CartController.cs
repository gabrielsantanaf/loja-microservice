using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.CartApi.DTOs;
using VShop.CartApi.Repositories;

namespace VShop.CartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderDTO>> Checkout(CheckoutHeaderDTO checkoutDTO)
        {
            var cart =  await _cartRepository.GetCartByUserIdAsync(checkoutDTO.UserId);

            if (cart is null )
            {
                return NotFound($"Cart not found for {checkoutDTO.UserId}");
            }

            checkoutDTO.CartItems = cart.CartItems;
            checkoutDTO.DateTime = DateTime.Now;

            return Ok(checkoutDTO);
        }

        [HttpGet("getcart/{userId}")]
        public async Task<ActionResult<CartDTO>> GetByUserId(string userId)
        {
            var cartDTO = await _cartRepository.GetCartByUserIdAsync(userId);

            if (cartDTO is null)
                return NotFound();
            
            return Ok(cartDTO);
        }

        [HttpPost("addcart")]
        public async Task<ActionResult<CartDTO>> AddCart(CartDTO cartDTO)
        {
            var cart = await _cartRepository.UpdateCartAsync(cartDTO);

            if (cart is null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost("applycoupon")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(CartDTO cartDTO)
        {
            var result = await _cartRepository.ApplyCouponAsync(cartDTO.CartHeader.UserId, cartDTO.CartHeader.CouponCode);

            if (!result)
            {
                return NotFound($"CartHeader not found for userId = {cartDTO.CartHeader.UserId}");
            }
            return Ok(result);
        }

        [HttpPut("updatecart")]
        public async Task<ActionResult<CartDTO>> UpdadeCart(CartDTO cartDTO)
        {
            var cart = await _cartRepository.UpdateCartAsync(cartDTO);
            
            if (cart is null)
                return NotFound();

            return Ok(cart);
        }

        [HttpDelete("deletecart/{id}")]
        public async Task<ActionResult<bool>> DeleteCart(int id)
        {
            var status = await _cartRepository.DeleteItemCartAsync(id);

            if (!status)
                return NotFound();

            return Ok(status);
        }

        [HttpDelete("deletecoupon/{userId}")]
        public async Task<ActionResult<CartDTO>> DeleteCoupon(string userId)
        {
            var result = await _cartRepository.DeleteCouponAsync(userId);

            if (!result)
                return NotFound("Discount Coupon not found for userId = " + userId);

            return Ok(result);
        }
    }
}
