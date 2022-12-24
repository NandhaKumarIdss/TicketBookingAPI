﻿using AutoMapper;
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
    public class CrudController<TEntity, TModel> : ControllerBase where TEntity : class
    {
        private readonly IRepository<TEntity, TModel> _repository;
        public CrudController(IRepository<TEntity, TModel> repository)
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
        public virtual async Task<IActionResult> Create(TModel model)
        {
            await _repository.Create(model);
            return Ok(model);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(TModel model)
        {
            await _repository.Update(model);
            return Ok(model);
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(TModel model)
        {
            await _repository.Delete(model);
            return Ok(model);
        }

    }
}
