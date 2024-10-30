using Catalog.Application.DTOs;
using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces;

public interface IProductService : IService<ProductDTO>
{
}
