using ChallengeDor.Data;
using ChallengeDor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDor.Services.BlogCommentService
{
    public class BlogCommentService : IBlogCommentService
    {
        private readonly DataContext _context;
        public BlogCommentService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<BlogComment>> CreateBlogComment(BlogComment entity)
        {
            var result = await _context.BlogComments.AddAsync(entity);
            await _context.SaveChangesAsync();
            var response = new ServiceResponse<BlogComment>
            {
                Code = "0",
                Data = result.Entity,
                Message = "Success."
            };
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBlogComment(int id)
        {
            var response = new ServiceResponse<bool>();

            var result = await _context.BlogComments.FirstOrDefaultAsync(e => e.Id == id);

            if (result == null)
            {
                response.Code = "1";
                response.Message = $"BlogComment with Id = {id} not found.";
            }
            else
            {
                _context.BlogComments.Remove(result);
                await _context.SaveChangesAsync();

                response.Code = "0";
                response.Data = true;
                response.Message = "Success.";
            }

            return response;
        }

        public async Task<ServiceResponse<BlogComment>> GetBlogComment(int id)
        {
            var response = new ServiceResponse<BlogComment>();

            var deposito = await _context.BlogComments.FirstOrDefaultAsync(d => d.Id == id);
            if (deposito == null)
            {
                response.Code = "1";
                response.Message = $"BlogComment with Id = {id} not found.";
            }
            else
            {
                response.Code = "0";
                response.Data = deposito;
                response.Message = "Success.";
            }

            return response;
        }

        public async Task<ServiceResponse<List<BlogComment>>> GetBlogCommentsForPost(int id)
        {
            var blogPost = await _context.BlogPosts
                .Include(post => post.Comments) // Ensures all related comments are loaded.
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            if (blogPost != null)
            {
                var response = new ServiceResponse<List<BlogComment>>
                {
                    Code = "0",
                    Data = blogPost.Comments.ToList(),
                    Message = "Success."
                };

                return response;
            }
            else
            {
                var response = new ServiceResponse<List<BlogComment>>
                {
                    Code = "1",
                    Data = null,
                    Message = $"BlogComment with Id = {id} not found."
                };

                return response;
            }
        }


        public async Task<ServiceResponse<BlogComment>> UpdateBlogComment(BlogComment entity)
        {
            var response = new ServiceResponse<BlogComment>();

            var existingEntity = await _context.BlogComments.FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (existingEntity == null)
            {
                response.Code = "1";
                response.Message = $"BlogComment with Id = {entity.Id} not found.";
            }
            else
            {
                entity.UpdatedAt = DateTime.Now;
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);

                await _context.SaveChangesAsync();

                response.Code = "0";
                response.Data = existingEntity;
                response.Message = "Success.";
            }

            return response;
        }
    }
}

