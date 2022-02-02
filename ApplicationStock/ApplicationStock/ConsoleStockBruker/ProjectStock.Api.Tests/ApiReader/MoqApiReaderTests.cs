using ApiApplication.Controllers;
using ApiApplication.Model;
using ApiApplication.Models;
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
using ProjectStockModels.APIReader.Services;
using ProjectStockModels.JsonReader;
using ProjectStockModels.Model;
using ProjectStockRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStock.Api.Tests.ApiReader
{
    [TestClass]
    internal class MoqApiReaderTests
    {
        private NotificationController NotificationController { get; set; }


        public JsonGenericReader<NotificationModel, NotificationDto> _jsonReader { get; set; }

        public IMapper Mapper { get; set; }

        public ILogger<NotificationController> Logger { get; set; } = new NullLogger<NotificationController>();


        private APIContext APIContext { get; set; }

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<NotificationEntity> Orders { get; set; }


        public MoqApiReaderTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(NotificationController)));
            Mapper = new Mapper(configuration);
            HttpClient httpClient = new HttpClient();
            APIContext = new APIContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIContext>());
            _jsonReader = new NotificationServiceReader(httpClient, Mapper);
        }



        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Orders = Fixture.CreateMany<NotificationEntity>();
            NotificationController = new NotificationController(Mapper, APIContext);
        }




        [TestMethod]
        public void TestGetAll()
        {

            //Arrange
  


            var result_generic = _jsonReader.GetAll();
            var mapped = Mapper.Map<IEnumerable<NotificationDto>>(result_generic);
            var count_mapped = mapped.Count() > 0;
            Assert.IsTrue(count_mapped);


        }



        [TestMethod]
        public void TestGet()
        {

            //Arrange
           
            Guid Id= new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
  
            //Assert
            var result_generic = _jsonReader.Get(Id);
            var mapped = Mapper.Map<IEnumerable<NotificationDto>>(result_generic);
            var count_mapped = mapped.Count() > 0;
            Assert.IsTrue(count_mapped);

       

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
       


            DeleteClass _delete = new DeleteClass();
            _delete.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result =_jsonReader.Delete(_delete.Id);


            //Assert

            result.Should().BeOfType<OkObjectResult>()
     .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);

          

        }




        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
      
            NotificationDto _notif = new NotificationDto();
            _notif.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            _notif.sendAt = DateTime.Now;
            _notif.textRappel = "test";

            var mapped = Mapper.Map<NotificationModel>(_notif);

            var result = _jsonReader.Update(mapped);

            //Assert

            result.Should().BeOfType<OkObjectResult>()
     .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);


        }

        [TestMethod]
        public void TestAdd()
        {
            NotificationDto _notif = new NotificationDto();
            _notif.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            _notif.sendAt = DateTime.Now;
            _notif.textRappel = "test";

            var mapped = Mapper.Map<NotificationModel>(_notif);

            var result = _jsonReader.Update(mapped);

            //Assert

            result.Should().BeOfType<OkObjectResult>()
     .Which.StatusCode.Should().Be((int)HttpStatusCode.OK);


        }
    }
}
