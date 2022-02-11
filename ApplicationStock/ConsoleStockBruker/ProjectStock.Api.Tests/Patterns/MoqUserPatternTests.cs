using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStockDTOS;
using ProjectStockLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectStockPatternsLibrary;

namespace ProjectStock.Api.Tests.Patterns
{
    internal class MoqUserPatternTests
    {
        public IMapper Mapper { get; set; }

        public MoqUserPatternTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(

                typeof(Client)

                ));
            Mapper = new Mapper(configuration);
        }

        [TestMethod]
        public void ToDto()
        {
            var id = Guid.NewGuid();
            var stock = new Stock();
            UserDto userDto = new UserDto() { Id = id, _addresses = new List<Address>(),_stocks = new List<Stock>(), _email = "test" };
            Client client = new Client(id) { _email = "test" };

            var mapped = client.ToDto();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(UserDto), mapped.GetType());
            Assert.AreEqual(client,userDto);




        }


        [TestMethod]
        public void ToModel()
        {

            var id = Guid.NewGuid();
            var stock = new Stock();
            UserDto userDto = new UserDto() { Id = id, _addresses = new List<Address>(), _stocks = new List<Stock>(), _email = "test" };
            Client client = new Client(id) { _email = "test" };

            var mapped = userDto.ToModel();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(Client), mapped.GetType());
            Assert.AreEqual(client, userDto);
        }

    }
}
