using ApiApplication.Controllers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository;
using ApiApplication.Profil.Repository.Interfaces;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStock.Api.Tests.Controllers
{

    [TestClass]
    internal class MoqAddressControllerTest
    {
        private AddressController AddressController { get; set; }

        public Mock<IGenericRepository<Address>> AddressRepository { get; set; }

        public IMapper Mapper { get; set; }

        public ILogger<AddressController> Logger { get; set; } = new NullLogger<AddressController>();


        private IGenericRepository<Address> genericRepository; 

        private APIContext APIContext { get; set; }

        private Fixture Fixture { get; set; } = new Fixture();

        private IEnumerable<Address> Addresses{ get; set; }

      


        public MoqAddressControllerTest(GenericRepository<Address> generic)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(AddressController)));
            Mapper = new Mapper(configuration);
            APIContext = new APIContext(new Microsoft.EntityFrameworkCore.DbContextOptions<APIContext>());
            genericRepository = generic;
       
        }

        [TestInitialize]
        public void InitTest()
        {
            Fixture = new Fixture();
            Addresses = Fixture.CreateMany<Address>();
           
            AddressRepository = new Mock<IGenericRepository<Address>>();
            AddressController = new AddressController(Mapper, APIContext,genericRepository);
        }




        [TestMethod]
        public void TestGetAll_OK()
        {

            //Arrange
          
            AddressRepository.Setup(repo => repo.Add(It.IsAny<Address>()))
                .Throws(new Exception("test unitaire"));


            var result = AddressController.GetAll();
            //TODO vérifier le code de retour 
            //Assert
            var entities = result.Value;
            entities.Should().NotBeNull();
            entities.Count().Should().Be(10);

            AddressRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));


        }



        [TestMethod]
        public void TestGet()
        {

            //Arrange
            
            AddressRepository.Setup(repo => repo.Add(It.IsAny<Address>()))
                .Throws(new Exception("test unitaire"));


            Guid _id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = AddressController.Get(_id);
            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            AddressRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }

        [TestMethod]
        public void TestDelete()
        {
            //Arrange
          
            AddressRepository.Setup(repo => repo.Add(It.IsAny<Address>()))
                .Throws(new Exception("test unitaire"));


            DeleteClass _delete = new DeleteClass();
            _delete.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            var result = AddressController.Delete(_delete);


            //Assert

            var entities = result.Value;
            entities.Should().NotBeNull();

            AddressRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));

        }




        [TestMethod]
        public void TestUpdate()
        {
            //Arrange
           
            AddressRepository.Setup(repo => repo.Add(It.IsAny<Address>()))
                .Throws(new Exception("test unitaire"));




            AddressDto _Address = new AddressDto();
            _Address.Id = new Guid("23467B99 - 0F3E-42DF - A7AC - 43869A1E07C0");
            _Address._address_line_1 = "41 rue du cerf volant";
            _Address._address_line_2 = "Address";
            _Address._city = "lyon";
            _Address._country = "allemagne";

             var result = AddressController.Put(_Address);

            var entities = result.Value;
            entities.Should().NotBeNull();
            AddressRepository.Verify(repo => repo.GetAll(), Times.Exactly(1));
        }
    }
}
