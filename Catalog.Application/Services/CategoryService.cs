using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services;

public class CategoryService : Service<Category>, ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uof;

    public CategoryService(IUnitOfWork uof, IMapper mapper) : base(uof)
    {
        _mapper = mapper;
        _uof = uof;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        var categories = await base.GetAllAsync();
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        return categoriesDto;
    }

    public async Task<CategoryDTO> GetAsync(int id)
    {
        var category = await base.GetAsync(id);
        var categoryDto = _mapper.Map<CategoryDTO>(category);
        return categoryDto;
    }

    public async Task<CategoryDTO> Create(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);

        var createdCategory = await base.Create(category);
        //await _uof.CommitAsync();

        var createdDto = _mapper.Map<CategoryDTO>(createdCategory);

        return createdDto;
    }

    public async Task<CategoryDTO> Update(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        var update = await base.Update(category);
        var updateDto = _mapper.Map<CategoryDTO>(category);
        return updateDto;
    }
    public new async Task<CategoryDTO> Delete(int id)
    {
        var product = await base.Delete(id);
        return _mapper.Map<CategoryDTO>(product);
    }

}
