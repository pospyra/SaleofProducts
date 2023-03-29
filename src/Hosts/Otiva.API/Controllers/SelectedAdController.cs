using Microsoft.AspNetCore.Mvc;
using Otiva.AppServeces.Service.Ad;
using Otiva.AppServeces.Service;
using Otiva.Contracts.AdDto;
using Otiva.Contracts.SelectedAdDto;
using System.Net;
using Otiva.AppServeces.Service.ShoppingCart;

namespace Otiva.API.Controllers
{
    [ApiController]
    public class SelectedAdController : ControllerBase
    {
        public readonly IItemCartService _itemService;
        public SelectedAdController(IItemCartService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("/allSelectedByUserID")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoSelectedResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll( int take, int skip, CancellationToken cancellation)
        {
            var result = await _itemService.GetSelectedUsersAsync( take, skip, cancellation);

            return Ok(result);
        }


        [HttpPost("selectedAd/add")]
        [ProducesResponseType(typeof(IReadOnlyCollection<InfoSelectedResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateAdAsync(Guid AdId, CancellationToken cancellation)
        {
            var result = await _itemService.AddSelectedAsync(AdId, cancellation);

            return Created("", result);
        }


        [HttpDelete("/selected/delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAdAsync(Guid Id)
        {
            await _itemService.DeleteAsync(Id);

            return NoContent();
        }
    }
}
