using ApiApplication.Controllers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Service.Interfaces;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectStock.Api.Tests.Divers
{
    [TestClass]
    internal class MoqPasswordHasherTest
    {

        public IPasswordHasherService _passwordHasherService { get; set; }

        public MoqPasswordHasherTest()
        {
      
        }


        [TestInitialize]
        public void InitTest()
        {

            
        }


        [TestMethod]
        public void TestPasswordHasher()
        {
            var test = "test";
            var result = _passwordHasherService.GetPasswordHasher(test);
            bool match = Regex.IsMatch(result, "^[A-Fa-f0-9]{64}$");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));


            Assert.AreNotSame(test, result);

            Assert.IsTrue(match);
           


        }





    }
}
