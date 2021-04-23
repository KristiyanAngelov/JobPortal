namespace JobPortal.Web.Controllers
{
    using JobPortal.Services.Data.Interfaces;
    using JobPortal.Web.ViewModels.Worker;
    using Microsoft.AspNetCore.Mvc;

    public class WorkersController : BaseController
    {
        private readonly IWorkersService workersService;

        public WorkersController(IWorkersService workersService)
        {
            this.workersService = workersService;
        }

        public IActionResult GetById(string workerId)
        {
            var model = this.workersService.FindById<WorkerViewModel>(workerId);

            return this.View(model);
        }
    }
}
