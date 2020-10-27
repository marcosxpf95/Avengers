using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWash.Api.Services;
using MyWash.Model.Entity;
using MyWash.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace MyWash.Api.Controllers
{
    [Route("v1/account")]
    public class AccountController : Controller
    {

        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] User model)
        {
            try
            {
                var user = _userRepository.GetUserAuthenticated(model.Name, model.Password);

                if (user == null)
                    return BadRequest(new { message = "Usuário ou senha inválidos" });

                var service = new UserService();
                var userAuthenticated = service.Authenticate(user);

                return Ok(userAuthenticated);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
