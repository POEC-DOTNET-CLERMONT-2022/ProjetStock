using ApiApplication.Controllers.Services;
using ApiApplication.Helpers;
using ApiApplication.Interface;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Service.Interfaces;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using ProjectStockDTOS;
using ProjectStockLibrary;
using ProjectStockPatternsLibrary;

using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplicationProjectStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly APIContext _context;

        private  readonly IUserService _userService;

        private IPasswordHasherService _userPasswordHasher { get; }

        public UserController(IMapper mapper, APIContext context, IUserService userService)
        {
            _mapper = mapper;
            _context = context;
            _userPasswordHasher = new PasswordHasherService();
            _userService = userService;

        }




        //// GET api/<ProjectController>/GetAll
        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
           var p = _context._users.ToList();
           if (p == null)
               return NotFound();
           else
               return Ok(p);

        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {

            model._password = _userPasswordHasher.GetPasswordHasher(model._password);
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
    
            return Ok(response);
        }
        

        [HttpPost("register")]
        public IActionResult Register(CreateResult create)
        {
            Client _client = new Client();

            var _pass =_userPasswordHasher.GetPasswordHasher(create._password); 
            _client._email = create._email;
            _client._password = _pass;
            _client._lastName = create._lastName;
            _client._firstName = create._firstName;
            try
            {
                _context._users.Add(_client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            _context.SaveChanges();
            return Ok(new { message = $"Created user { _client._firstName}  { _client._lastName} with email { _client._email}" });        }

        

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            try
            {
                //Find authorization in headers
                var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var p = _context._users.Where(x => x._token == token);


                Client client = null;

                foreach (var user in p)
                {
                    if(user._token == token)
                        client = user;
                }

                if (client == null)
                    return BadRequest(new { message = "No connected user" });
              
                else
                {
                    client.setToken("");
                    client.setExpireDate(DateTime.Now);
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

       
<<<<<<< HEAD
=======
            if (p == null)
                return NotFound();
            else
                return Ok(p);
        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Get([FromQuery] string email)
        {
            var p = _context._users.Where(x => x._email == email);
         


>>>>>>> f299a31ae1595ef19471a46b84a8fb59aa5b88d0
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
            if (p == null)
                return BadRequest();
            _context._users.Add(p);

            _context.SaveChanges();
            return Ok();
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Put(UserDto userDto)
        {


            var p = _context._users.Find(userDto._id);
            if (p == null)
                return BadRequest();
            p._siret = userDto._siret;
            p._phone = userDto._phone;
            p._lastName = userDto._lastName;
            p._firstName = userDto._firstName;
            p._email = userDto._email;
            p._phone = userDto._phone;
            p._password = userDto._password;
           

        
            _context._users.Update(p);
            _context.SaveChanges();
            return Ok(p);
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

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public ActionResult<UserDto> DeleteById(Guid id)
        {
            var p = _context._users.Find(id);
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
