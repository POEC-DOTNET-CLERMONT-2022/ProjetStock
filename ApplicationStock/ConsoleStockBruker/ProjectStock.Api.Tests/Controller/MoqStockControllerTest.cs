using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplicationProjectStock.Controllers;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
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
using System.Text;
using System.Threading.Tasks;

namespace ProjectStock.Api.Test.Controllers
{
    [TestClass]
    public class MoqStockControllerTest
    {
        private StocksController StockController { get; set; }

        public Mock<IGenericRepository<StockEntity>> stockRepository { get; set; }

        public IMapper Mapper { get; set; }

        public ILogger<StocksController> Logger { get; set; } = new NullLogger<StocksController>();


        private APIContext APIContext { get; set; }

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<StockEntity> Stocks { get; set; }


        public MoqStockControllerTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(StocksController)));
            Mapper = new Mapper(configuration);
            APIContext = new APIContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIContext>());
        }

        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Stocks = Fixture.CreateMany<StockEntity>();
            stockRepository = new Mock<IGenericRepository<StockEntity>>();
            StockController = new StocksController(Mapper, APIContext);
        }




        [TestMethod]
        public void TestGetAll_OK()
        {

            //Arrange
            stockRepository.Setup(repo => repo.GetAll()).Returns(Stocks);
            stockRepository.Setup(repo => repo.Add(It.IsAny<StockEntity>()))
                .Throws(new Exception("test unitaire"));


            var result = StockController.GetAll();
            //Assert
            var entities = result.Value;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);

            stockRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));


        }



        [TestMethod]
        public void TestGet()
        {

            //Arrange
            stockRepository.Setup(repo => repo.GetAll()).Returns(Stocks);
            stockRepository.Setup(repo => repo.Add(It.IsAny<StockEntity>()))
                .Throws(new Exception("test unitaire"));

            Guid _id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = StockController.Get(_id);
            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            stockRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            stockRepository.Setup(repo => repo.GetAll()).Returns(Stocks);
            stockRepository.Setup(repo => repo.Add(It.IsAny<StockEntity>()))
                .Throws(new Exception("test unitaire"));
            DeleteClass _delete = new DeleteClass();
            _delete._id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = StockController.Delete(_delete);


            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            stockRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }




        [TestMethod]
        public void TestUpdate()
        {
            stockRepository.Setup(repo => repo.GetAll()).Returns(Stocks);
            stockRepository.Setup(repo => repo.Add(It.IsAny<StockEntity>()))
                  .Throws(new Exception("test unitaire"));


            StockDto _stock= new StockDto();
            _stock._entrepriseName = "trelleborg";
            _stock._id = Guid.NewGuid();
            _stock._name = "trelleborg";
            _stock._value = 20;



            var result = StockController.Put(_stock);

            var entities = result.Value;
            entities.Should().NotBeNull();
            stockRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }
    }
}
