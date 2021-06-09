using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class PlanDetail : Entity
    {
        public int IdPlan { get; set; }
        public int IdExercise { get; set; }
        public DateTime WhenWorking { get; set; }
        public int Repetitions { get; set; }

        public UserPlan PlanUser { get; set; }
        public Exercise Exercise { get; set; }
    }
}
