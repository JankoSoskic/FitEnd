using FitEnd.Application;
using FitEnd.Application.Commands.UserPlanCommands;
using FitEnd.Application.Dto.UserPlanDto;
using FitEnd.Application.Queries.UserPlanQueries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlans : ControllerBase
    {
        private readonly Executor executor;

        public UserPlans(Executor executor)
        {
            this.executor = executor;
        }

        // GET: api/<UserPlans>
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IShowUserPlans akcija)
        {
            return Ok(this.executor.IzvrsiQuery(akcija,id));
        }

        [HttpPatch("UpdateWeight")]
        public IActionResult UpdateWeight([FromBody] UserNewWeightDto dto,[FromServices] INewUserWeight action)
        {
            this.executor.IzvrsiKomandu(action, dto);
            return NoContent();
        }

        // POST api/<UserPlans>
        [HttpPost]
        public IActionResult Post([FromBody] NewUserPlanDto dto,[FromServices] ICreateNewUserPlan action)
        {
            this.executor.IzvrsiKomandu(action, dto);
            return NoContent();
        }

        // DELETE api/<UserPlans>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteUserPlan action)
        {
            this.executor.IzvrsiKomandu(action,id);
            return NoContent();
        }
    }
}
