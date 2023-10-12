using ChallengeDor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDor.Services.BlogCommentService
{
    public interface IBlogCommentService
    {
        Task<ServiceResponse<List<BlogComment>>> GetBlogCommentsForPost(int id);
        Task<ServiceResponse<BlogComment>> CreateBlogComment(BlogComment entity);
        Task<ServiceResponse<bool>> DeleteBlogComment(int id);
        Task<ServiceResponse<BlogComment>> UpdateBlogComment(BlogComment entity);
        Task<ServiceResponse<BlogComment>> GetBlogComment(int id);
    }
}
