using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.TicketBookingDbContext;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Repositories.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected TicketBookingDbContext _context;

        public Repository(TicketBookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChangesAsync();
        }
    }
}
