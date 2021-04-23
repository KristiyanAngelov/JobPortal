using JobPortal.Data.Common.Repositories;
using JobPortal.Data.Models;
using JobPortal.Services.Data.Interfaces;
using JobPortal.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobPortal.Services.Data
{
    public class WorkersService : IWorkersService
    {
        private readonly IRepository<Worker> workersRepository;

        public WorkersService(IRepository<Worker> workersRepository)
        {
            this.workersRepository = workersRepository;
        }

        public Worker FindById(string workerId)
        {
            return this.workersRepository
                .All()
                .FirstOrDefault(x => x.Id == workerId);
        }

        public T FindById<T>(string workerId)
        {
            return this.workersRepository
                .All()
                .Where(x => x.Id == workerId)
                .To<T>()
                .FirstOrDefault();
        }
    }
}
