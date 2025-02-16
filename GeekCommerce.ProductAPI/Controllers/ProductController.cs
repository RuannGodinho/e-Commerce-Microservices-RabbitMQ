﻿using GeekCommerce.ProductAPI.Data.ValueObjects;
using GeekCommerce.ProductAPI.Model;
using GeekCommerce.ProductAPI.Repository;
using GeekCommerce.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekCommerce.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVo>>> FindAll()
        {
            var products = await _repository.FindAll();

            return Ok(products);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVo>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductVo>> Create([FromBody]ProductVo vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);

            return Ok(product);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<ProductVo>> Update([FromBody]ProductVo vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);

            return Ok(product);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductVo>> Delete(long id)
        {
            var status = await _repository.Delete(id);

            if (!status) return BadRequest();

            return Ok(status);
        }
    }
}
