
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class ExercisePictures : Entity
    {
        public int IdExercise { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }

        public Exercise Exercise { get; set; }
    }
}
