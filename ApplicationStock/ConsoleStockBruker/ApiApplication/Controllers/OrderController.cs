using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
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

        private readonly IMapper _mapper;

        private readonly APIContext _context;
        public OrderController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //// GET api/<ProjectController>/GetAll
        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var p = _context._orders.ToList();
            if (p == null)
                return NotFound();
            else
                return Ok(p);

        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> Get([FromQuery] Guid id)
        {

            var p = _context._orders.Find(id);

            var mapProj = _mapper.Map<OrderDto>(p);

           if (mapProj == null)
                return NotFound();
            else
                return Ok(mapProj);
        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> Post(OrderDto orderDto)
        {
            try
            {
                var p = orderDto.ToModel();

                var mapProj = _mapper.Map<OrderDto>(p);

                if (mapProj == null)
                    return NotFound();
                else
                    _context._orders.Add(p);
                _context.SaveChanges();
                return Ok(mapProj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> Put(OrderDto orderDto)
        {

            var p = _context._orders.Find(orderDto._id);
            p._orderName = orderDto._orderName;
            p._orderDate = orderDto._orderDate;
            p._nbStock = orderDto._nbStock;
            

            _context._orders.Update(p);
            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        public ActionResult<OrderDto> Delete(DeleteClass delete)
        {
            var p = _context._orders.Find(delete._id);
            if (p != null)
            {
                _context._orders.Remove(p);
                _context.SaveChanges();

            }
            else
                return NotFound();

            return Ok(p);

        }
    }
}
