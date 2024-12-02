using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportApp_Business.Commands.CartCommand;
using SportApp_Business.Commands.OrderCommand;
using SportApp_Business.Queries.CartQuery;
using SportApp_Business.Queries.OrderQuery;
using SportApp_Domain.Entities;
using System.Security.Claims;
using System.Threading;

namespace SportApp_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddItem(Guid sportProductVariantId,int quantity, CancellationToken cancellationToken)
        {
            var cart = await _mediator.Send(new GetCart { BuyerId = GetBuyerId() }, cancellationToken);
            if (cart == null) cart = await CreateCart(cancellationToken);
            return Ok(await _mediator.Send(new AddItem
            {
                BuyerId = cart.BuyerId,
                Quantity = quantity,
                SportProductVariantId = sportProductVariantId
            },cancellationToken));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteItem(Guid sportProductVariantId,CancellationToken cancellationToken, int quantity = 1)
        {
            var cart = await _mediator.Send(new GetCart { BuyerId = GetBuyerId() }, cancellationToken);
            return Ok(await _mediator.Send(new DeleteItem { BuyerId= GetBuyerId(),SportProductVariantId=sportProductVariantId,Quantity=quantity }, cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCartDetail(CancellationToken cancellationToken)
        {
            var cart = await _mediator.Send(new GetCartDto { BuyerId = GetBuyerId() }, cancellationToken);
            return Ok(cart);
        }
        private async Task<Cart> CreateCart(CancellationToken cancellationToken)
        {
            var buyerId = User.Identity.Name;
            if (string.IsNullOrEmpty(buyerId))
            {
                buyerId = Guid.NewGuid().ToString();
                var optionCookies = new CookieOptions
                {
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.Now.AddDays(30),
                };
                Response.Cookies.Append("buyerId", buyerId, optionCookies);
            }
            var cart = await _mediator.Send(new CreateCart { BuyerId = buyerId }, cancellationToken);
            return cart;

        }
        private string GetBuyerId()
        {
            return User.FindFirst(ClaimTypes.Email)?.Value ?? Request.Cookies["buyerId"];
        }
    }
}
