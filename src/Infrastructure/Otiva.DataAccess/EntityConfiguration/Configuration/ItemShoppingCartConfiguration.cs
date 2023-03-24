using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.DataAccess.EntityConfiguration.Configuration
{
    public class ItemShoppingCartConfiguration : IEntityTypeConfiguration<ItemShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ItemShoppingCart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();


            //builder.HasOne(x => x.User)
            //    .WithMany(p => p.ItemSelectedAds)
            //    .HasForeignKey(x => x.UserId);

        }
    }
}
