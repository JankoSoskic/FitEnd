using FitEnd.Application.Dto.UserPlanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Application.Queries.UserPlanQueries
{
    public interface IShowUserPlans : IQuery<int,UserPlanDto>
    {
    }
}
