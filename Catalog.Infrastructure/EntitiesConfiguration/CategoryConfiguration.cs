using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.ImageUrl).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Category(1, "School Itens", "school.jpg"),
            new Category(2, "Electronics", "electronics.jpg"),
            new Category(3, "Acessories", "acessories.jpg")
            );
    }
}
