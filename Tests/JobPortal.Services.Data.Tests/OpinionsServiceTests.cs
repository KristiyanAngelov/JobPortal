using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Data.Common.Repositories;
using JobPortal.Data.Models;
using JobPortal.Services.Mapping;
using JobPortal.Web.ViewModels;
using Moq;
using Xunit;

namespace JobPortal.Services.Data.Tests
{
    public class OpinionsServiceTests
    {
        private readonly List<Opinion> list;
        private readonly Mock<IRepository<Company>> companiesMockRepo;
        private readonly Mock<IRepository<Worker>> workersMockRepo;
        private readonly Mock<IRepository<Opinion>> opinionMockRepo;
        private readonly OpinionsService service;

        public OpinionsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            this.companiesMockRepo = new Mock<IRepository<Company>>();
            this.workersMockRepo = new Mock<IRepository<Worker>>();
            this.opinionMockRepo = new Mock<IRepository<Opinion>>();
            this.list = new List<Opinion>();
            this.service = new OpinionsService(this.companiesMockRepo.Object, this.workersMockRepo.Object, this.opinionMockRepo.Object);

        }

        [Fact]
        public async Task Create_Should_Add_Correct_Model_In_Database()
        {
            this.companiesMockRepo.Setup(x => x.All())
                .Returns(new List<Company>()
                {
                    new Company()
                    {
                        Id = "1",
                        Name = "TestCompany",
                        WorkersOpinions = new List<Opinion>(),
                    },
                }.AsQueryable());

            this.workersMockRepo.Setup(x => x.All())
                .Returns(new List<Worker>()
                {
                    new Worker()
                    {
                        Id = "1",
                        FirstName = "TestWorker",
                        Opinions = new List<Opinion>(),
                    },
                }.AsQueryable());
            this.opinionMockRepo.Setup(x => x.AddAsync(It.IsAny<Opinion>()))
                .Callback((Opinion opinion) => this.list.Add(opinion));
            var listWorker = this.workersMockRepo.Object.All();
            var listCompany = this.companiesMockRepo.Object.All();

            await this.service.CreateAsync("1", "TestCompany", "Test opinion");

            Assert.Equal(1, this.list.Count);
        }

        [Fact]
        public void GetAll_Should_Return_All_Opinions()
        {
            for (int i = 0; i < 3; i++)
            {
                var input = new Opinion()
                {
                    Worker = new Worker(),
                    Company = new Company(),
                    CompanyId = i.ToString(),
                    Text = "test" + i.ToString(),
                    WorkerId = i.ToString(),
                };
                this.list.Add(input);
            }

            this.opinionMockRepo.Setup(x => x.All()).Returns(this.list.AsQueryable);

            Assert.Equal(3, this.list.Count);
        }
    }
}
