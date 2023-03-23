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
        /// ID коризны товаров
        /// </summary>
        public Guid ShoppingCartId { get; set; }

        /// <summary>
        /// ID курьера
        /// </summary>
        public Guid CourierId { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// ДатаВремя выдачи заказа
        /// </summary>
        public DateTime IssueDateTime { get; set; }

    }
}
