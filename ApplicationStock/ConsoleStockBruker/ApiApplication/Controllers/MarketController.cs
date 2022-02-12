using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly APIContext _context;

        private readonly IGenericRepository<Market> genericRepository;


        public MarketController(IMapper mapper, APIContext context, IGenericRepository<Market> marketRepository)
        {
            _mapper = mapper;
            _context = context;
            this.genericRepository = marketRepository;
        }

        //// GET api/<ProjectController>/
   
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<MarketDto>> GetAll()
        {
            try
            {
                var p = genericRepository.GetAll();
                if (p == null)
                    return NotFound();
                else
                    return Ok(p);

            }catch (Exception ex)
            {
                return BadRequest();
            }
          

        }


        // GET api/<ProjectController>/Get
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<MarketDto> Get([FromQuery]Guid id)
        {
            try
            {
                var p = genericRepository.GetById(id);

                if (p == null)
                    return NotFound();

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
            
            
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
                {
                    genericRepository.Add(p);
                    return Ok(mapProj);
                }
                    
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

            try
            {

                var p = genericRepository.GetById(marketDto.Id);
                if (p == null)
                {
                    return BadRequest();
                }

                p._name = marketDto._name;
                p._openingDate = marketDto._openingDate;

                var mapProj = _mapper.Map<MarketDto>(p);

                genericRepository.Update(p);

                return Ok(mapProj);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        public ActionResult<MarketDto> Delete(DeleteClass delete)
        {
            try
            {
                var p = genericRepository.GetById(delete.Id);
                if (p != null)
                {
                    _context._markets.Remove(p);

                }

                else
                    return NotFound();
                return Ok(p);

            }catch (Exception ex)
            {
                return BadRequest();
            }
           
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        public ActionResult<MarketDto> DeleteById(Guid id)
        {

            try
            {
                var p = genericRepository.GetById(id);
                if (p != null)
                {
                    _context._markets.Remove(p);

                }

                else
                    return NotFound();
                return Ok(p);
            }catch(Exception ex)
            {
                return NotFound();
            }
          
        }
    }
}
