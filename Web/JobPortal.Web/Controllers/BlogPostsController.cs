namespace JobPortal.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using JobPortal.Common;
    using JobPortal.Data.Common.Repositories;
    using JobPortal.Data.Models;
    using JobPortal.Services.Mapping;
    using JobPortal.Web.ViewModels.Blog;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class BlogPostsController : BaseController
    {
        private const int PostsPerPageDefaultValue = 5;
        private readonly IDeletableEntityRepository<BlogPost> blogPosts;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Company> companiesRepository;

        public BlogPostsController(IDeletableEntityRepository<BlogPost> blogPosts, UserManager<ApplicationUser> userManager, IRepository<Company> companiesRepository)
        {
            this.blogPosts = blogPosts;
            this.userManager = userManager;
            this.companiesRepository = companiesRepository;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogPost = await this.blogPosts.All().FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return this.NotFound();
            }

            return this.View(blogPost);
        }

        [Authorize(Roles = GlobalConstants.CompanyRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.CompanyRoleName)]
        public async Task<IActionResult> Create(BlogPost blogPost)
        {
            blogPost.Company = this.companiesRepository.All().Where(x => x.Id == blogPost.CompanyId).FirstOrDefault();
            if (this.ModelState.IsValid)
            {
                await this.blogPosts.AddAsync(blogPost);
                await this.blogPosts.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.AllBlogPosts));
            }

            return this.View(blogPost);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogPost = await this.blogPosts.All().FirstOrDefaultAsync(x => x.Id == id);
            if (blogPost == null)
            {
                return this.NotFound();
            }

            return this.View(blogPost);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.blogPosts.Update(blogPost);
                    await this.blogPosts.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BlogPostExists(blogPost.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Post));
            }

            return this.View(blogPost);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var blogPost = await this.blogPosts.All().FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return this.NotFound();
            }

            return this.View(blogPost);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await this.blogPosts.All().FirstOrDefaultAsync(x => x.Id == id);
            this.blogPosts.Delete(blogPost);
            await this.blogPosts.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Post));
        }

        public IActionResult Post(int id)
        {
            var viewModel =
                this.blogPosts.All().Where(x => x.Id == id).To<BlogPostViewModel>().FirstOrDefault();

            if (viewModel == null)
            {
                return this.NotFound("Blog post not found");
            }

            this.ViewBag.Keywords = viewModel.MetaKeywords;
            this.ViewBag.Description = viewModel.MetaDescription;

            return this.View(viewModel);
        }

        public IActionResult AllBlogPosts(int page = 1, int perPage = PostsPerPageDefaultValue, string keyword = null)
        {
            var pagesCount = 0;
            var posts = this.blogPosts
                .All()
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedOn)
                .To<BlogPostViewModel>();

            if (!string.IsNullOrEmpty(keyword))
            {
                posts = posts
                .Where(x => x.Title.Contains(keyword));

                pagesCount = (int)Math.Ceiling(posts.Count() / (decimal)perPage);
            }
            else
            {
                pagesCount = (int)Math.Ceiling(this.blogPosts.All().Count() / (decimal)perPage);
                posts = posts
                    .Skip(perPage * (page - 1))
                    .Take(perPage);
            }

            var model = new AllBlogPostsViewModel
            {
                BlogPosts = posts.ToList(),
                CurrentPage = page,
                PagesCount = pagesCount,
            };

            return this.View(model);
        }

        private bool BlogPostExists(int id)
        {
            return this.blogPosts.All().Any(e => e.Id == id);
        }
    }
}
