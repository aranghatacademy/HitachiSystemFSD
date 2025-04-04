using System;

namespace Ecom.Data;

public interface IRepository<T>
{
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
}
