using ApiApplication.Interface;
using ApiApplication.Model;
using ApiApplicationProjectStock.Controllers;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockRepository.Context;
using ProjectStockRepository.Interfaces;
using ProjectStockRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStock.Api.Tests
{
    public class InMemoryUserControllerTest
    {
        [TestClass]
        public class InMemoryUsersControllerTest
        {
            private UserController UserController { get; set; }

            private IGenericRepository<UserEntity> UserRepository { get; set; }

            private IMapper Mapper { get; set; }

            private ILogger<UserController> Logger { get; set; } = new NullLogger<UserController>();

            private Fixture Fixture { get; set; } = new Fixture();

            private IEnumerable<UserEntity> CleanUserBdd { get; set; }

            private SqlDbContext InMemoryDbContext { get; set; }

            private APIContext ApiContext { get; set; }

            public IUserService IuserService { get; set; }

            public InMemoryUsersControllerTest()
            {
                var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(UserController)));
                Mapper = new Mapper(configuration);
                CleanUserBdd = Fixture.CreateMany<UserEntity>(10);
            }

            [TestInitialize]
            public void InitTest()
            {
                //UserController = new UserController( Mapper, ApiContext, IuserService);
                //var option = new DbContextOptionsBuilder()
                //    .UseInMemoryDatabase("myDataBase").Options;
                //InMemoryDbContext = new DemoDbContext(option);
                //InMemoryDbContext.Database.Migrate();

                UserRepository = new GenericRepository<UserEntity>();
                InMemoryDbContext.AddRange(CleanUserBdd);
                InMemoryDbContext.SaveChanges();
            }

            [TestMethod]
            public void TestGetAllUsers_Ok()
            {
                //Arrange

                //Act
                Guid id = new Guid();
                var result = UserController.Get(id);

                //Assert
                result.Should().NotBeNull();
                var entities = result?.Value as IEnumerable<UserDto>;
                entities.Should().NotBeNull();
                entities.Count().Should().Be(10);
            }


            [TestMethod]
            public void TestGetAllUsers_NullRepository()
            {
                //Arrange
                //UserController = new UserController( Mapper, ApiContext, IuserService );


                //Act
                Guid id = new Guid();
                var result = UserController.Get(id);

                //Assert
                result.Should().NotBeNull();
                result.Should().Be((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
