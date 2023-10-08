using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQLitePCL;

namespace Infrastracture.Data.config
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(p=>p.Id).IsRequired();
            builder.Property(p=>p.ProductTitle).IsRequired().HasMaxLength(500);
            builder.Property(p=>p.Description).HasMaxLength(5000);
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(b=>b.ProductBrands).WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(b=>b.ProductTypes).WithMany().HasForeignKey(p=>p.ProductTypeId);
        }
    }
}