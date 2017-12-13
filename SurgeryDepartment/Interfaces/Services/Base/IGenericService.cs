using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SurgeryDepartment.Models.DomainModels;

namespace SurgeryDepartment.Interfaces.Services.Base
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetItemsAsync();
        Task<TEntity> AddAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task<Boolean> RemoveAsync(TEntity item);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, Boolean>> predicate);
        Task<TEntity> FindFirstAsync(Expression<Func<TEntity, Boolean>> predicate);
    }
}
