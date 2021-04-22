using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data.Models.Enums;
using Xunit;

namespace JobPortal.Services.Data.Tests
{
    using System.Collections.Generic;

    using JobPortal.Data.Common.Repositories;
    using JobPortal.Data.Models;
    using Moq;

    public class SearchJobPostTests
    {
        private readonly List<SearchJobPost> list;
        private readonly Mock<IRepository<SearchJobPost>> searchJobPostsRepositoryMock;
        private readonly SearchJobPostsService service;

        public SearchJobPostTests()
        {
            this.searchJobPostsRepositoryMock = new Mock<IRepository<SearchJobPost>>();
            this.list = new List<SearchJobPost>()
            {
                new SearchJobPost()
                {
                    Id = "1",
                    WorkerId = "1",
                    Worker = new Worker(),
                },
                new SearchJobPost()
                {
                    Id = "2",
                    WorkerId = "2",
                    Worker = new Worker(),
                },
            };
            this.service = new SearchJobPostsService(this.searchJobPostsRepositoryMock.Object);
            this.searchJobPostsRepositoryMock.Setup(x => x.All()).Returns(this.list.AsQueryable());
        }

        [Fact]
        public async Task CreateAsync_Should_Add_New_Element_To_Db()
        {
            this.searchJobPostsRepositoryMock
                .Setup(x => x.AddAsync(It.IsAny<SearchJobPost>()))
                .Callback((SearchJobPost searchJobPost) => this.list.Add(searchJobPost));
            await this.service.CreateAsync("FrontEnd", JobType.FullTime, "3", "Sofia");

            Assert.Equal(3,this.list.Count);
        }

        [Fact]
        public void GetAll_Should_Return_All_Two_Elements()
        {
            var list2 = service.GetAll();

            Assert.Equal(list,list2);
        }

        [Fact]
        public void GetSearchJobById_Should_Return_Correct_SearchJobPost()
        {
            var job = this.service.GetById("2");

            Assert.Equal("2", job.WorkerId);
        }
    }
}
