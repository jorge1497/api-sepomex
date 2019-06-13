using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using api_sepomex.Services;
using api_sepomex.Models;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers
{
    [Authorize("Bearer")]
    [ApiController]
    [Route("[controller]")]
    [EnableCors("SepomexPolicy")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}