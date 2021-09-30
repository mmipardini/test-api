using System;
using System.Collections.Generic;
using Catalog.Interfaces;
using Catalog.Models;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemItemsRepository _repository;

        public ItemsController(IInMemItemsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = _repository.GetItems();
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);

            if(item is null)
            {
                return NotFound();
            }

            return item;
        }
    }
}