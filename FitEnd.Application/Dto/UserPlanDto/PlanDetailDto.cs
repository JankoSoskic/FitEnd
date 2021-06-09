using FitEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.UserPlanDto
{
    public class PlanDetailDto : DtoAbstract
    {
        public ExerciseDto Exercise { get; set; }
        public DateTime KadaSeRadi { get; set; }
        public int Repetitions { get; set; }
    }
}
