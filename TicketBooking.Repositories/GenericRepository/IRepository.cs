using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Repositories.GenericRepository
{
    public interface IRepository<TEntity, TModel> where TEntity : class where TModel : class
    {
        Task<TModel> GetById(Guid id);
        Task<TEntity> Create(TModel entity);
        Task Update(TModel entity);
        Task Delete(TModel entity);
        Task<IEnumerable<TModel>> GetAll();
    }
}
