#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCarsAPI.CarAPI.Core.Interfaces.Services;
using MyCarsAPI.Models;

namespace MyCarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET ALL: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            var user = await _userService.GetAll();

            if (user != null)
                return Ok(user);
            else
                return BadRequest("No users!");


        }

        // GET by ID: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {

            var user = await _userService.GetById(id);

            if (user != null)
                return Ok(user);
            else
                return BadRequest("No users!");


        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            try
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }
                await _userService.UpdateUser(user);
                _userService.CommitAll();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(AddUserRequest user)
        {
            try
            {
                var resp = await _userService.AddUser(user);
                _userService.CommitAll();

                if (resp != null)
                    return Ok(resp);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var resp = _userService.DeleteUser(id);
                _userService.CommitAll();
                if (resp)
                    return Ok("User deleted");
                else
                    return BadRequest();

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

    }
}
