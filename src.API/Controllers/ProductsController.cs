﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.API.DTOs;
using src.API.DTOs.Filters;
using src.API.Filters;
using src.Core.Models;
using src.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet("{id}"), ServiceFilter(typeof(ProductNotFoundFilter))]
        public async Task<IActionResult> GetById(int id)
        {
            var prodcut = await _productService.GetByIdAsync(id);

            return Ok(_mapper.Map<ProductDto>(prodcut));
        }

        [HttpGet("{id}/category"), ServiceFilter(typeof(ProductNotFoundFilter))]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var product = await _productService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<ProductWithCategoryDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            return Created(string.Empty, _mapper.Map<ProductDto>(newProduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var product = _productService.Update(_mapper.Map<Product>(productDto));

            return NoContent();
        }

        [HttpDelete("{id}"), ServiceFilter(typeof(ProductNotFoundFilter))]
        public IActionResult Remove(int id)
        {
            var deleteProduct = _productService.GetByIdAsync(id).Result;
            _productService.Remove(deleteProduct);
            return NoContent();

        }

    }
}
