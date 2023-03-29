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
        /// Адрес доставки
        /// </summary>
        public string DeliveryAddress { get; set; }

    }
}
