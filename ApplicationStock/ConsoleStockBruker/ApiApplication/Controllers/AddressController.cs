using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository;
using ApiApplication.Profil.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockLibrary;
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

        private readonly IGenericRepository<Address> genericRepository;
        public AddressController(IMapper mapper, APIContext context,IGenericRepository< Address> generic)
        {
            //TODO : utiliser les repo plutôt que le DBContext directement
            _mapper = mapper;
            _context = context;
            genericRepository = generic;



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

            try
            {
                var p = genericRepository.GetAll();
                if (p == null)
                    return NotFound();
                else
                    return Ok(p);

            }catch (Exception ex)
            {
                return NotFound();
            }
            

        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AddressDto> Get([FromQuery] Guid id)
        {

            var p = genericRepository.GetById(id);
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

                    genericRepository.Add(p);

                    return Ok(mapProj);
                }
                 
                

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
            try
            {
                var p = _context._addresses.Find(addressDto.Id);
                if (p == null)
                {
                    return BadRequest();
                }

                p._address_line_1 = addressDto._address_line_1;
                p._address_line_2 = addressDto._address_line_2;
                p._city = addressDto._city;
                p._codePostal = addressDto._codePostal;
                p._country = addressDto._country;

                genericRepository.Update(p);
            
                _context.SaveChanges();

                return Ok(p);
            }


            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

            //TODO: on fait soit le mapping à la main ou le mapping via automapper 

            

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        public ActionResult<AddressDto> Delete(DeleteClass delete)
        {
            try
            {

                var p = _context._addresses.Find(delete.Id);

                if (p != null)
                {
                    genericRepository.Delete(p);
                }

                else
                    return NotFound();


                return Ok(p);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }
        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddressDto))]
        public ActionResult<AddressDto> DeleteById(Guid id)
        {
            try
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
            catch(Exception ex)
            
            {
                return BadRequest(ex.Message);
            }
          

        }
    }
}
