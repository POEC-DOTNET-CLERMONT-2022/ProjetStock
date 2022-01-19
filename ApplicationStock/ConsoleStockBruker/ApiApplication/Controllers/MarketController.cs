using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockPatternsLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private IMapper _mapper;

        private APIContext _context;
        public MarketController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MarketDto>> GetAll()
        {
            var p = _context._markets.ToList();
            if (p == null)
                return NotFound();
            else
                return Ok(p);

        }


        // GET api/<ProjectController>/Get
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MarketDto> Get([FromQuery]Guid id)
        {
                var p = _context._markets.Find(id);

            
                if (p == null)
                    return NotFound();

                return Ok(p);
            
        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MarketDto> Post( MarketDto    marketDto)
        {
            try
            {

                var p = marketDto.ToModelStock();

                var mapProj = _mapper.Map<MarketDto>(p);


                if (mapProj == null)
                    return NotFound();
                else
                    _context._markets.Add(p);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MarketDto> Put(MarketDto marketDto)
        {


            var p = _context._markets.Find(marketDto._id);

           
            p._name = marketDto._name;
            p._openingDate = marketDto._openingDate;

            var mapProj = _mapper.Map<MarketDto>(p);

            _context._markets.Update(p);
            _context.SaveChanges();

            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        public ActionResult<MarketDto> Delete(DeleteClass delete)
        {
            var p = _context._markets.Find(delete._id);
            if(p != null)
            {
                _context._markets.Remove(p);
          
            }
           
            else
                return NotFound();
            return Ok(p);
        }
    }
}
