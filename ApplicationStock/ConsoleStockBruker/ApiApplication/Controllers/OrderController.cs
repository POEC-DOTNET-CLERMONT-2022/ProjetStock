﻿using ApiApplication.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockPatternsLibrary.Factory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IMapper _mapper;

        private APIContext _context;
        public OrderController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> Get(Guid id)
        {

            var p = _context._orders.Find(id);

            var mapProj = _mapper.Map<OrderDto>(p);

            return Ok(mapProj);
        }


        // GET api/<ProjectController>/5
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MarketDto> Post(OrderDto orderDto)
        {

            var p = orderDto.ToModel();

            var mapProj = _mapper.Map<MarketDto>(p);

            return Ok(mapProj);
        }


        // GET api/<ProjectController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> Put(OrderDto orderDto, int id)
        {


            var p = _context._orders.Find(id);


            p._orderName = orderDto._orderName;
            p._orderDate = orderDto._orderDate;
            p._nbStock = orderDto._nbStock;
           

            var mapProj = _mapper.Map<MarketDto>(p);

            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        public ActionResult<OrderDto> Delete(Guid id)
        {
            var p = _context._orders.Find(id);
            if (p != null)
                _context._orders.Remove(p);
            else
                return NotFound();

            var mapProj = _mapper.Map<OrderDto>(p);
            return Ok(mapProj);
        }
    }
}