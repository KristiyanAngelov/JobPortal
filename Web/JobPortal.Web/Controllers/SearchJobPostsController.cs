﻿namespace JobPortal.Web.Controllers
{
    using System.Threading.Tasks;

    using JobPortal.Common;
    using JobPortal.Data.Models;
    using JobPortal.Services.Data.Interfaces;
    using JobPortal.Web.ViewModels.SearchJobPost;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SearchJobPostsController : BaseController
    {
        private readonly ISearchJobPostsService searchJobPostsService;
        private readonly UserManager<ApplicationUser> userManager;

        public SearchJobPostsController(ISearchJobPostsService searchJobPostsService, UserManager<ApplicationUser> userManager)
        {
            this.searchJobPostsService = searchJobPostsService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var viewModel = new AllSearchJobPostsViewModel
            {
                SearchJobPosts = this.searchJobPostsService.GetAllSearchJobPosts<SearchJobPostViewModel>(),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = GlobalConstants.WorkerRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.WorkerRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(string positions, string jobTypes, string workerId, string city)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentWorkerUser = await this.userManager.GetUserAsync(this.HttpContext.User);
            await this.searchJobPostsService.CreateAsync(positions, jobTypes, currentWorkerUser.Id, city);

            return this.RedirectToAction("All");
        }

        public IActionResult GetById(string id)
        {
            var viewModel = this.searchJobPostsService.GetSearchJobPostById<SearchJobPostViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }


    }
}
