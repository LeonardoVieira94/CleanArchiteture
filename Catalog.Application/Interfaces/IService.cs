using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces;

public interface IService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetAsync(int id);
    Task <T> Create(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
}
