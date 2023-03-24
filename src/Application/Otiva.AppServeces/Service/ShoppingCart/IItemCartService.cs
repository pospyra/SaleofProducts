using Otiva.Contracts.AdDto;
using Otiva.Contracts.SelectedAdDto;
using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.Service.ShoppingCart
{
    public interface IItemCartService
    {
        Task<InfoSelectedResponse> AddSelectedAsync (Guid AdId, CancellationToken cancellation);

        Task<IReadOnlyCollection<InfoSelectedResponse>> GetSelectedUsersAsync(Guid UserId, int take, int skip, CancellationToken cancellation);

        Task DeleteAsync(Guid Id);
    }
}
