namespace JobPortal.Web.ViewModels.Worker
{
    using JobPortal.Data.Models.Enums;
    using JobPortal.Services.Mapping;

    public class WorkerViewModel : IMapFrom<Data.Models.Worker>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string WorkExperience { get; set; }

        public string Education { get; set; }

        public string CV { get; set; }

        public string LinkedIn { get; set; }

        public string Github { get; set; }
    }
}
