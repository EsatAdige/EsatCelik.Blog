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
using EsatCelik.Core.CacheManager;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EsatCelik.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly ICacheProvider _cache;

        public CategoriesController(ICategoryService categoryService, IMapper mapper, ICacheProvider cache)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _cache = cache;
        }

        // GET: api/<CategoriesController>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(string categoryName = "")
        {
            try
            {
                var categories = await _categoryService.GetListAsync(categoryName);
                var mappedData = _mapper.Map<ICollection<CategoryForListDto>>(categories);
                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("GetAllCategoriesFromCache")]
        public async Task<IActionResult> GetAllCategoriesFromCache()
        {
            try
            {
                if(!_cache.IsInCache(CacheKeyHelper.AllCategories))
                {
                    var categories = await _categoryService.GetListAsync();
                    _cache.Set<ICollection<Category>>(CacheKeyHelper.AllCategories, categories, TimeSpan.FromHours(2));
                }

                var cachedCategories = _cache.Get<ICollection<Category>>(CacheKeyHelper.AllCategories);
                var mappedData = _mapper.Map<ICollection<CategoryForListDto>>(cachedCategories);

                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // GET api/<CategoriesController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                var mappedData = _mapper.Map<ICollection<CategoryForListDto>>(category);
                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // POST api/<CategoriesController>
        [Authorize]
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
                _cache.Remove(CacheKeyHelper.AllCategories);

                return Ok(await _categoryService.AddAsync(category));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT api/<CategoriesController>/5
        [Authorize]
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
                _cache.Remove(CacheKeyHelper.AllCategories);

                return Ok(await _categoryService.UpdateAsync(category));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CategoriesController>/5
        [Authorize]
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
