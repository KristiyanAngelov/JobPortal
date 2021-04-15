namespace JobPortal.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPortal.Data.Common.Repositories;
    using JobPortal.Data.Models;
    using JobPortal.Services.Data.Interfaces;

    public class OpinionsService : IOpinionsService
    {
        private readonly IRepository<Company> companiesRepository;
        private readonly IRepository<Worker> workersRepository;
        private readonly IRepository<Opinion> opinionsRepository;

        public OpinionsService(IRepository<Company> companiesRepository, IRepository<Worker> workersRepository, IRepository<Opinion> opinionsRepository)
        {
            this.companiesRepository = companiesRepository;
            this.workersRepository = workersRepository;
            this.opinionsRepository = opinionsRepository;
        }

        public async Task CreateAsync(string workerId, string companyName, string opinion)
        {
            var company = this.companiesRepository.All().Where(x => x.Name == companyName).FirstOrDefault();
            var worker = this.workersRepository.All().Where(x => x.Id == workerId).FirstOrDefault();

            var model = new Opinion
            {
                WorkerId = workerId,
                Worker = worker,
                CompanyId = company.Id,
                Company = company,
                Text = opinion,
            };
            company.WorkersOpinions.Add(model);
            worker.Opinions.Add(model);
            await this.opinionsRepository.AddAsync(model);
            await this.opinionsRepository.SaveChangesAsync();
        }

        public ICollection<Opinion> GetAll()
        {
            return this.opinionsRepository.All().ToList();
        }
    }
}
