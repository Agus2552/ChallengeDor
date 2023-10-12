using ChallengeDor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ChallengeDor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet("GetAllBlogs")]
        public async Task<ActionResult<ServiceResponse<List<BlogPost>>>> GetAll() {
            try
            {
                return await _blogPostService.GetBlogPosts();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<List<BlogPost>>
                {
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<BlogPost>>> Get(int id)
        {
            try
            {
                var result = await _blogPostService.GetBlogPost(id);

                if (result.Code == "1")
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<List<BlogPost>>
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BlogPost>>> Create(BlogPost blogPost)
        {
            try
            {
                var result = await _blogPostService.CreateBlogPost(blogPost);

                return CreatedAtAction(nameof(GetAll), new { id = blogPost.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<BlogPost>
                {
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BlogPost>>> Update(BlogPost blogPost)
        {
            try
            {
                var result = await _blogPostService.UpdateBlogPost(blogPost);

                if (result.Code == "1")
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<BlogPost>
                {
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            try
            {
                var result = await _blogPostService.DeleteBlogPost(id);

                if (result.Code == "1")
                {
                    return NotFound(result);
                }

                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<bool>
                {
                    Message = ex.Message
                });
            }
        }
    }
}
