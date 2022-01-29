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
using ApiApplication.Models;

namespace ProjectStock.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private UserController UserController { get; set; }
        public IGenericRepository<UserEntity> UserRepository { get; set; } = new GenericRepository<UserEntity>();

        private IMapper Mapper { get; set; }

        private IUserService Iuserservice { get; set; }
        private APIContext APIContext { get; set; }

        public ILogger<UserController> Logger { get; set; } = new NullLogger<UserController>();

        public UserControllerTest()
        {
            var configuation = new MapperConfiguration(conf => conf.AddMaps(typeof(UserController)));
            Mapper = new Mapper(configuation);
         
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
            UserController = new UserController(Mapper, APIContext, Iuserservice);


            //Act
            Guid id = new Guid();
            var result = UserController.Get(id);

            //Assert
            
            result.Should().NotBeNull();
            result.Should().Be((int)HttpStatusCode.InternalServerError);
        }



        [TestMethod]
        public void TestAuthenticate()
        {
            //Arrange
            UserController = new UserController(Mapper, APIContext, Iuserservice);


            //Act
            AuthenticateRequest _requestAuthenticate = new AuthenticateRequest();
            _requestAuthenticate._email = "test@gmail.fr";
            _requestAuthenticate._password = "string";
            var result = UserController.Authenticate(_requestAuthenticate);

            //Assert

            result.Should().NotBeNull();
            result.Should().Be((int)HttpStatusCode.OK);
        }



        [TestMethod]
        public void TestRegister()
        {     
            //Arrange
            UserController = new UserController(Mapper, APIContext, Iuserservice);


            //Act
            CreateResult _create = new CreateResult();
            _create._email = "toto@gmail.fr";
            _create._password = "sUP3rPassw@rd";
            _create._firstName = "Enzo";
            _create._lastName = "frara";
            var result = UserController.Register(_create);

            //Assert

            result.Should().NotBeNull();
            result.Should().Be((int)HttpStatusCode.OK);

        }
 
        [TestMethod]
        public void TestLogout()
        {

            UserController = new UserController(Mapper, APIContext, Iuserservice);
            var result = UserController.Logout();
            result.Should().NotBeNull();
            result.Should().Be((int)HttpStatusCode.OK);
        }
    }
}