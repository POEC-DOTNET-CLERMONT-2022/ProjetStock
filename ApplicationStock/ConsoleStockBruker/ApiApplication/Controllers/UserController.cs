using ApiApplication.Helpers;
using ApiApplication.Interface;
using ApiApplication.Model;
using ApiApplication.Models;
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
    public class UserController : ControllerBase
    {
        private IMapper _mapper;

        private APIContext _context { get; }

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


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            try
            {
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var p = _context._users.Where(x => x._token == token);


                Client client = null;

                foreach (var user in p)
                {
                    if(user._token == token)
                    {
                        client = user;
                    }
                
                }

                if (client == null)
                    return BadRequest(new { message = "No connected user" });
                else
                {
                    client.setToken("");
                    _context._users.Update(client);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok(new { message = "Deconnected" });
        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Get([FromQuery] Guid id)
        {

            var p = _context._users.Find(id);

            var mapProj = _mapper.Map<UserDto>(p);

            if (p == null)
                return NotFound();
            else
                return Ok(p);
        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Post(UserDto userDto)
        {

            var p = userDto.ToModel();
            try
            {


                foreach (var _address in p._addresses)
                {
                   _context._addresses.Add(_address);
                   _context.SaveChanges();

                }


                _context._users.Add(p);
               
              
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            _context.SaveChanges();
            return Ok(p);
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Put(UserDto userDto)
        {


            var p = _context._users.Find(userDto._id);

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
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public ActionResult<UserDto> Delete(DeleteClass delete)
        {
            var p = _context._users.Find(delete._id);
            if (p != null)
            {
                _context._users.Remove(p);
                _context.SaveChanges();
            }
            
            else
                return NotFound();

            return Ok();
        }
    }
}
