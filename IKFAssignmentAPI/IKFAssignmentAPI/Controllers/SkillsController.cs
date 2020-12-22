using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IKFAssignmentAPI.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Http.Cors;

namespace IKFAssignmentAPI.Controllers
{
    //[EnableCors(origins: "https://localhost:44360", headers: "*", methods: "*")]
    public class SkillsController : ApiController
    {
        private UserDBContext dbContext = new UserDBContext();
        [HttpGet]
        public async Task<IHttpActionResult> GetSkills()
        {
            IEnumerable<Skill> skills = await dbContext.Skills.ToListAsync();
            return Ok(skills);
        }
    }
}