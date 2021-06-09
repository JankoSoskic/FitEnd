using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitEnd.Application.Dto;
using FitEnd.Application.Searches;
using FitEnd.Implementation.Queries;
using FitEnd.Application.Queries;
using FitEnd.Application;
using AutoMapper;
using FitEnd.Implementation.Validators;
using FitEnd.Implementation.Extensions;
using FluentValidation;
using FitEnd.Application.Commands;
using FitEnd.Application.Queries.ExerciseQueries;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Exercises : ControllerBase
    {
        private readonly Executor executorAkcija;
       

        public Exercises(Executor executorAkcija)
        {
            this.executorAkcija = executorAkcija;
        }
        // GET: api/<Exercises>
        [HttpGet]
        public IActionResult Get([FromBody] VezbaPrazanSearch val,[FromServices] IPregledVezba action)
        {
            return Ok(this.executorAkcija.IzvrsiQuery(action, val));
        }
        
        [HttpGet("searchNaziv/{naziv}")]
        public IActionResult serchPoNazivu(string naziv,[FromServices] IPretragaPoNazivu action)
        {
            return Ok(this.executorAkcija.IzvrsiQuery(action,naziv));
        }
        // GET api/<Exercises>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IPregledVezbePoID action)
        {
            return Ok(this.executorAkcija.IzvrsiQuery(action, id));
        }

        // POST api/<Exercises>
        [HttpPost]
        public IActionResult Post([FromForm] UpisExerciseDto noviExercise,[FromServices] IUpisExercise akcija)
        {
            this.executorAkcija.IzvrsiKomandu(akcija, noviExercise);

            return NoContent();
        }

        // PUT api/<Exercises>
        [HttpPut]
        public IActionResult Put([FromForm] UpdateExerciseDto dto,[FromServices] IUpdateExercise action)
        {
            this.executorAkcija.IzvrsiKomandu(action, dto);
            return NoContent();
        }

        // DELETE api/<Exercises>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IRemoveExercise action)
        {
            this.executorAkcija.IzvrsiKomandu(action, id);
            return NoContent();
        }
    }
}
