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
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EsatCelik.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        // GET: api/<ArticlesController>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(string title = "", string content = "")
        {
            try
            {
                var articles = await _articleService.GetListAsync(title, content);
                var mappedData = _mapper.Map<ICollection<ArticleForListDto>>(articles);
                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // GET api/<ArticlesController>/5
        [Authorize]
        [HttpGet("GetListByCategoryId")]
        public async Task<IActionResult> GetListByCategoryId(int categoryId)
        {
            try
            {
                var articles = await _articleService.GetListByCategoryIdAsync(categoryId);
                var mappedData = _mapper.Map<ICollection<ArticleForListDto>>(articles);
                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var article = await _articleService.GetByIdAsync(id);
                var mappedData = _mapper.Map<ArticleForListDto>(article);
                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // POST api/<ArticlesController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticleSaveModel articleSaveModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem();
                }

                Article article = new Article(0, articleSaveModel.Title, articleSaveModel.ArticleAddress, articleSaveModel.Content, articleSaveModel.MainPictureResourceId, articleSaveModel.AllowComment, articleSaveModel.MainPictureResource);

                var newArticle = await _articleService.AddAsync(article);
                var mappedData = _mapper.Map<ArticleForListDto>(newArticle);

                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT api/<ArticlesController>/5
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ArticleSaveModel articleSaveModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem();
                }
                
                Article article = new Article(articleSaveModel.Id, articleSaveModel.Title, articleSaveModel.ArticleAddress, articleSaveModel.Content, articleSaveModel.MainPictureResourceId, articleSaveModel.AllowComment, articleSaveModel.MainPictureResource);

                var newArticle = await _articleService.UpdateAsync(article);
                var mappedData = _mapper.Map<ArticleForListDto>(newArticle);

                return Ok(mappedData);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ArticlesController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _articleService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
