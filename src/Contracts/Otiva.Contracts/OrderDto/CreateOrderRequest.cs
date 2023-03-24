using Otiva.Contracts.SelectedAdDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.Contracts.OrderDto
{
    public class CreateOrderRequest
    {

        /// <summary>
        /// ID курьера
        /// </summary>
        public Guid CourierId { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string DeliveryAddress { get; set; }

    }
}
