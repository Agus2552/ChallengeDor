using ChallengeDor.Models;

namespace ChallengeDor.Services.BlogPostService
{
    public interface IBlogPostService
    {
        Task<ServiceResponse<List<BlogPost>>> GetBlogPosts();
        Task<ServiceResponse<BlogPost>> CreateBlogPost(BlogPost entity);
        Task<ServiceResponse<bool>> DeleteBlogPost(int id);
        Task<ServiceResponse<BlogPost>> UpdateBlogPost(BlogPost entity);
        Task<ServiceResponse<BlogPost>> GetBlogPost(int id);
    }
}
