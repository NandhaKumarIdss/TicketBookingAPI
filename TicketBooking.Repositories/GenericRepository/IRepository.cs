using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Repositories.GenericRepository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
