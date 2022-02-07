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

namespace ProjectStock.Api.Tests.Controller
{
    [TestClass]
    internal class MoqNotificationControllerTest
    {
        private NotificationController NotificationController { get; set; }

        public Mock<IGenericRepository<NotificationEntity>> notifsRepository { get; set; }

        public IMapper Mapper { get; set; }

        public ILogger<NotificationController> Logger { get; set; } = new NullLogger<NotificationController>();


        private APIContext APIContext { get; set; }

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<NotificationEntity> Orders { get; set; }


        private GenericRepository<Notification> genericRepository;

        public MoqNotificationControllerTest(GenericRepository<Notification> generic)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(NotificationController)));
            Mapper = new Mapper(configuration);
            APIContext = new APIContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIContext>());
            genericRepository = generic;
        }

        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Orders = Fixture.CreateMany<NotificationEntity>();
            notifsRepository = new Mock<IGenericRepository<NotificationEntity>>();
            //NotificationController = new NotificationController(Mapper, APIContext);
        }




        [TestMethod]
        public void TestGetAll_OK()
        {

            //Arrange
            notifsRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            notifsRepository.Setup(repo => repo.Add(It.IsAny<NotificationEntity>()))
                .Throws(new Exception("test unitaire"));


            var result = NotificationController.GetAll();
            //Assert
            var entities = result.Value;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);

            notifsRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));


        }



        [TestMethod]
        public void TestGet()
        {

            //Arrange
            notifsRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            notifsRepository.Setup(repo => repo.Add(It.IsAny<NotificationEntity>()))
                .Throws(new Exception("test unitaire"));


            Guid _id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = NotificationController.Get(_id);
            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            notifsRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
            notifsRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            notifsRepository.Setup(repo => repo.Add(It.IsAny<NotificationEntity>()))
                .Throws(new Exception("test unitaire"));


            DeleteClass _delete = new DeleteClass();
            _delete.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = NotificationController.Delete(_delete);


            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            notifsRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }




        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
            notifsRepository.Setup(repo => repo.GetAll()).Returns(Orders);
            notifsRepository.Setup(repo => repo.Add(It.IsAny<NotificationEntity>()))
                .Throws(new Exception("test unitaire"));




            NotificationDto _notif = new NotificationDto();
            _notif.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            _notif.sendAt = DateTime.Now;
            _notif.textRappel = "test";

            var result = NotificationController.Put(_notif);

            var entities = result.Value;
            entities.Should().NotBeNull();
            notifsRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }
    }
}
