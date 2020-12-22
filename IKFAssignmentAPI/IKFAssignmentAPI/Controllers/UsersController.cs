using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IKFAssignmentAPI.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using System.Web.Http.Cors;

namespace IKFAssignmentAPI.Controllers
{
    
    //[EnableCors(origins: "/*http://localhost:4200", headers: "", methods: "*")]
    public class UsersController : ApiController
    {
        private UserDBContext dbContext = new UserDBContext();

        [HttpGet]
        public async Task<IHttpActionResult> GetUsers()
        {
            IEnumerable<User> users = await dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            User user = await dbContext.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
                
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }



        [HttpPost]
        public async Task<IHttpActionResult> AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(user.Skill);
            }

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPatch]
        public async Task<IHttpActionResult> EditUser(int id, [FromBody] JsonPatchDocument<User> user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User userFromDb = await dbContext.Users.Where(u => u.UserId == id).FirstOrDefaultAsync(); 

            if (userFromDb == null)
            {
                return NotFound();
            }

            user.ApplyTo(userFromDb);

            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Users.Where(u => u.UserId == id).FirstOrDefaultAsync());
        }

        [HttpPut]
        public async Task<IHttpActionResult> EditUserbyPut(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User userFromDb = await dbContext.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();

            if (userFromDb == null)
            {
                return NotFound();
            }

            userFromDb.Name = user.Name;
            userFromDb.DOB = user.DOB;
            userFromDb.Designation = user.Designation;
            userFromDb.Skill = user.Skill;

            await dbContext.SaveChangesAsync();

            return Ok(await dbContext.Users.Where(u => u.UserId == id).FirstOrDefaultAsync());
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User userFromDb = await dbContext.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();

            if (userFromDb == null)
            {
                return NotFound();
            }

            dbContext.Users.Remove(userFromDb);
            await dbContext.SaveChangesAsync();
            
            return Ok();
        }
    }
}