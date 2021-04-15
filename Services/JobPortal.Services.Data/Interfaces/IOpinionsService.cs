namespace JobPortal.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JobPortal.Data.Models;

    public interface IOpinionsService
    {
        public Task CreateAsync(string workerID, string companyName, string opinion);

        public ICollection<Opinion> GetAll();
    }
}
