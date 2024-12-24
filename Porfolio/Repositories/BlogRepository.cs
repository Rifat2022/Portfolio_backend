using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Porfolio.Data;
using Porfolio.Entity;

namespace Porfolio.Repositories
{
    public interface IBlogRepository
    {
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> GetBlogByIdAsync(int blogId);
        Task<List<Blog>> GetAllBlogAsync();
        Task<bool> DeleteBlogByIdAsync(int blogId);
        Task<Blog> UpdateBlogByIdAsync(int BlogId, Blog blog); 

    }
    public class BlogRepository : IBlogRepository
    {
        private readonly PortfolioContext _context;

        public BlogRepository(PortfolioContext context)
        {
            _context = context;
        }
        // Create a new Blog
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            try
            {
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            
        }

        // Get a Blog by its ID
        public async Task<Blog> GetBlogByIdAsync(int blogId)
        {

            return await _context.Blogs
                    .Include(b => b.Comments)
                    .Include(b => b.BlogCategories)
                    .Include(b => b.ContentPhotos)
                    .Include(b => b.BlogVideo)
                    .Include(b => b.BlogContents)
                    .FirstOrDefaultAsync(b => b.Id == blogId) ?? new Blog();
        }

        // Get all Blogs
        public async Task<List<Blog>> GetAllBlogAsync()
        {
            return await _context.Blogs
                .Include(b => b.Comments)
                .Include(b => b.BlogCategories)
                .Include(b => b.ContentPhotos)
                .Include(b => b.BlogVideo)
                .Include(b => b.BlogContents)
                //.Include(b => b.SerialIdentifier)
                .ToListAsync();
        }

        // Update an existing Blog
        public async Task<Blog> UpdateBlogByIdAsync(int BlogId, Blog blog)
        {
            var existingBlog = await _context.Blogs.FindAsync(BlogId);
            if (existingBlog == null)
            {
                throw new Exception("Blog not found");
            }

            // Update properties
            existingBlog.AuthorName = blog.AuthorName;
            existingBlog.Title = blog.Title;
            existingBlog.Heading = blog.Heading;
            existingBlog.Slug = blog.Slug;
            existingBlog.MetaDescription = blog.MetaDescription;
            existingBlog.CreatedAt = blog.CreatedAt;
            existingBlog.BlogVideo = blog.BlogVideo;
            existingBlog.BlogContents = blog.BlogContents;
            //existingBlog.SerialIdentifier = blog.SerialIdentifier;
            existingBlog.Comments = blog.Comments;
            existingBlog.BlogCategories = blog.BlogCategories;
            existingBlog.ContentPhotos = blog.ContentPhotos;

            await _context.SaveChangesAsync();
            return existingBlog;
        }

        // Get a Blog by a specific condition (e.g., Title)
        public async Task<Blog> GetAsync(string title)
        {
            return await _context.Blogs
                .Include(b => b.Comments)
                .Include(b => b.BlogCategories)
                .Include(b => b.ContentPhotos)
                .Include(b => b.BlogVideo)
                .Include(b => b.BlogContents)
                //.Include(b => b.SerialIdentifier)
                .FirstOrDefaultAsync(b => b.Title == title) ?? new Blog();
        }

        // Delete a Blog by its ID
        public async Task<bool> DeleteBlogByIdAsync(int blogId)
        {
            var blog = await _context.Blogs.FindAsync(blogId);
            if (blog == null)
            {
                return false; // Blog not found
            }
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return true; // Blog deleted successfully
        }
    }

}
