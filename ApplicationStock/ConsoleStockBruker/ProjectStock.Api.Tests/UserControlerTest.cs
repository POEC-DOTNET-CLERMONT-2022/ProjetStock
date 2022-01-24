using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStockEntity;
using AutoMapper;
using ProjectStockRepository.Interfaces;
using ApiApplicationProjectStock.Controllers;
using ProjectStockRepository.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ApiApplication.Model;
using ApiApplication.Interface;
using System;
using FluentAssertions;
using System.Collections.Generic;
using ProjectStockDTOS;
using System.Net;

namespace ProjectStock.Api.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        private UserController UserController { get; set; }
        public IGenericRepository<UserEntity> UserRepository { get; set; } = new GenericRepository<UserEntity>();

        public IMapper Mapper { get; set; }

        public IUserService Iuserservice { get; set; }
        private APIContext APIContext { get; set; }

        public ILogger<UserController> Logger { get; set; } = new NullLogger<UserController>();

        public UserControllerTest()
        {
            var congiguation = new MapperConfiguration(conf => conf.AddMaps(typeof(UserController)));
        }

        [TestInitialize]
        public void InitTest()
        {
            UserController = new UserController(Mapper,APIContext , Iuserservice);
        }
        [TestMethod]
        public void TestGetAllUsers_Ok()
        {
            //Arrange

            //Act\
            Guid id = new Guid();
            var result = UserController.Get(id);

            //Assert
           
            result.Should().NotBeNull();
            var entities = result?.Value as IEnumerable<UserDto>;
            entities.Should().NotBeNull();
        }


        [TestMethod]
        public void TestGetAllUsers_NullRepository()
        {
            //Arrange
            UserController = new UserController(null, APIContext, Iuserservice);


            //Act
            Guid id = new Guid();
            var result = UserController.Get(id);

            //Assert
            
            result.Should().NotBeNull();
            result.Should().Be((int)HttpStatusCode.InternalServerError);
        }
    }
}