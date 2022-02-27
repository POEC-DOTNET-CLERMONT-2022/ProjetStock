using ApiApplication.Helpers;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository;
using ApiApplication.Profil.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Mvc;
using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary;
using System.Net;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly APIContext _context;

        private readonly IGenericRepository<Stock> genericRepository;
        public StocksController(IMapper mapper, APIContext context,IGenericRepository<Stock> generic)
        {
            _mapper = mapper;
            _context = context;
            genericRepository = generic;

        }


        //// GET api/<ProjectController>/GetAll

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<StockDto>> GetAll()
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
                return BadRequest(ex);
            }
           

        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Get([FromQuery] Guid id)
        {
            try { 
               var p = genericRepository.GetById(id); 

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
            var p = _mapper.Map<Stock>(stockDto);
            try
            {
              
               
             
    
                genericRepository.Add(p);
            
                return Ok(p);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StockDto> Put(StockDto stockDto)
        {

            try{
            
                var p = genericRepository.GetById(stockDto.Id);
                if (p == null)
                    return BadRequest();

                p._entrepriseName = stockDto._entrepriseName;
                p._value = stockDto._value;
                p._name = stockDto._name;


                var mapProj = _mapper.Map<StockDto>(p);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        public ActionResult<StockDto> Delete(DeleteClass delete)
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
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StockDto))]
        public ActionResult<StockDto> DeleteById(Guid id)
        {

            try
            {
              
                var p = genericRepository.GetById(id);
                if (p != null)
                {
                    _context._stocks.Remove(p);
                    _context.SaveChanges();
                    return Ok(p);

                }

                else
                    return NotFound();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            


        }
    }
}
