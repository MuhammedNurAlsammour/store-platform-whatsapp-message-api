﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorePlatform.Domain.Entities;

public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategoryViewModel>
{
	public void Configure(EntityTypeBuilder<ProductCategoryViewModel> builder)
	{
		builder.ToTable("product_categories");

		builder.HasKey(pc => pc.Id);

		builder.HasOne(pc => pc.Product)
			.WithMany(p => p.ProductCategories)
			.HasForeignKey(pc => pc.ProductId);

		builder.HasOne(pc => pc.Category)
			.WithMany(c => c.ProductCategories)
			.HasForeignKey(pc => pc.CategoryId);
	}
}
