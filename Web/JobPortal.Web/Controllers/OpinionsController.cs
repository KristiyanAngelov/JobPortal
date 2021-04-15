namespace JobPortal.Web.Controllers
{
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
        private readonly IOpinionsService opinionsService;
        private readonly UserManager<ApplicationUser> userManager;

        public OpinionsController(IOpinionsService opinionsService, UserManager<ApplicationUser> userManager)
        {
            this.opinionsService = opinionsService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var model = new AllOpinionsViewModel
            {
                Opinions = this.opinionsService.GetAll(),
            };

            return this.View(model);
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
