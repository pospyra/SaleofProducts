using Microsoft.AspNetCore.Mvc;
using Otiva.AppServeces.Service.Ad;
using Otiva.AppServeces.Service.Order;
using Otiva.AppServeces.Service.SelectedAds;
using Otiva.Contracts.AdDto;
using Otiva.Contracts.OrderDto;
using Otiva.Contracts.SelectedAdDto;
using System.Net;
namespace Otiva.API.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("/getOrder{Id}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoSelectedResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(Guid OrderId)
        {
            var result = await _orderService.GetOrderAsync(OrderId);

            return Ok(result);
        }


        [HttpPost("order/add")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoSelectedResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAdAsync(CreateOrderRequest createOrder, CancellationToken cancellation)
        {
            var result = await _orderService.Order(createOrder, cancellation);

            return Created("", result);
        }


        [HttpDelete("/order/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAdAsync(Guid Id)
        {
            await _orderService.DeleteAsync(Id);

            return NoContent();
        }
    }
}
