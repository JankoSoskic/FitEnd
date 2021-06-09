using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto
{
    public class ExerciseDto : DtoAbstract
    {
        public int IdExercise { get; set; }
        public string Name { get; set; }
        public double AverageCalLost { get; set; }
        public string? Description { get; set; }
        public string ExerciseType { get; set; }
        public IEnumerable<string> PicSrcs { get; set; }
        public IEnumerable<string> Alts { get; set; }

    }
}
