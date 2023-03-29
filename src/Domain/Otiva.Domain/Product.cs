using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.Domain
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid SubcategoryId { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.UtcNow;

        public decimal Price { get; set; }

        public string? KodBase64 { get; set; }

        public Subcategory Subcategory { get; set; }

    }
}
