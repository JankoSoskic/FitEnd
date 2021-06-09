using FitEnd.Application;
using FitEnd.Application.Commands.UsersCommand;
using FitEnd.Application.Dto.UsersDto;
using FitEnd.Application.Queries;
using FitEnd.Application.Queries.UserQueries;
using Microsoft.AspNetCore.Authorization;
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
    public class Admin : ControllerBase
    {
        private readonly Executor executor;

        public Admin(Executor executor)
        {
            this.executor = executor;
        }

        [HttpGet("DohvatiRoles")]
        public IActionResult DohvatiRoles([FromServices] IRolesQuery action)
        {
            return Ok(this.executor.IzvrsiQuery(action,new object()));
        }
        // GET: api/<Admin>
        [HttpGet("{nekoIme?}")]
        public IActionResult Get(string nekoIme, [FromServices] IUserQuery action)
        {
            return Ok(this.executor.IzvrsiQuery(action, nekoIme));
        }

        [HttpGet("DohvatiDesavanja/{trazi?}")]
        public IActionResult DesavanjaNaAplikaciji(string trazi,[FromServices] ICitanjeIzLogFajla akcija)
        {
            return Ok(this.executor.IzvrsiQuery(akcija,trazi));
        }

        // PUT api/<Admin>/5
        [HttpPatch("{id}/{idUloge}")]
        public IActionResult promenaRole(int id, int idUloge,[FromServices] IChangeUserRole action)
        {
            var dto = new ChangeUserRoleDto()
            {
                IdKorisnika = id,
                NoviRole = idUloge
            };
            this.executor.IzvrsiKomandu(action, dto);
            return NoContent();
        }

        // DELETE api/<Admin>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteUser action)
        {
            this.executor.IzvrsiKomandu(action, id);
            return NoContent();
        }
    }
}
