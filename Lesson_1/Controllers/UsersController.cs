
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private UsersService usersService = new UsersService();
        // GET: api/<LoginController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return usersService.GetUserById(id);
        //}

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user = usersService.GetUserById(id);
            return user == null ? NotFound() :user;
                   
        }
        [HttpGet]
        public int GetPasswordStrength([FromQuery] string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;

        }


        // POST api/<LoginController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {

            return usersService.CreataeUser(user); ;


        }
        //POST api/<LoginController>
        [HttpPost]
        [Route("signIn")]
       // public ActionResult<User> Post1([FromBody] string password,string email)
       public ActionResult<User> SignIn([FromBody] User data)
        {
            User user = usersService.SignIN(data);
            if(user == null) return NotFound();
            else
                return Ok(user);
            //return user == null ? NotFound() : Ok(user);


        }
      //  PUT api/<LoginController>
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            usersService.UpdateUser(id, userToUpdate);
           


        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //return nameof(GetUserById, user.UserId, user)
        }
    }
}
