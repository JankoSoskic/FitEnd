using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class ExerciseType : Entity
    {
        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
    }
}
