using ApiSqlAzure.Models;
using ApiSqlAzure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
       public readonly IUsersService _usersService;

       public UsersController(IUsersService usersService)=> _usersService = usersService;

       [HttpGet]
       public async Task<IActionResult> GetAll()
        {
            var users = await _usersService.GetAllAsync();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(String id)
        {
            var user = await _usersService.GetByIdAsync(id);
            if(user is null)
                return NotFound();
                
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Users users)
        {
            var created = await _usersService.CreateAsync(users);
            return CreatedAtAction(nameof(GetById), new {id = created.id}, created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {

            var user = await _usersService.DeleteAsync(id);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> updateAsync([FromBody] Users users)
        {
            var updated = await _usersService.UpdateAsync(users);
            return Ok(updated);
        }


    }
}