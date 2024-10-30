using Catalog.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }
    [JsonIgnore]
    public ICollection<Product> Products { get; set; } = new Collection<Product>();

    public Category(string name, string imageUrl)
    {
        ValidateDomain(name, imageUrl);
    }

    public Category(int id, string name, string imageUrl)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(name, imageUrl);
    }

    private void ValidateDomain(string name, string imgUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is required.");

        DomainExceptionValidation.When(string.IsNullOrEmpty(imgUrl), "invalid img. Img is required.");

        DomainExceptionValidation.When(name.Length < 3,
                        "Name must contain more than 3 characters");
        DomainExceptionValidation.When(imgUrl.Length < 5,
                        "Img name must contain more than 3 characters");
        Name = name;
        ImageUrl = imgUrl;
    }

}
