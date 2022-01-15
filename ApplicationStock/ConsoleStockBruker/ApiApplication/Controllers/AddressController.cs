using ApiApplication.Helpers;
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

               if (mapProj == null)
                  return NotFound();
               else
                  return Ok(mapProj);
           
        }


        // GET api/<ProjectController>/5
       // [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Post(AddressDto addressDto)
        {
            try
             {
                   var p = addressDto.ToModelStock();

                var mapProj = _mapper.Map<AddressDto>(p);
                _context._addresses.Add(p);
                _context.SaveChanges();
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
       // [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Put(AddressDto addressDto)
        {


            var p = _context._addresses.Find(addressDto._id);
            p._address_line_1 = addressDto._address_line_1;
            p._address_line_2 = addressDto._address_line_2;
            p._city = addressDto._city;
            p._codePostal = addressDto._codePostal;
            p._country = addressDto._country; 
   
           

            var mapProj = _mapper.Map<AddressDto>(p);

            _context._addresses.Update(p);
            _context.SaveChanges();

            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        //[Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        public ActionResult<AddressDto> Delete(Guid id)
        {
            var p = _context._addresses.Find(id);
            if (p != null)
            {
                _context._addresses.Remove(p);
                _context.SaveChanges();
            } 
            else
                return NotFound();

            var mapProj = _mapper.Map<AddressDto>(p);


            return Ok(mapProj);
        }
    }
}
