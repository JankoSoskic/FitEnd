using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.UserPlanDto
{
    public class NewUserPlanDto : DtoAbstract
    {
        public int WeightGoal { get; set; }
        public DateTime TillWhen { get; set; }

    }
}
