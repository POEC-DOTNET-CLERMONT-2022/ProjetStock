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

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly APIContext _context;
        private readonly IGenericRepository<Notification> genericRepository;
        public NotificationController(IMapper mapper, APIContext context, IGenericRepository<Notification> genericRepository)
        {
            _mapper = mapper;
            _context = context;
            this.genericRepository = genericRepository;

        }

        //// GET api/<ProjectController>/GetAll
        
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<NotificationDto>> GetAll()
        {
            var p = genericRepository.GetAll();
            if (p == null)
                return NotFound();
            else
                return Ok(p);

        }


        // GET api/<ProjectController>/5
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<NotificationDto> Get([FromQuery] Guid id)
        {

            var p = genericRepository.GetById(id);

            var mapProj = _mapper.Map<NotificationDto>(p);

            if (mapProj == null)
                return NotFound();
            else
            {
     
                return Ok(mapProj);
            }
                
        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<NotificationDto> Post(NotificationDto notificationDto)
        {
            try
            {
                var p = _mapper.Map<Notification>(notificationDto);

                

                if (p == null)
                    return NotFound();
                else
                {
                    genericRepository.Add(p);
                    return Ok(notificationDto);
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
        public ActionResult<NotificationDto> Put(NotificationDto notificationDto)
        {


            var p = genericRepository.GetById(notificationDto.Id);
            if (p == null)
                return BadRequest();
            p._textRappel = notificationDto.textRappel;
            p._sendAt = notificationDto.sendAt;
            p.ClientId = notificationDto.ClientId;
            

            var mapProj = _mapper.Map<NotificationDto>(p);
            genericRepository.Update(p);
            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        public ActionResult<NotificationDto> Delete(DeleteClass delete)
        {
            var p = genericRepository.GetById(delete.Id);
            if (p != null)
            {
                genericRepository.Delete(p);


            }
            else
                return NotFound();

            return Ok(p);
        }

        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        public ActionResult<NotificationDto> DeleteByGuid(Guid id)
        {
            var p = genericRepository.GetById(id);
            if (p != null)
            {
                genericRepository.Delete(p);


            }
            else
                return NotFound();

            return Ok(p);
        }
    }
}
