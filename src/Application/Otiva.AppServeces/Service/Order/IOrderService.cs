using Otiva.Contracts.AdDto;
using Otiva.Contracts.OrderDto;
using Otiva.Contracts.SelectedAdDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.Order
{
    public interface IOrderService
    {
        public Task<InfoOrderResponse> GetOrderAsync(Guid OrderId);
        Task<Guid> Order(CreateOrderRequest createOrder, CancellationToken cancellation);

        Task DeleteAsync(Guid Id);

    }
}
