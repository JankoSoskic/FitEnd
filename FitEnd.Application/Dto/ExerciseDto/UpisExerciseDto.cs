using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto
{
    public class UpisExerciseDto : DtoAbstract
    {
        public string Naziv { get; set; }
        public double AverageCalLost { get; set; }
        public string Description { get; set; }
        public int IdTypeOf { get; set; }
        public IEnumerable<IFormFile> Slike { get; set; }
    }
}
