using ApiApplication.Interface;
using ApiApplication.Model;
using ApiApplication.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProjectStockDTOS;
using ProjectStockPatternsLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;

        private APIContext _context;

        private IUserService _userService;

        public UserController(IMapper mapper, APIContext context, IUserService userService)
        {
            _mapper = mapper;
            _context = context;
            _userService = userService;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Get(Guid id)
        {

            var p = _context._stocks.First();

            var mapProj = _mapper.Map<UserDto>(p);

            if (mapProj == null)
                return NotFound();
            else
                return Ok(mapProj);
        }


        // GET api/<ProjectController>/5
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Post(UserDto userDto)
        {
            try
            {
                var p = userDto.ToModel();

                var mapProj = _mapper.Map<UserDto>(p);
                foreach (var _address in p._addresses)
                {
                    _context._addresses.Add(_address);
                    _context.SaveChanges();

                }


                _context._users.Add(p);
                _context.SaveChanges();
                return Ok(mapProj);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
  
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Put(UserDto userDto, Guid id)
        {


            var p = _context._users.Find(id);

            p._siret = userDto._siret;
            p._phone = userDto._phone;
            p._lastName = userDto._lastName;
            p._firstName = userDto._firstName;
            p._email = userDto._email;
            p._phone = userDto._phone;
            p._password = userDto._password;
           

            var mapProj = _mapper.Map<UserDto>(p);
            _context._users.Update(p);
            _context.SaveChanges();
            return Ok(mapProj);
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public ActionResult<UserDto> Delete(Guid id)
        {
            var p = _context._users.Find(id);
            if (p != null)
            {
                _context._users.Remove(p);
                _context.SaveChanges();
            }
            
            else
                return NotFound();

            var mapProj = _mapper.Map<UserDto>(p);
            return Ok(mapProj);
        }
    }
}
