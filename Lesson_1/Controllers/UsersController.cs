﻿
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

        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET: api/<LoginController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return usersService.GetUserById(id);
        //}

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await usersService.GetUserById(id);
            return user == null ? NotFound() :user;
                   
        }
        //[HttpGet]
        //public int GetPasswordStrength([FromQuery] string password)
        //{
        //    var result = Zxcvbn.Core.EvaluatePassword(password);
        //    return result.Score;

        //}


        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<User> >Post([FromBody] User user)
        {

            return await usersService.CreataeUser(user); ;


        }
        //POST api/<LoginController>
        [HttpPost]
        [Route("signIn")]
       // public ActionResult<User> Post1([FromBody] string password,string email)
       public async Task<ActionResult<User>> SignIn([FromBody] User data)
        {
            User user =await usersService.SignIN(data);
            if(user == null) return NotFound();
            else
                return Ok(user);
            //return user == null ? NotFound() : Ok(user);


        }
      //  PUT api/<LoginController>
       
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await usersService.UpdateUser(id, userToUpdate);
           


        }

        // DELETE api/<LoginController>/5
        //[HttpDelete("{id}")]
        //public async Task Delete(int id)
        //{
        //    //return nameof(GetUserById, user.Id, user)
        //}
    }
}
