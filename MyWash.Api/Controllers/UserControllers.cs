using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyWash.Infra.Repositories;
using MyWash.Model.Entity;

namespace MyWash.Api.Controllers
{
    [Route("v1/api/users")]
    public class UserControllers : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserControllers(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<User>> getAllUsers()
        {
            var users = _userRepository.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user != null)
                return Ok(user);
            else
                return NotFound();                
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            _userRepository.Create(user);
            _userRepository.saveChanges();

            return Created("", user);
        }
    }
}