namespace JobPortal.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using JobPortal.Common;
    using JobPortal.Data.Models;
    using JobPortal.Services.Data.Interfaces;
    using JobPortal.Web.ViewModels;
    using JobPortal.Web.ViewModels.Opinion;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class OpinionsController : BaseController
    {
        private const int PostsPerPageDefaultValue = 5;
        private readonly IOpinionsService opinionsService;
        private readonly UserManager<ApplicationUser> userManager;

        public OpinionsController(IOpinionsService opinionsService, UserManager<ApplicationUser> userManager)
        {
            this.opinionsService = opinionsService;
            this.userManager = userManager;
        }

        public IActionResult All(int page = 1, int perPage = PostsPerPageDefaultValue)
        {
            var pagesCount = (int)Math.Ceiling(this.opinionsService.GetAll().Count() / (decimal)perPage);

            var posts = this.opinionsService
                .GetAll()
                .Skip(perPage * (page - 1))
                .Take(perPage);

            var model = new AllOpinionsViewModel
            {
                Opinions = posts.ToList(),
                CurrentPage = page,
                PagesCount = pagesCount,
            };

            return this.View(model);
            //var model = new AllOpinionsViewModel
            //{
            //    Opinions = this.opinionsService.GetAll(),
            //};

            //return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.WorkerRoleName)]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.WorkerRoleName)]
        public async Task<IActionResult> Create(CreateOpinionViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var currentWorker = await this.userManager.GetUserAsync(this.HttpContext.User);

            await this.opinionsService.CreateAsync(currentWorker.Id, inputModel.CompanyName, inputModel.Text);

            return this.RedirectToAction("All");
        }
    }
}
