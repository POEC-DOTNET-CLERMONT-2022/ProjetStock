using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockPatternsLibrary;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly APIContext _context;
        public StocksController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
           
        }


        //// GET api/<ProjectController>/GetAll
        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<StockDto>> GetAll()
        {
            var p = _context._stocks.ToList();
            if (p == null)
                return NotFound();
            else
                return Ok(p);

        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Get([FromQuery] Guid id)
        {
            try { 
               var p = _context._stocks.Find(id);

               var mapProj = _mapper.Map<StockDto>(p);

               if (mapProj == null)
                  return NotFound();
               else
                  return Ok(mapProj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProjectController>/5
        [Authorize]
      
        [HttpPost]
     
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Post(StockDto stockDto)
        {

            try
            {
                var p = stockDto.ToModelStock();

             
                _context._stocks.Add(p);
                _context.SaveChanges();
                return Ok(p);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Put(StockDto stockDto)
        {


            var p = _context._stocks.Find(stockDto._id);

            p._entrepriseName = stockDto._entrepriseName;
            p._value = stockDto._value;
            p._name = stockDto._name;
           

            var mapProj = _mapper.Map<StockDto>(p);
            _context._stocks.Update(p);
            _context.SaveChanges();
            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [Authorize]

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        public ActionResult<StockDto> Delete(DeleteClass delete)
        {
            var p = _context._stocks.Find(delete._id);
            if (p != null)
            {
                _context._stocks.Remove(p);
                _context.SaveChanges();
                return Ok(p);

            }
              
            else
                return NotFound();

     

          
        }
    }
}
