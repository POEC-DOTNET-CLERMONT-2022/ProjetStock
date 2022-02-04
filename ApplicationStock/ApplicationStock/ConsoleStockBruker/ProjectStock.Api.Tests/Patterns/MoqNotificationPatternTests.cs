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
    internal class MoqNotificationPatternTests
    {
        public IMapper Mapper { get; set; }

        public MoqNotificationPatternTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(

                typeof(Notification)

                ));
            Mapper = new Mapper(configuration);
        }


        [TestMethod]
        public void ToDto()
        {
            var id = Guid.NewGuid();
            var stock = new Stock();
   

            Notification notification = new Notification("test",DateTime.Now) { Id = id };
            NotificationDto notificationDto = new NotificationDto() { Id = id, sendAt = DateTime.Now, textRappel="test" };
            var mapped = notification.ToDtoStock();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(NotificationDto), mapped.GetType());
            Assert.AreEqual(notification,notificationDto);




        }


        [TestMethod]
        public void ToModel()
        {

            var id = Guid.NewGuid();
            var stock = new Stock();


            Notification notification = new Notification("test", DateTime.Now) { Id = id };
            NotificationDto notificationDto = new NotificationDto() { Id = id, sendAt = DateTime.Now, textRappel = "test" };
            var mapped = notificationDto.ToModelStock();

            Assert.IsNotNull(mapped);
            Assert.IsInstanceOfType(typeof(Notification), mapped.GetType());
            Assert.AreEqual(notification, notificationDto);



        }

    }
}
