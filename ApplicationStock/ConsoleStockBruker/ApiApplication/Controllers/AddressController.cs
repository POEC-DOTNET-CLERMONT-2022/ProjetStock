using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
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
        private readonly IMapper _mapper;

        private readonly APIContext _context;
        public AddressController(IMapper mapper, APIContext context)
        {
            //TODO : utiliser les repo plutôt que le DBContext directement
            _mapper = mapper;
            _context = context;
        }



        [Authorize]
        //TODO : attention au règle des URL => https://docs.microsoft.com/fr-fr/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio
        [HttpGet("all")]


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<AddressDto>> GetAll()
        {
            //TODO: il faut gérer les exceptions !
            //TODO: il faut aussi logger les erreurs ! 
            var p = _context._addresses.ToList();
            if (p == null)
                return NotFound();
            else
                return Ok(p);

        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Get([FromQuery] Guid id)
        {
            var p = _context._addresses.Find(id);
            if ( p == null)
                  return NotFound();
               else
                  return Ok(p);
           
        }


        // GET api/<ProjectController>/5
       
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Post(AddressDto addressDto)
        {
            try
             {
                var p = addressDto.ToModelStock();

                var mapProj = _mapper.Map<AddressDto>(p);
       
                if (p == null)
                    return NotFound();
                else
                {

                    _context._addresses.Add(p);
                    _context.SaveChanges();
                }
                 
                    return Ok(mapProj);

            }
            catch (Exception ex)
            {
                //TODO : logger ici 
                return BadRequest(ex.Message);
            }
        }


        // GET api/<ProjectController>/5
       // [Authorize]
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Put(AddressDto addressDto)
        {
            var p = _context._addresses.Find(addressDto._id);
            if(p == null)
            {
                return BadRequest();
            }

            p._address_line_1 = addressDto._address_line_1;
            p._address_line_2 = addressDto._address_line_2;
            p._city = addressDto._city;
            p._codePostal = addressDto._codePostal;
            p._country = addressDto._country; 
            var mapProj = _mapper.Map<AddressDto>(p);
            //TODO: on fait soit le mapping à la main ou le mapping via automapper 

            _context._addresses.Update(p);
            _context.SaveChanges();

            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        public ActionResult<AddressDto> Delete(DeleteClass delete)
        {
            var p = _context._addresses.Find(delete._id);

            if (p != null)
            {
                _context._addresses.Remove(p);
               //TODO: save ici 
            }

            else
                return NotFound();

             _context.SaveChanges();
            return Ok(p);
        }
        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        public ActionResult<AddressDto> DeleteById(Guid id)
        {
            var p = _context._addresses.Find(id);

            if (p != null)
            {
                _context._addresses.Remove(p);

            }

            else
                return NotFound();

            _context.SaveChanges();
            return Ok(p);
        }
    }
}
