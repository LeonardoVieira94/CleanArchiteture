using Catalog.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string ImageUrl { get; private set; }
    public int Inventory { get; private set; }
    public DateTime RegDate { get; private set; }
    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category Category { get; set; }

    public Product(string name, string description, decimal price, string imageUrl, int inventory, DateTime regDate)
    {
        ValidateDomain(name, description, price, imageUrl, inventory, regDate);
    }

    public void Update(string name, string description, decimal price, string imageUrl, 
                        int inventory, DateTime regDate, int categoryId)
    {
        ValidateDomain(name, description, price, imageUrl, inventory, regDate);
        CategoryId = categoryId;

    }

    private void ValidateDomain(string name, string description, decimal price, string imageUrl,
        int inventory, DateTime regDate)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "Invalid name. Name is required.");

        DomainExceptionValidation.When(name.Length < 3,
            "Name must contain more than 3 characters");

        DomainExceptionValidation.When(string.IsNullOrEmpty(description),
            "Invalid description. Description is required.");

        DomainExceptionValidation.When(description.Length < 5,
            "Description must contain more than 5 characters");

        DomainExceptionValidation.When(price < 0, "Invalid price");

        DomainExceptionValidation.When(imageUrl?.Length > 250,
            "Image name cannot exceed 250 characters.");

        DomainExceptionValidation.When(inventory < 0, "invalid inventory");

        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Inventory = inventory;
        RegDate = regDate;

    }
}
