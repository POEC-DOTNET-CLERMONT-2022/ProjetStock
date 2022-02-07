using ApiApplication.Controllers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository;
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

namespace ProjectStock.Api.Tests.Controller
{
    [TestClass]
    public  class MoqOrderControllerTest
    {
        private OrderController OrderController { get; set; }

        public Mock<IGenericRepository<OrderEntity>> orderRepository { get; set; }

        public IMapper Mapper { get; set; }

        public ILogger<OrderController> Logger { get; set; } = new NullLogger<OrderController>();


        private APIContext APIContext { get; set; }

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<OrderEntity> Orders { get; set; }

        private GenericRepository<Order> genericRepository;

        public MoqOrderControllerTest(GenericRepository<Order> generic)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(OrderController)));
            Mapper = new Mapper(configuration);
            APIContext = new APIContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIContext>());
            genericRepository = generic;
        }

        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Orders = Fixture.CreateMany<OrderEntity>();
            orderRepository = new Mock<IGenericRepository<OrderEntity>>();
           // OrderController = new OrderController(Mapper, APIContext);
        }




        [TestMethod]
        public void TestGetAll_OK()
        {

            //Arrange
            orderRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            orderRepository.Setup(repo => repo.Add(It.IsAny<OrderEntity>()))
                .Throws(new Exception("test unitaire"));


            var result = OrderController.GetAll();
            //Assert
            var entities = result.Value;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);

            orderRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));


        }



        [TestMethod]
        public void TestGet()
        {

            //Arrange
            orderRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            orderRepository.Setup(repo => repo.Add(It.IsAny<OrderEntity>()))
                .Throws(new Exception("test unitaire"));

            Guid _id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = OrderController.Get(_id);
            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            orderRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            //Arrange
            orderRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            orderRepository.Setup(repo => repo.Add(It.IsAny<OrderEntity>()))
                .Throws(new Exception("test unitaire"));

            DeleteClass _delete = new DeleteClass();
            _delete.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = OrderController.Delete(_delete);


            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            orderRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }




        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            orderRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            orderRepository.Setup(repo => repo.Add(It.IsAny<OrderEntity>()))
                .Throws(new Exception("test unitaire"));



            OrderDto _order = new OrderDto();
            _order.Id = Guid.NewGuid();
            _order._orderName = "test";
            _order._stock = new Stock();


            var result = OrderController.Put(_order);

            var entities = result.Value;
            entities.Should().NotBeNull();
            orderRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }
    }
}
