using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MyWash.Infra.Repositories;
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
        public ActionResult<List<User>> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
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


        [HttpPut]
        public ActionResult<User> AlterUser(User user)
        {
            var result = _userRepository.GetUserById(user.Id);

            if (result != null)
            {
                _userRepository.Update(user);
                _userRepository.saveChanges();
                return Ok(user);
            }   
            else
                return NotFound();
        }
    }
}