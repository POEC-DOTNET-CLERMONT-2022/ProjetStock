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
    internal class MoqStockPatternTests
    {
        public IMapper Mapper { get; set; }

        public MoqStockPatternTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(

                typeof(Stock)

                ));
            Mapper = new Mapper(configuration);
        }


        [TestMethod]
        public void ToDto()
        {
            var id = Guid.NewGuid();
            var stock = new Stock();


            StockDto _stockDto  = new StockDto() { Id = id, _name = "test", _value =1000,_entrepriseName= "michelin"};

            Stock _stock = new Stock(id, "test", 1000, "michelin");



            var mapped = _stock.ToDtoStock();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(StockDto), mapped.GetType());
            Assert.AreEqual(_stock,_stockDto);




        }


        [TestMethod]
        public void ToModel()
        {

            var id = Guid.NewGuid();
            var stock = new Stock();


            StockDto _stockDto = new StockDto() { Id = id, _name = "test", _value = 1000, _entrepriseName = "michelin" };

            Stock _stock = new Stock(id, "test", 1000, "michelin");



            var mapped = _stockDto.ToModelStock();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(Stock), mapped.GetType());
            Assert.AreEqual(_stock, _stockDto);


        }

    }
}
