
using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUsersService _usersService;
        private IMapper _mapper;
        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            User user = await _usersService.GetUserById(id);
            UserDto userDto = _mapper.Map<User, UserDto>(user);
            return user == null ? NotFound() :userDto;
                   
        }
        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<UserDto>>Post([FromBody] User user)
        {
             User userCreated=await _usersService.CreataeUser(user);
            UserDto userDto = _mapper.Map<User, UserDto>(userCreated);
            return userDto;
        }
        //POST api/<LoginController>
        [HttpPost]
        [Route("signIn")]
       public async Task<ActionResult<UserDto>> SignIn([FromBody] LoginDto logInUser)
       {
            User user = _mapper.Map<LoginDto, User>(logInUser);
            User createdUser =await _usersService.SignIN(user);
            UserDto userDto= _mapper.Map<User, UserDto>(createdUser);
            if(createdUser == null) return NotFound();
            else
                return Ok(userDto);

       }
      //  PUT api/<LoginController>
       
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await _usersService.UpdateUser(id, userToUpdate);
        }
    }
}
