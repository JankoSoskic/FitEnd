using FitEnd.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Queries.ExerciseQueries
{
    public interface IPretragaPoNazivu : IQuery<string,IEnumerable<ExerciseDto>>
    {
    }
}
