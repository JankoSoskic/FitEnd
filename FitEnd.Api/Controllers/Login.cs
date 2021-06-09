using FitEnd.Api.Core;
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
    public class Login : ControllerBase
    {
        private readonly JwtAction JwtMenager;

        public Login(JwtAction jwtMenager)
        {
            this.JwtMenager = jwtMenager;
        }

        // POST api/<Login>
        [HttpPost]
        public IActionResult Post([FromBody] LoginDto dto)
        {
            var token = this.JwtMenager.PraviToken(dto.Username,dto.Password);
            return Ok(new {token = token });
        }
    }
}
