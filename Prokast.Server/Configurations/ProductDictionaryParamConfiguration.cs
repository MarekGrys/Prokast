using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prokast.Server.Entities;

namespace Prokast.Server.Configurations
{
    public class ProductDictionaryParamConfiguration: IEntityTypeConfiguration<ProductDictionaryParam>
    {
        public void Configure(EntityTypeBuilder<ProductDictionaryParam> builder)
        {
            builder.HasIndex(x => x.ID).IsUnique();
            builder.HasOne(x => x.Product)
                   .WithMany(p => p.ProductDictionaryParams)
                   .HasForeignKey(x => x.ProductID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DictionaryParam)
                   .WithMany(dp => dp.ProductDictionaryParams)
                   .HasForeignKey(x => x.DictionaryParamID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
