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
    public class NotificationController : ControllerBase
    {
        private IMapper _mapper;

        private APIContext _context;
        public NotificationController(IMapper mapper, APIContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //// GET api/<ProjectController>/GetAll
        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<NotificationDto>> GetAll()
        {
            var p = _context._notifs.ToList();
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

            var p = _context._notifs.Find(id); 

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
                var p = notificationDto.ToModelStock();

                var mapProj = _mapper.Map<NotificationDto>(p);

                if (mapProj == null)
                    return NotFound();
                else
                {
                    _context._notifs.Add(p);
                    _context.SaveChanges();
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
        public ActionResult<NotificationDto> Put(NotificationDto notificationDto)
        {


            var p = _context._notifs.Find(notificationDto._id);

            p._textRappel = notificationDto.textRappel;
            p._sendAt = p._sendAt;

            var mapProj = _mapper.Map<NotificationDto>(p);
            _context._notifs.Update(p);
            _context.SaveChanges();
            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NotificationDto))]
        public ActionResult<NotificationDto> Delete(DeleteClass delete)
        {
            var p = _context._notifs.Find(delete._id);
            if (p != null)
            {
                _context._notifs.Remove(p);
                _context.SaveChanges();

            }    
            else
                return NotFound();

            return Ok(p);
        }
    }
}
