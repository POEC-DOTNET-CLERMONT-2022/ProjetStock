using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockPatternsLibrary;



namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cryptocontroller : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly APIContext _context;

        public Cryptocontroller (IMapper mapper , APIContext context)
        {
            _mapper = mapper;
            _context = context;

        }

        //// GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CryptoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CryptoDto> Get([FromQuery] Guid id)
        {
            var p = _context._cryptos.Find(id);


            if (p == null)
                return NotFound();

            return Ok(p);

        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CryptoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CryptoDto> Post(CryptoDto  cryptoDto)
        {
            try
            {
                var p = cryptoDto.ToModel();

                if (p == null)
                    return NotFound();
                else
                {
                    _context._cryptos.Add(p);
                    _context.SaveChanges();
                    return Ok(p);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CryptoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CryptoDto> Put(CryptoDto cryptoDto)
        {

           
            var p = _context._cryptos.Find(cryptoDto._id);
            if (p == null)
                return BadRequest();
           
            p._name = cryptoDto._name;
            p._value = cryptoDto._value;


           

            _context._cryptos.Update(p);
            _context.SaveChanges();

            return Ok(p);
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarketDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CryptoDto> Delete(DeleteClass delete)
        {
            var p = _context._cryptos.Find(delete._id);
            if(p != null)
            {
                _context._cryptos.Remove(p);
          
            }
           
            else
                return NotFound();
            return Ok(p);
        }
       


    }
}