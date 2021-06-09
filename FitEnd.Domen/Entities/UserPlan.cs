using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class UserPlan : Entity
    {
        public int IdUser { get; set; }
        public double WeightGoal { get; set; }
        public DateTime TillWhen { get; set; }

        public User User { get; set; }
        public ICollection<PlanDetail> Details { get; set; } = new HashSet<PlanDetail>();

    }
}
