using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EsatCelik.Blog.Api.Models;
using EsatCelik.Blog.Business.Abstract;
using EsatCelik.Blog.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EsatCelik.Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var comments = await _commentService.GetListAsync();
                return Ok(comments);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // GET api/<CommentsController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var comment = await _commentService.GetByIdAsync(id);
                return Ok(comment);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // GET api/<CommentsController>/5
        [Authorize]
        [HttpGet("GetByArticleId/{id}")]
        public async Task<IActionResult> GetByArticleId(int id)
        {
            try
            {
                var comment = await _commentService.GetListByArticleIdAsync(id);
                return Ok(comment);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // POST api/<CommentsController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentSaveModel commentSaveModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem();
                }

                Comment comment = new Comment(commentSaveModel.Id, commentSaveModel.Title, commentSaveModel.Message, commentSaveModel.ArticleId);

                return Ok(await _commentService.AddAsync(comment));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // PUT api/<CommentsController>/5
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CommentSaveModel commentSaveModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationProblem();
                }

                Comment comment = new Comment(commentSaveModel.Id, commentSaveModel.Title, commentSaveModel.Message, commentSaveModel.ArticleId);

                return Ok(await _commentService.UpdateAsync(comment));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CommentsController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _commentService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
