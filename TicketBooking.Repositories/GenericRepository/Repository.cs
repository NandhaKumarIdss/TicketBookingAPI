using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketBooking.Data.TicketBookingDbContext;
using TicketBooking.Entities.BaseEntity;

namespace TicketBooking.Repositories.GenericRepository
{
    public class Repository<TEntity, TModel> : IRepository<TEntity, TModel> where TEntity : class where TModel : class
    {
        protected readonly TicketBookingDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _entities;
        public Repository(TicketBookingDbContext context, IMapper mapper)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            var entities = await _entities.ToListAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public async Task<TModel> GetById(Guid id)
        {
            var entity = await _entities.FindAsync(id);
            return _mapper.Map<TModel>(entity);
        }

        public async Task<TEntity> Create(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task Update(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task Delete(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChangesAsync();
        }
    }
}
