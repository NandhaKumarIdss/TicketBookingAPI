using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TicketBooking.Entities.BaseEntity;
using TicketBooking.Repositories.GenericRepository;

namespace TicketBooking.CrudController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController<TEntity> : ControllerBase where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;

        public CrudController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(TEntity entity)
        {
            await _repository.Create(entity);
            return Ok(entity);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            await _repository.Update(entity);
            return Ok(entity);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Delete(TEntity entity)
        {
            await _repository.Delete(entity);
            return Ok(entity);
        }

    }
}
