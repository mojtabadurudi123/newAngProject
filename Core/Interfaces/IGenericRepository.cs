using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetEntityWithSpecification(ISpecifications<T> specification);

        Task<IReadOnlyList<T>> ListAsync (ISpecifications<T> specifications);
    }
}