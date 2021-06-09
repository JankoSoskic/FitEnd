using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.UserPlanDto
{
    public class UserPlanDto : DtoAbstract
    {
        public int Id { get; set; }
        public int WeightGoal { get; set; }
        public DateTime TIllWhen { get; set; }
        public IEnumerable<PlanDetailDto> PlanDetails { get; set; }

    }
}
