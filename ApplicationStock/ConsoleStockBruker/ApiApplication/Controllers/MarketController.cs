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
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MarketDto> Get(Guid id)
        {
      
                var p = _context._markets.Find(id);

                var mapProj = _mapper.Map<MarketDto>(p);

                if (mapProj == null)
                    return NotFound();
                else
                    _context.SaveChanges();
                return Ok(mapProj);
            
        }


        // GET api/<ProjectController>/5
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
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MarketDto> Put(MarketDto marketDto,Guid id)
        {


            var p = _context._markets.Find(id);

            p._stock = marketDto._stocks;
            p._name = marketDto._name;
            p._openingDate = marketDto._openingDate;

            var mapProj = _mapper.Map<MarketDto>(p);

            _context._markets.Update(p);
            _context.SaveChanges();

            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        public ActionResult<MarketDto> Delete(Guid id)
        {
            var p = _context._markets.Find(id);
            if(p != null)
              _context._markets.Remove(p);
            else
                return NotFound();

            var mapProj = _mapper.Map<MarketDto>(p);

            _context._markets.Remove(p);
            _context.SaveChanges();
            return Ok(mapProj);
        }
    }
}
