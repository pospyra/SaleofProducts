using AutoMapper;
using Otiva.AppServeces.IRepository;
using Otiva.AppServeces.Service.User;
using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.ShoppingCart
{
    public class ShoppingCartService : IShoppingCartService
    {
        public readonly IShoppingCartRepository _shoppingCartRepository;
        public readonly IUserService _userService;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, 
            IUserService userService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userService = userService;
        }
        public async Task<Guid> GetCartByCurrentUser(CancellationToken cancellationToken)
        {
            var currentUserId = await _userService.GetCurrentUserId(cancellationToken);
            var shopCart = await _shoppingCartRepository.FindWhere(x => x.UserId == currentUserId);
            return shopCart.Id;
        }


    }
}
