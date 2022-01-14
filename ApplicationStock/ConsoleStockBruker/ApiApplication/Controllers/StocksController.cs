using ApiApplication.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockPatternsLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private IMapper _mapper;

        private APIContext _context;
        public StocksController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Get(Guid id)
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Post(StockDto stockDto)
        {
            try
            {
                var p = stockDto.ToModelStock();

                var mapProj = _mapper.Map<StockDto>(p);
                _context._stocks.Add(p);
                _context.SaveChanges();
                return Ok(mapProj);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // GET api/<ProjectController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Put(StockDto stockDto, Guid id)
        {


            var p = _context._stocks.Find(id);

            p._entrepriseName = stockDto._entrepriseName;
            p._value = stockDto._value;
            p._name = stockDto._name;
           

            var mapProj = _mapper.Map<StockDto>(p);
            _context._stocks.Update(p);
            _context.SaveChanges();
            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        public ActionResult<StockDto> Delete(Guid id)
        {
            var p = _context._stocks.Find(id);
            if (p != null)
            {
                _context._stocks.Remove(p);
                _context.SaveChanges();
            }
              
            else
                return NotFound();

            var mapProj = _mapper.Map<StockDto>(p);

            return Ok(mapProj);
        }
    }
}
