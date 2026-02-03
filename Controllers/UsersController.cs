using ApiSqlAzure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSqlAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private UsersContext userContext;

        public UsersController(UsersContext context)
        {
            userContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> Get()
        {
            return userContext.Users.ToList();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Users>> Get(string id)
        {
            var user =  await userContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Users>>> Post([FromBody] Users users)
        {
            userContext.Add(users);

            await userContext.SaveChangesAsync();

            return await userContext.Users.ToListAsync();

        }
        
    }
}