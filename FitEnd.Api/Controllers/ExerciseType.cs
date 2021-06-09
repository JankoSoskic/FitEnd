using FitEnd.Application;
using FitEnd.Application.Actors;
using FitEnd.Application.Commands;
using FitEnd.Application.Commands.ExerciseTypeCommands;
using FitEnd.Application.Dto;
using FitEnd.Application.Dto.ExerciseTypeDto;
using FitEnd.Application.Queries;
using FitEnd.DataAccess;
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
    public class ExerciseType : ControllerBase
    {
        private readonly Executor executorAkcija;
        

        public ExerciseType(Executor executorAkcija)
        {
            this.executorAkcija = executorAkcija;
           
        }

        // GET: api/<ExerciseType>
        [HttpGet]
        public IActionResult Get([FromServices] IPregledTipova akcija)
        {
            return Ok(this.executorAkcija.IzvrsiQuery(akcija, new object()));
        }

      

        // POST api/<ExerciseType>
        [HttpPost]
        public IActionResult Post([FromBody] NewExerciseTypeDto dto, [FromServices] INewExerciseType action)
        {
            this.executorAkcija.IzvrsiKomandu(action,dto);
            return NoContent();
        }

        // PUT api/<ExerciseType>
        [HttpPut]
        public IActionResult Put([FromBody] UpdateExerciseTypeDto dto,[FromServices] IUpdateExerciseType action)
        {
            this.executorAkcija.IzvrsiKomandu(action, dto);
            return NoContent();
        }

        // DELETE api/<ExerciseType>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteExerciseType action)
        {
            this.executorAkcija.IzvrsiKomandu(action, id);
            return NoContent();
        }
    }
}
