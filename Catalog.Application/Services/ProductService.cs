using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services;

public class ProductService : Service<Product>, IProductService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uof;

    public ProductService(IUnitOfWork uof, IMapper mapper) : base(uof)
    {
        _mapper = mapper;
        _uof = uof;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await base.GetAllAsync();
        var productsDto = _mapper.Map<IEnumerable<ProductDTO>>(products);
        return productsDto;
    }

    public async Task<ProductDTO> GetAsync(int id)
    {
        var product = await base.GetAsync(id);
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        var productDto = _mapper.Map<ProductDTO>(product);
        return productDto;
    }

    public async Task <ProductDTO> Create(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);

        var createdProduct = await base.Create(product);
        await _uof.CommitAsync();

        var createdDto = _mapper.Map<ProductDTO>(createdProduct);

        return createdDto;
    }

    public async Task<ProductDTO> Update(ProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        await base.Update(product);
        return _mapper.Map<ProductDTO>(product);
    }
    public async Task<ProductDTO> Delete(int id)
    {
        var product = base.GetAsync(id);
        await base.Delete(id);
        return _mapper.Map<ProductDTO>(product);
    }



}
