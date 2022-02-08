
using ApiApplication.Helpers;
using ApiApplication.Interface;
using ApiApplication.Model;
using ApiApplication.Models;
using ApiApplication.Profil.Repository.Interfaces;
using ApiApplication.Service.ApiApplication.Controllers.Services;
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


        private readonly IGenericRepository<Client> genericRepository;

        public UserController(IMapper mapper, APIContext context, IUserService userService, IGenericRepository<Client> genericRepository)
        {
            _mapper = mapper;
            _context = context;
            _userPasswordHasher = new PasswordHasherService();
            _userService = userService;
            this.genericRepository = genericRepository;
        }




        //// GET api/<ProjectController>/GetAll
      
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserDto>> GetAll()
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


        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {

            model._password = _userPasswordHasher.GetPasswordHasher(model._password);
            var response = _userService.Authenticate(model);


            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
    


            return Ok(response);
        }


        [Authorize]
        [HttpPost("user_auth")]
        public IActionResult GetUser(AuthenticateRequest model)
        {
            var p = _context._users.Where(x => x._email == model._email);
            return Ok(p);
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
            _client._token = " ";
            _client._expireToken = DateTime.Now ;
            
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

            try
            {
                var p = genericRepository.GetById(id);


                if (p == null)
                    return NotFound();
                else
                    return Ok(p);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
           
        }


        // GET api/<ProjectController>/5
        [Authorize]
        [HttpGet("email")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Get([FromQuery] string email)
        {
            var p = _context._users.Where(x => x._email == email);

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
            try
            {
                var p = userDto.ToModel();
                p._password = _userPasswordHasher.GetPasswordHasher(p._password);
                if (p == null)
                    return BadRequest();
                genericRepository.Add(p);

                _context.SaveChanges();
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<ProjectController>/5
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> Put(UserDto userDto)
        {

            try
            {

                var p = genericRepository.GetById(userDto.Id);
                if (p == null)
                    return BadRequest();
                p._siret = userDto._siret;
                p._phone = userDto._phone;
                p._lastName = userDto._lastName;
                p._firstName = userDto._firstName;
                p._email = userDto._email;
                p._phone = userDto._phone;
                p._password = _userPasswordHasher.GetPasswordHasher(userDto._password); 



                _context._users.Update(p);
                _context.SaveChanges();
                return Ok(p);


            }catch(Exception ex)
            {
                return BadRequest();
            }

        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public ActionResult<UserDto> Delete(DeleteClass delete)
        {
            try
            {

                var p = genericRepository.GetById(delete.Id);
                if (p != null)
                {
                    genericRepository.Delete(p);
                }

                else
                    return NotFound();

                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // DELETE api/<ProjectController>/5
        [Authorize]
        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        public ActionResult<UserDto> DeleteById(Guid id)
        {
            try
            {

                var p = genericRepository.GetById(id);
                if (p != null)
                {
                    _context._users.Remove(p);
                    _context.SaveChanges();
                }

                else
                    return NotFound();

                return Ok();
            }catch (Exception ex)
            {
                return NotFound();
            }
           
        }
    }
}
