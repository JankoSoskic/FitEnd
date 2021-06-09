using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto
{
    public class UpdateExerciseDto : DtoAbstract
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double AverageCalLost { get; set; }
        public string Description { get; set; }
        public int IdTypeOf { get; set; }
        public IEnumerable<IFormFile> Slike { get; set; }
    }
}
