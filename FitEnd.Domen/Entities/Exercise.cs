using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class Exercise : Entity
    {
        public string Naziv { get; set; }
        public double AverageCalLost { get; set; }
        public string Description { get; set; }
        public int IdType { get; set; }

        public ExerciseType ExerciseType { get; set; }
        public ICollection<ExercisePictures> ExercisePics { get; set; } = new HashSet<ExercisePictures>();
        public ICollection<PlanDetail> PlanDetails { get; set; } = new HashSet<PlanDetail>();
    }
}
