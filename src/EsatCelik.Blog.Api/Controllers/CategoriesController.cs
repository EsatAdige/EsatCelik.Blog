using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EsatCelik.Blog.Api.Dtos;
using EsatCelik.Blog.Api.Models;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EsatCelik.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get(string categoryName = "")
        {
            try
            {
                var categories = await _categoryService.GetListAsync(categoryName);
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategorySaveModel categorySaveModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem();
                }

                Category category = new Category(categorySaveModel.Id, categorySaveModel.Name);

                return Ok(await _categoryService.AddAsync(category));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategorySaveModel categorySaveModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem();
                }

                Category category = new Category(categorySaveModel.Id, categorySaveModel.Name);

                return Ok(await _categoryService.UpdateAsync(category));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
