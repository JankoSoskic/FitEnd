using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.ExerciseTypeDto
{
    public class UpdateExerciseTypeDto : DtoAbstract
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

    }
}
