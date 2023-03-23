using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Otiva.AppServeces.IRepository;
using Otiva.AppServeces.Service.Photo;
using Otiva.AppServeces.Service.User;
using Otiva.Contracts.AdDto;
using Otiva.Contracts.OrderDto;
using Otiva.Contracts.SelectedAdDto;
using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.Order
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _ordreRepository;
        public readonly IUserService _userService;
        public readonly IMapper _mapper;
        public OrderService(IOrderRepository ordreRepository, IMapper mapper, IUserService userService)
        {
            _ordreRepository = ordreRepository;
            _mapper = mapper;
            _userService = userService;
        }


        public async Task DeleteAsync(Guid Id)
        {
            var cancelOrder = await _ordreRepository.FindByIdAsync(Id);
            await _ordreRepository.DeleteAsync(cancelOrder);
        }

        public async Task<InfoOrderResponse> GetOrderAsync(Guid OrderId)
        {
            var order = await _ordreRepository.FindByIdAsync(OrderId);
            return new InfoOrderResponse()
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ShoppingCartId = order.ShoppingCartId,
                CourierId = order.CourierId,
                DeliveryAddress = order.DeliveryAddress,
                TotalPrice = order.TotalPrice,
                OrderDateTime = order.OrderDateTime,
                IssueDateTime = order.IssueDateTime
            };
        }

        public async Task<Guid> Order(CreateOrderRequest createOrder, CancellationToken cancellation)
        {
            var newOrder = new Domain.Order()
            {
                ShoppingCartId = createOrder.ShoppingCartId,
                ClientId = await _userService.GetCurrentUserId(cancellation),
                CourierId = createOrder.CourierId,
                DeliveryAddress = createOrder.DeliveryAddress,
            };
           await  _ordreRepository.Add(newOrder);

            return newOrder.Id;
        }
    }
}
