
using Porfolio.Entity;
using Porfolio.Model;
using Porfolio.Repositories;
using Porfolio.Services.Interface;

namespace Porfolio.Services
{
    public interface IBlogService
    {
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> GetBlogByIdAsync(int id);
        Task<List<Blog>> GetAllBlogsAsync();
        Task<bool> DeleteBlogByIdAsync(int BlogId);
        Task<Blog> UpdateBlogByIdAsync(int BlogId, Blog blog); 
    }
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IFileDetailsService _fileDetailsService;

        public BlogService(IBlogRepository blogRepository, IFileDetailsService fileDetailsService)
        {
            _blogRepository = blogRepository;
            _fileDetailsService = fileDetailsService;
        }        
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
             return await _blogRepository.CreateBlogAsync(blog); 
        }
        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _blogRepository.GetBlogByIdAsync(id);
        }
        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _blogRepository.GetAllBlogAsync();
        }
        public async Task<bool> DeleteBlogByIdAsync(int BlogId)
        {
            return await _blogRepository.DeleteBlogByIdAsync(BlogId);
        }
        public async Task<Blog> UpdateBlogByIdAsync(int BlogId, Blog blog)
        {
            return await _blogRepository.UpdateBlogByIdAsync(BlogId, blog);
        }
    }
}

