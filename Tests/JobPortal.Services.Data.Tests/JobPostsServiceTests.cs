using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using JobPortal.Data.Common.Repositories;
using JobPortal.Data.Models;
using JobPortal.Services.Mapping;
using JobPortal.Web.ViewModels;
using JobPortal.Web.ViewModels.JobPost;
using Moq;
using Xunit;

namespace JobPortal.Services.Data.Tests
{
    public class JobPostsServiceTests
    {
        private List<JobPost> list;
        private Mock<IRepository<JobPost>> mockRepo;
        private JobPostsService service;

        public JobPostsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);
            this.list = new List<JobPost>()
            {
                new JobPost()
                {
                    Id = "1",
                    CompanyLogo = "www.test.com",
                    PositionName = "Intern",
                    CompanyDescription = "Test",
                    JobResponsibilities = "Test",
                    JobRequirements = "Test",
                    Benefits = "Test",
                    ApplicationDate = new DateTime(2021 - 04 - 20),
                    StartingDate = new DateTime(2021 - 04 - 20),
                    Location = "Sofia",
                },
                new JobPost()
                {
                Id = "2",
                CompanyLogo = "www.test.com2",
                PositionName = "Intern2",
                CompanyDescription = "Test2",
                JobResponsibilities = "Test2",
                JobRequirements = "Test2",
                Benefits = "Test2",
                ApplicationDate = new DateTime(2021 - 04 - 20),
                StartingDate = new DateTime(2021 - 04 - 20),
                Location = "Sofia2",
                },
            };

            this.mockRepo = new Mock<IRepository<JobPost>>();
            this.service = new JobPostsService(this.mockRepo.Object);

            this.mockRepo.Setup(x => x.All())
                .Returns(this.list.AsQueryable());
        }

        [Fact]
        public async Task CreateAsync_Should_Add_New_Element_To_Db()
        {
            this.mockRepo
                .Setup(x => x.AddAsync(It.IsAny<JobPost>()))
                .Callback((JobPost jobPost) => this.list.Add(jobPost));

            var jobPost = new JobPostCreateViewModel()
            {
                CompanyLogo = "www.test.com3",
                PositionName = "Intern3",
                CompanyDescription = "Test3",
                JobResponsibilities = "Test3",
                JobRequirements = "Test3",
                Benefits = "Test3",
                ApplicationDate = new DateTime(2021 - 04 - 20),
                StartingDate = new DateTime(2021 - 04 - 20),
                Location = "Sofia3",
            };

            await this.service.CreateAsync(jobPost, "as-22454a-sff32-34");

            Assert.Equal(3, this.list.Count);
        }

        [Fact]
        public void GetAllJobPosts_Should_Return_All_Entities_From_JobPost_Table()
        {
            var list2 = this.service.GetAll();

            Assert.Equal(this.list, list2);
        }

        [Fact]
        public void GetJobById_Should_Return_Correct_Job()
        {
            var job = this.service.GetById("2");

            Assert.Equal("Intern2", job.PositionName);
        }
    }
}
