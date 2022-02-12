using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockLibrary;
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

        private readonly IGenericRepository<Order> genericRepository;
        public OrderController(IMapper mapper, APIContext context,IGenericRepository<Order> generic)
        {
            _mapper = mapper;
            _context = context;
            genericRepository = generic;
        }

        //// GET api/<ProjectController>/GetAll
        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var p = genericRepository.GetAll();

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

            var p = genericRepository.GetById(id);

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
                var p = _mapper.Map<Order>(orderDto);

                var mapProj = _mapper.Map<OrderDto>(p);

                if (mapProj == null)
                    return NotFound();
                else
                    genericRepository.Add(p);
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

            var p = genericRepository.GetById(orderDto.Id);

            if (p == null) 
                return NotFound();
            p._orderName = orderDto._orderName;
            p._orderDate = orderDto._orderDate;
            p._nbStock = orderDto._nbStock;
            


            genericRepository.Update(p);
            return Ok();
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        public ActionResult<OrderDto> Delete(DeleteClass delete)
        {
            var p = genericRepository.GetById(delete.Id);
            if (p != null)
            {
               genericRepository.Delete(p);
            }
            else
                return NotFound();

            return Ok(p);

        }

        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderDto))]
        public ActionResult<OrderDto> DeleteById(Guid id)
        {
            var p = genericRepository.GetById(id);
            if (p != null)
            {
                genericRepository.Delete(p);

            }
            else
                return NotFound();

            return Ok(p);

        }
    }
}
