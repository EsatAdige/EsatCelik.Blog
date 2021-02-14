using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsatCelik.Blog.Api.Models;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.Entities.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EsatCelik.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoriesController : ControllerBase
    {
        private readonly IArticleCategoryService _articleCategoryService;

        public ArticleCategoriesController(IArticleCategoryService articleCategoryService)
        {
            _articleCategoryService = articleCategoryService;
        }

        // POST api/<ArticleCategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticleCategorySaveModel articleCategorySaveModel)
        {
            try
            {
                ArticleCategory articleCategory = new ArticleCategory(articleCategorySaveModel.ArticleId, articleCategorySaveModel.CategoryId);
                await _articleCategoryService.AddAsync(articleCategory);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ArticleCategoriesController>/5
        [HttpDelete("{articleId}/{categoryId}")]
        public async Task<IActionResult> Delete(int articleId, int categoryId)
        {
            try
            {
                await _articleCategoryService.DeleteAsync(articleId, categoryId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
