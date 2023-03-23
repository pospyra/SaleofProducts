
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.Domain
{
    public class User 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public DateTime RegistrationDateTime { get; set; } = DateTime.UtcNow;

        public string? KodBase64 { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<ShoppingCart> SelectedAds { get; set; }
    }
}
