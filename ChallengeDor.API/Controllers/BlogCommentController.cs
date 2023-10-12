using Microsoft.AspNetCore.Mvc;

namespace ChallengeDor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class BlogCommentController : ControllerBase
    {
        private readonly IBlogCommentService _blogCommentService;
        public BlogCommentController(IBlogCommentService blogCommentService)
        {
            _blogCommentService = blogCommentService;
        }

        [ProducesResponseType(200)]
        [HttpGet("GetAllPostCommentsForPost/{id:int}")]
        public async Task<ActionResult<ServiceResponse<List<BlogComment>>>> GetAllCommentsForPost(int id)
        {
            try
            {
                return Ok(await _blogCommentService.GetBlogCommentsForPost(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<List<BlogComment>>
                {
                    Message = ex.Message
                });
            }
        }

        [ProducesResponseType(200)]
        [HttpGet("GetPostComment/{id:int}")]
        public async Task<ActionResult<ServiceResponse<BlogComment>>> Get(int id)
        {
            try
            {
                var result = await _blogCommentService.GetBlogComment(id);

                if (result.Code == "1")
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<List<BlogComment>>
                {
                    Message = ex.Message
                });
            }
        }

        [ProducesResponseType(201)]
        [HttpPost("CreatePostComment")]
        public async Task<ActionResult<ServiceResponse<BlogComment>>> Create(BlogComment blogComment)
        {
            try
            {
                var result = await _blogCommentService.CreateBlogComment(blogComment);

                return CreatedAtAction(nameof(GetAllCommentsForPost), new { id = blogComment.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<BlogComment>
                {
                    Message = ex.Message
                });
            }
        }

        [ProducesResponseType(200)]
        [HttpPut("UpdatePostComment")]
        public async Task<ActionResult<ServiceResponse<BlogComment>>> Update(BlogComment blogComment)
        {
            try
            {
                var result = await _blogCommentService.UpdateBlogComment(blogComment);

                if (result.Code == "1")
                {
                    return NotFound(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new ServiceResponse<BlogComment>
                {
                    Message = ex.Message
                });
            }
        }

        [ProducesResponseType(204)]
        [HttpDelete("DeletePostComment/{id:int}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            try
            {
                var result = await _blogCommentService.DeleteBlogComment(id);

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
