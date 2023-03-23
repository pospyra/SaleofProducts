using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.Domain
{
    public class Order
    {
        /// <summary>
        /// ID заказа
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ID коризны товаров
        /// </summary>
        public Guid ShoppingCartId { get; set; }

        /// <summary>
        /// ID заказчика
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// ID курьера
        /// </summary>
        public Guid CourierId { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// Итоговая цена
        /// </summary>
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// ДатаВремя оформления заказа
        /// </summary>
        public DateTime OrderDateTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ДатаВремя выдачи заказа
        /// </summary>
        public DateTime? IssueDateTime { get; set; }
    }
}
