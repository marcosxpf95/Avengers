using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWash.Model.Entity;
using MyWash.Model.Repositories;

namespace MyWash.Api.Controllers
{
    [Route("v1/api/users")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        //dependency injection
        public UserControllers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize("admin")]
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            return Ok(users);
        }


        [HttpGet("{id}")]
        [Authorize("admin")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user != null)
                return Ok(user);
            else
                return NotFound();                
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<User> CreateUser(User user)
        {
            _userRepository.Create(user);
            _userRepository.SaveChanges();

            return Created("", user);
        }

        [HttpDelete("{id}")]
        [Authorize("admin")]
        public ActionResult<User> DeleteUser(int id)
        {
            var result = _userRepository.GetUserById(id);

            if (result != null)
            {
                _userRepository.Delete(result);
                _userRepository.SaveChanges();
                return Ok(result);
            }
            else
                return NotFound();
        }

        [HttpPut]
        [Authorize("admin")]
        public ActionResult<User> AlterUser(User user)
        {
            var result = _userRepository.GetUserById(user.Id);

            if (result != null)
            {
                _userRepository.Update(user);
                _userRepository.SaveChanges();
                return Ok(user);
            }   
            else
                return NotFound();
        }
    }
}