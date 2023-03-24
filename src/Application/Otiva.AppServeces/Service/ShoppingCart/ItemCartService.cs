using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Otiva.AppServeces.IRepository;
using Otiva.AppServeces.Service.User;
using Otiva.Contracts.SelectedAdDto;
using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.ShoppingCart
{
    public class ItemCartService : IItemCartService
    {
        public readonly IItemCartRepository _selectedadRepository;
        public readonly IUserService _userService;
        public readonly IShoppingCartService _cartService;
        public readonly IMapper _mapper;
        public ItemCartService(IItemCartRepository selectedadRepository,
            IMapper mapper,
            IUserService userService,
          IShoppingCartService cartService)
        {
            _selectedadRepository = selectedadRepository;
            _userService = userService;
            _mapper = mapper;
            _cartService = cartService;
        }


        public async Task<InfoSelectedResponse> AddSelectedAsync( Guid AdId, CancellationToken cancellation)
        {
            var shoppingCartID = await _cartService.GetCartByCurrentUser(cancellation);

            var selected = new Domain.ItemShoppingCart()
            {
                ProductId = AdId,
                ShoppingCartId = shoppingCartID,
            };
            await _selectedadRepository.Add(selected);

            return _mapper.Map<InfoSelectedResponse>(selected);
        }

        public async Task DeleteAsync(Guid Id)
        {
            var selectedDel = await _selectedadRepository.FindByIdAsync(Id);
            await _selectedadRepository.DeleteAsync(selectedDel);
        }

        public async Task<IReadOnlyCollection<InfoSelectedResponse>> GetSelectedUsersAsync(Guid UserId, int take, int skip, CancellationToken cancellation)
        {
            var shoppingCartID = await _cartService.GetCartByCurrentUser(cancellation);

            return await _selectedadRepository.GetAll()
               //.Where(x => x.ShoppingCartId == shoppingCartID)
               .Select(a=> new InfoSelectedResponse()
               {
                   Id= a.Id,
                   AdId= a.ProductId,
                   DateAdded= a.Created,
               }).OrderBy(x =>x.DateAdded).Skip(skip).Take(take).ToListAsync();
        }
    }
}
