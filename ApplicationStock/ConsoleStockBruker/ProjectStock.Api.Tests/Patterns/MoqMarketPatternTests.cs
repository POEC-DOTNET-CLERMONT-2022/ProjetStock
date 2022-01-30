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
    [TestClass]
    internal class MoqMarketPatternTests
    {
        public IMapper Mapper { get; set; }

        public MoqMarketPatternTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(

                typeof(Market)

                ));
            Mapper = new Mapper(configuration);
        }


        [TestMethod]
        public void ToDto()
        {
            var id = Guid.NewGuid();
            var stock = new Stock();

            MarketDto marketDto = new MarketDto() { _id=id, _closingDate= DateTime.Now,_openingDate= DateTime.Now,_name = "test", _stocks = new List<Stock>()};
            Market _market = new Market("test",DateTime.Now,DateTime.Now) { _id = id, _closingDate = DateTime.Now, _openingDate = DateTime.Now, _name = "test", _stock = new List<Stock>() };


            var mapped = _market.ToDtoStock();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(MarketDto), mapped.GetType());
            Assert.AreEqual(_market,marketDto);




        }


        [TestMethod]
        public void ToModel()
        {

            var id = Guid.NewGuid();
            var stock = new Stock();

            MarketDto marketDto = new MarketDto() { _id = id, _closingDate = DateTime.Now, _openingDate = DateTime.Now, _name = "test", _stocks = new List<Stock>() };
            Market _market = new Market("test", DateTime.Now, DateTime.Now) { _id = id, _closingDate = DateTime.Now, _openingDate = DateTime.Now, _name = "test", _stock = new List<Stock>() };


            var mapped = marketDto.ToModelStock();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(Market), mapped.GetType());
            Assert.AreEqual(_market, marketDto);



        }
    }
}
