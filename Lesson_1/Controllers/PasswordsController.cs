using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1_login.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class PasswordsController : ControllerBase
{
    IPasswordsService _passwordsService ;

    public PasswordsController(IPasswordsService passwordsService)
    {
        _passwordsService = passwordsService;
    }

    [HttpPost]
    public ActionResult<int> GetPasswordStrength([FromBody] string password)
    {
            var strength= _passwordsService.GetPasswordStrength(password);
            if (strength < 2)
                return BadRequest("password not strong");
            else
                return strength;

    }

   

   
}
}
