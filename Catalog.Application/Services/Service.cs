using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services;

public class Service<T> : IService<T> where T : Entity
{
    private readonly IUnitOfWork _uof;

    public Service(IUnitOfWork uof)
    {
        _uof = uof;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _uof.Repository<T>().GetAllAsync();
    }
    public async Task<T?> GetAsync(int id)
    {
        return await _uof.Repository<T>().GetAsync(x => x.Id == id);
    }

    public async Task<T> Create(T entity)
    {
        var created = _uof.Repository<T>().Create(entity);
        await _uof.CommitAsync();
        return created;
    }

    public async Task <T> Update(T entity)
    {
        var updated = _uof.Repository<T>().Update(entity);
        await _uof.CommitAsync();
        return updated;
    }
    public async Task <T> Delete(int id)
    {
        var obj = await _uof.Repository<T>().GetAsync(x =>x.Id == id);
        if (obj != null)
        {
            _uof.Repository<T>().Delete(obj);
            await _uof.CommitAsync();
            return obj;
        }
        else
        {
            throw new Exception("Object not found");
        }
    }
}
