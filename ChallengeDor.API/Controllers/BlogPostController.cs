using Microsoft.AspNetCore.Mvc;

namespace ChallengeDor.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogPostController
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BlogPost>>>> GetAll() { 
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServiceResponse<BlogPost>>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<BlogPost>>> Create(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<BlogPost>>> Update(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
