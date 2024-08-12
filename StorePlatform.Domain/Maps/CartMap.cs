using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StorePlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorePlatform.Domain.Maps
{
	public class CartMap : IEntityTypeConfiguration<CartViewModel>
	{
		public void Configure(EntityTypeBuilder<CartViewModel> builder)
		{
			builder.ToTable("cart", "StorePlatform");

			builder.HasKey(e => e.Id)
				   .HasName("cart_pkey");

			builder.Property(e => e.Id)
				   .HasColumnName("id")
				   .HasDefaultValueSql("gen_random_uuid()")
				   .IsRequired()
				   .HasComment("Sepet kimliği (birincil anahtar)");

			builder.Property(e => e.ProductId)
				   .HasColumnName("product_id")
				   .IsRequired()
				   .HasComment("Ürün kimliği, ürünler tablosunda olmalıdır");

			builder.Property(e => e.Quantity)
				   .HasColumnName("quantity")
				   .IsRequired()
				   .HasComment("İstenen ürün miktarı, sıfırdan büyük olmalıdır");

			builder.Property(e => e.Price)
				   .HasColumnName("price")
				   .IsRequired()
				   .HasColumnType("numeric(10, 2)")
				   .HasComment("Ürün fiyatı, sıfır veya daha fazla olmalıdır");

			builder.Property(e => e.CustomerId)
				   .HasColumnName("customer_id")
				   .IsRequired();

			builder.Property(e => e.RowCreatedDate)
				   .HasColumnName("row_created_date")
				   .HasDefaultValueSql("CURRENT_TIMESTAMP")
				   .IsRequired();

			builder.Property(e => e.RowUpdatedDate)
				   .HasColumnName("row_updated_date")
				   .HasDefaultValueSql("CURRENT_TIMESTAMP")
				   .IsRequired();

			builder.Property(e => e.RowIsActive)
				   .HasColumnName("row_is_active")
				   .HasDefaultValue(true)
				   .IsRequired();

			builder.Property(e => e.RowIsDeleted)
				   .HasColumnName("row_is_deleted")
				   .HasDefaultValue(false)
				   .IsRequired();

			builder.HasCheckConstraint("cart_quantity_check", "quantity > 0");
			builder.HasCheckConstraint("cart_price_check", "price >= 0");

			builder.HasOne<CustomerViewModel>()
				   .WithMany()
				   .HasForeignKey(e => e.CustomerId)
				   .HasConstraintName("fk_customer");

			builder.HasOne<ProductViewModel>()
				   .WithMany()
				   .HasForeignKey(e => e.ProductId)
				   .HasConstraintName("fk_product");
		}
	}
}
