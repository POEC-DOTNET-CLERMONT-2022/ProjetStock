using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStock.Api.Tests.Patterns
{
    [TestClass]
    internal class MoqOrderPatternTests
    {
        public IMapper Mapper { get; set; }
        
        public MoqOrderPatternTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(
                
                typeof(Order)

                ));
            Mapper = new Mapper(configuration);
        }


        [TestMethod]
        public void ToDto()
        {
            var id = Guid.NewGuid();
            var stock = new Stock();
            OrderDto _orderDto = new OrderDto() { Id = id , _nbStock = 5, _orderDate = DateTime.Now, _orderName = "test", _stock = stock};

            Order _order = new Order("test", stock, 5,DateTime.Now, id);

           

            var mapped_order = _orderDto.ToModel();


            Assert.IsNotNull(mapped_order);
            Assert.IsInstanceOfType(typeof(Order), mapped_order.GetType());
            Assert.AreEqual(_order, _orderDto);




        }


        [TestMethod]
        public void ToModel()
        {

            var id = Guid.NewGuid();
            var stock = new Stock();
            OrderDto _orderDto = new OrderDto() { Id = id, _nbStock = 5, _orderDate = DateTime.Now, _orderName = "test", _stock = stock };

            Order _order = new Order("test", stock, 5, DateTime.Now, id);



            var mapped_order = _order.ToDto();


            Assert.IsNotNull(mapped_order);
            Assert.IsInstanceOfType(typeof(OrderDto), _order.GetType());
            Assert.AreEqual(_order, _orderDto);



        }


    }
}
