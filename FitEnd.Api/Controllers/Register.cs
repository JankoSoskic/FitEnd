using FitEnd.Application;
using FitEnd.Application.Commands.UsersCommand;
using FitEnd.Application.Dto.UserLog_RegDto;
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
    public class Register : ControllerBase
    {

        private readonly Executor executor;

        public Register(Executor executor)
        {
            this.executor = executor;
        }

       
        // POST api/<Register>
        [HttpPost]
        public IActionResult Post([FromBody] UserRegistrationDto dto,[FromServices] IRegisterUser akcija)
        {
            executor.IzvrsiKomandu(akcija,dto);
            return NoContent();
        }

     
    }
}
