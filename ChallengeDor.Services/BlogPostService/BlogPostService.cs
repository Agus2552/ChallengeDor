using ChallengeDor.Data;
using ChallengeDor.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDor.Services.BlogPostService
{
    public class BlogPostService : IBlogPostService
    {
        private readonly DataContext _context;
        public BlogPostService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<BlogPost>> CreateBlogPost(BlogPost entity)
        {
            var result = await _context.BlogPosts.AddAsync(entity);
            await _context.SaveChangesAsync();
            var response = new ServiceResponse<BlogPost>
            {
                Code = "0",
                Data = result.Entity,
                Message = "Success."
            };
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBlogPost(int id)
        {
            var response = new ServiceResponse<bool>();

            var result = await _context.BlogPosts.FirstOrDefaultAsync(e => e.Id == id);

            if (result == null)
            {
                response.Code = "1";
                response.Message = $"BlogPost with Id = {id} not found.";
            }
            else
            {
                result.Deleted = true;
                await _context.SaveChangesAsync();

                response.Code = "0";
                response.Data = true;
                response.Message = "Success.";
            }

            return response;
        }

        public async Task<ServiceResponse<BlogPost>> GetBlogPost(int id)
        {
            var response = new ServiceResponse<BlogPost>();

            var deposito = await _context.BlogPosts.Where(d => !d.Deleted).FirstOrDefaultAsync(d => d.Id == id);
            if (deposito == null)
            {
                response.Code = "1";
                response.Message = $"BlogPost with Id = {id} not found.";
            }
            else
            {
                response.Code = "0";
                response.Data = deposito;
                response.Message = "Success.";
            }

            return response;
        }

        public async Task<ServiceResponse<List<BlogPost>>> GetBlogPosts()
        {
            var response = new ServiceResponse<List<BlogPost>>
            {
                Code = "0",
                Data = await _context.BlogPosts.Where(d => !d.Deleted).ToListAsync() ,
                Message = "Success."
            };

            return response;
        }

        public async Task<ServiceResponse<BlogPost>> UpdateBlogPost(BlogPost entity)
        {
            var response = new ServiceResponse<BlogPost>();

            var existingEntity = await _context.BlogPosts.FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (existingEntity == null)
            {
                response.Code = "1";
                response.Message = $"BlogPost with Id = {entity.Id} not found.";
            }
            else
            {
                // Adjuntar la entidad existente al contexto
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
