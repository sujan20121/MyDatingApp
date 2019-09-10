using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using DatingApp.API.Models;
using DatingApp.API.Dtos;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository repo)
        {
            _authRepository = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _authRepository.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("Username Already Exists");
            }

            var userToCreate = new User {

                Username = userForRegisterDto.Username,

            };

            var createdUser = await _authRepository.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}