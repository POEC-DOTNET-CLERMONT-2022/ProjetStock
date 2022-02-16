using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary;



namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cryptocontroller : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly APIContext _context;

        private readonly IGenericRepository<Crypto> genericRepository;

        public Cryptocontroller (IMapper mapper , APIContext context, IGenericRepository<Crypto> generic)

        {
            _mapper = mapper;
            _context = context;
            genericRepository = generic;

        }

        //// GET api/<ProjectController>/GetAll

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CryptoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CryptoDto>> GetAll()
        {

            try
            {
                var p = genericRepository.GetAll();
                if (p == null)
                    return NotFound();
                else
                    return Ok(p);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }

        //// GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CryptoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CryptoDto> Get([FromQuery] Guid id)
        {
            try
            {
                var p = genericRepository.GetById(id);

                var mapProj = _mapper.Map<CryptoDto>(p);

                if (mapProj == null)
                    return NotFound();

                return Ok(mapProj);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          

        }


        // PUT api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CryptoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<CryptoDto> Put(CryptoDto cryptoDto)
        {

            try
            {

                var p = genericRepository.GetById(cryptoDto.Id);
                if (p == null)
                    return BadRequest();

                p._name = cryptoDto._name;
                p._value = cryptoDto._value;
                //p._listMarket = cryptoDto._listMarker;
                //p._listClient = cryptoDto._listClient;


                var mapProj = _mapper.Map<CryptoDto>(p);
                genericRepository.Update(p);
                return Ok(mapProj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CryptoDto> Delete(DeleteClass delete)
        {
            try
            {
                var p = genericRepository.GetById(delete.Id);
                if (p != null)
                {
                    genericRepository.Delete(p);
                    return Ok(p);

                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CryptoDto))]
        public ActionResult<CryptoDto> DeleteById(Guid id)
        {

            try
            {

                var p = genericRepository.GetById(id);
                if (p != null)
                {
                    _context._cryptos.Remove(p);
                    _context.SaveChanges();
                    return Ok(p);

                }

                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }





    }
}