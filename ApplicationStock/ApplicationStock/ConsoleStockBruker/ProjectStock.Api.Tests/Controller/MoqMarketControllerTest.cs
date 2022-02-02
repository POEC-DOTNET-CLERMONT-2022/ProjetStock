using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplicationProjectStock.Controllers;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProjectStockDTOS;
using ProjectStockEntity;
using ProjectStockLibrary;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectStock.Api.Tests.Controller
{
    [TestClass]
    public class MoqMarketControllerTest
    {


        private MarketController MarketController { get; set; }
        
        public Mock<IGenericRepository<MarketEntity>> marketRepository { get; set; }

        public IMapper Mapper { get; set; }

        public ILogger<MarketController> Logger { get; set; } = new NullLogger<MarketController>();


        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<MarketEntity> Markets { get; set; }


        public MoqMarketControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MarketController)));
            Mapper = new Mapper(configuration);
        }


        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Markets = Fixture.CreateMany<MarketEntity>();   
            marketRepository = new Mock<IGenericRepository<MarketEntity>>();
           // MarketController = new MarketController(Mapper, new APIContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIContext>()));
        }




        [TestMethod]
        public void TestGetAll_OK()
        {

            //Arrange
            marketRepository.Setup(repo => repo.GetAll()).Returns(Markets);
            marketRepository.Setup(repo => repo.Add(It.IsAny<MarketEntity>()))
                .Throws(new Exception("test unitaire"));


            var result = MarketController.GetAll();
            //Assert
            var entities = result.Value;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);

            marketRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));


        }



        [TestMethod]
        public void TestGet()
        {

            //Arrange
            marketRepository.Setup(repo => repo.GetAll()).Returns(Markets);
            marketRepository.Setup(repo => repo.Add(It.IsAny<MarketEntity>()))
                .Throws(new Exception("test unitaire"));

            Guid _id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = MarketController.Get(_id);
            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            marketRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));
            
        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            marketRepository.Setup(repo => repo.GetAll()).Returns(Markets);
            marketRepository.Setup(repo => repo.Add(It.IsAny<MarketEntity>()))
                .Throws(new Exception("test unitaire"));
            DeleteClass _delete = new DeleteClass();
            _delete.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = MarketController.Delete(_delete);


            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            marketRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }




        [TestMethod]
        public void TestUpdate()
        {
            marketRepository.Setup(repo => repo.GetAll()).Returns(Markets);
            marketRepository.Setup(repo => repo.Add(It.IsAny<MarketEntity>()))
                  .Throws(new Exception("test unitaire"));


            MarketDto _market = new MarketDto();
            _market._closingDate = DateTime.Now;
            _market._openingDate = DateTime.Now;
            _market._name = "test";
            _market._stocks = new List<Stock>();
         
            var result = MarketController.Put(_market);

            var entities = result.Value;
            entities.Should().NotBeNull();
            marketRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }
    }
}
