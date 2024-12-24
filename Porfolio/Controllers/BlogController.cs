using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Porfolio.Dto;
using Porfolio.Entity;
using Porfolio.Model;
using Porfolio.Services;
using Porfolio.Services.Interface;

namespace Porfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IFileDetailsService _fileDetailsService;

        public BlogController (IBlogService blogService, IFileDetailsService fileDetailsService )
        {
            _fileDetailsService = fileDetailsService;
            _blogService = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog()
        {
            var ContentPhotos = new List<ContentPhoto>();
            var BlogContents = new List<BlogContent>();
            // Read form data
            var formCollection = await Request.ReadFormAsync();

            var title = formCollection["title"];
            var authorName = formCollection["authorName"];
            var heading = formCollection["heading"];
            var slug = formCollection["slug"];
            var metaTitle = formCollection["metaTitle"];
            var metaDescription = formCollection["metaDescription"].ToString();
            //var serialIdentifierJson = formCollection["serialIdentifier"];
            CoverPhoto coverPhoto = new CoverPhoto();
            BlogVideo blogVideo = new BlogVideo();

            var photo = formCollection.Files.FirstOrDefault(f => f.Name == "coverPhoto");
            if (photo != null)
            {
                FileDetails photoFile = await _fileDetailsService.GetFileDetailsFromFile(photo);
                coverPhoto.Data = photoFile.Data;
                coverPhoto.ContentType = photoFile.ContentType;
                coverPhoto.Path = photoFile.Path;
                coverPhoto.FileName = photoFile.FileName;

            }
            var videoFile = formCollection.Files.FirstOrDefault(f => f.Name == "blogVideo");

            if (videoFile != null)
            {
                var video = await _fileDetailsService.GetFileDetailsFromFile(videoFile);
                blogVideo.Data = video.Data;
                blogVideo.ContentType = video.ContentType;
                blogVideo.Path = video.Path;
                blogVideo.FileName = video.FileName;                
            }

            //Fetching blog contents
            var blogContentsJson = formCollection["blogContents"];

            var tempBlogContents = JsonConvert
                .DeserializeObject<List<BlogContentDto>>(blogContentsJson);

            if (tempBlogContents != null)
            {
                foreach (var blogContent in tempBlogContents)
                {
                    BlogContents.Add(new BlogContent
                    {
                        SerialNo = blogContent.Serial,
                        Content = blogContent.Content,
                        UniqueId = blogContent.UniqueId,
                    }); 
                }
            }

            //Fetching content photos
            var contentPhotoFiles = formCollection.Files.Where(f => f.Name == "contentPhotos").ToList();
            foreach (var file in contentPhotoFiles)
            {
                var fileName = file.FileName;
                if (fileName == null)
                {
                    return BadRequest(new { Message = "Invalid File!"});
                }
                var fileDetails = await _fileDetailsService.GetFileDetailsFromFile(file);
                var contentPhoto = new ContentPhoto
                {
                    SerialNo = fileName.Split('-')[1].ToString(),
                    UniqueId = fileName.Split('-')[2].ToString(),

                    BlogFileDetails = new BlogFileDetails
                    {
                        Name = file.FileName,
                        Type = file.ContentType,
                        Data = fileDetails.Data,
                        Path = ""
                    }

                };
                ContentPhotos.Add(contentPhoto);
            }            

            try
            {

                var blog = new Blog
                {
                    Title = title,
                    Heading = heading,
                    Slug = slug,
                    MetaTitle = metaTitle,
                    MetaDescription = metaDescription,
                    BlogContents = BlogContents,
                    
                    CoverPhoto = coverPhoto != null ?  new CoverPhoto
                    {
                        FileName = coverPhoto.FileName,
                        ContentType = coverPhoto.ContentType,
                        Data = coverPhoto.Data,
                        Path = ""
                    } : null ,
                    BlogVideo = blogVideo!= null ?  new BlogVideo
                    {
                        FileName = blogVideo.FileName,
                        ContentType = blogVideo.ContentType,
                        Data = blogVideo.Data,
                        Path = ""
                    }: null,
                    ContentPhotos = ContentPhotos,
                };

                var createdBlog = await _blogService.CreateBlogAsync(blog);
                return CreatedAtAction(nameof(GetBlogById), new { id = createdBlog.Id }, createdBlog);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _blogService.GetBlogByIdAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _blogService.GetAllBlogsAsync();
            if (blogs == null) return NotFound(new { Message = "Empty Blog Entity"});
            return Ok(blogs);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int BlogId)
        {
            var ContentPhotos = new List<ContentPhoto>();
            var BlogContents = new List<BlogContent>();
            // Read form data
            var formCollection = await Request.ReadFormAsync();

            var title = formCollection["title"];
            var authorName = formCollection["authorName"];
            var heading = formCollection["heading"];
            var slug = formCollection["slug"];
            var metaTitle = formCollection["metaTitle"];
            var metaDescription = formCollection["metaDescription"].ToString();
            //var serialIdentifierJson = formCollection["serialIdentifier"];
            CoverPhoto coverPhoto = new CoverPhoto();
            BlogVideo blogVideo = new BlogVideo();

            var photo = formCollection.Files.FirstOrDefault(f => f.Name == "coverPhoto");
            if (photo != null)
            {
                FileDetails photoFile = await _fileDetailsService.GetFileDetailsFromFile(photo);
                coverPhoto.Data = photoFile.Data;
                coverPhoto.ContentType = photoFile.ContentType;
                coverPhoto.Path = photoFile.Path;
                coverPhoto.FileName = photoFile.FileName;

            }
            var videoFile = formCollection.Files.FirstOrDefault(f => f.Name == "blogVideo");

            if (videoFile != null)
            {
                var video = await _fileDetailsService.GetFileDetailsFromFile(videoFile);
                blogVideo.Data = video.Data;
                blogVideo.ContentType = video.ContentType;
                blogVideo.Path = video.Path;
                blogVideo.FileName = video.FileName;
            }

            //Fetching blog contents
            var blogContentsJson = formCollection["blogContents"];

            var tempBlogContents = JsonConvert
                .DeserializeObject<List<BlogContentDto>>(blogContentsJson);

            if (tempBlogContents != null)
            {
                foreach (var blogContent in tempBlogContents)
                {
                    BlogContents.Add(new BlogContent
                    {
                        SerialNo = blogContent.Serial,
                        Content = blogContent.Content,
                        UniqueId = blogContent.UniqueId,
                    });
                }
            }

            //Fetching content photos
            var contentPhotoFiles = formCollection.Files.Where(f => f.Name == "contentPhotos").ToList();
            foreach (var file in contentPhotoFiles)
            {
                var fileName = file.FileName;
                if (fileName == null)
                {
                    return BadRequest(new { Message = "Invalid File!" });
                }
                var fileDetails = await _fileDetailsService.GetFileDetailsFromFile(file);
                var contentPhoto = new ContentPhoto
                {
                    SerialNo = fileName.Split('-')[1].ToString(),
                    UniqueId = fileName.Split('-')[2].ToString(),

                    BlogFileDetails = new BlogFileDetails
                    {
                        Name = file.FileName,
                        Type = file.ContentType,
                        Data = fileDetails.Data,
                        Path = ""
                    }

                };
                ContentPhotos.Add(contentPhoto);
            }

            try
            {

                var blog = new Blog
                {
                    Title = title,
                    Heading = heading,
                    Slug = slug,
                    MetaTitle = metaTitle,
                    MetaDescription = metaDescription,
                    BlogContents = BlogContents,

                    CoverPhoto = coverPhoto != null ? new CoverPhoto
                    {
                        FileName = coverPhoto.FileName,
                        ContentType = coverPhoto.ContentType,
                        Data = coverPhoto.Data,
                        Path = ""
                    } : null,
                    BlogVideo = blogVideo != null ? new BlogVideo
                    {
                        FileName = blogVideo.FileName,
                        ContentType = blogVideo.ContentType,
                        Data = blogVideo.Data,
                        Path = ""
                    } : null,
                    ContentPhotos = ContentPhotos,
                };

                var createdBlog = await _blogService.CreateBlogAsync(blog);
                return CreatedAtAction(nameof(GetBlogById), new { id = createdBlog.Id }, createdBlog);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var deleted = await _blogService.DeleteBlogByIdAsync(id);
            if (!deleted) return NotFound();

            return Ok(new {Message = $"Blog id = {id} deleted", id});
        }
    }

}
