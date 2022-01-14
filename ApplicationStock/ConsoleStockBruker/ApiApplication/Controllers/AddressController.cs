using ApiApplication.Model;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockPatternsLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IMapper _mapper;

        private APIContext _context;
        public AddressController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Get(Guid id)
        {

            var p = _context._addresses.Find(id);

            var mapProj = _mapper.Map<AddressDto>(p);

            return Ok(mapProj);
        }


        // GET api/<ProjectController>/5
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Post(AddressDto addressDto)
        {

            var p = addressDto.ToModelStock();

            var mapProj = _mapper.Map<AddressDto>(p);

            return Ok(mapProj);
        }


        // GET api/<ProjectController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Put(MarketDto marketDto, int id)
        {


            var p = _context._addresses.Find(id);

           

            var mapProj = _mapper.Map<AddressDto>(p);

            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        public ActionResult<AddressDto> Delete(Guid id)
        {
            var p = _context._addresses.Find(id);
            if (p != null)
                _context._addresses.Remove(p);
            else
                return NotFound();

            var mapProj = _mapper.Map<AddressDto>(p);
            return Ok(mapProj);
        }
    }
}
