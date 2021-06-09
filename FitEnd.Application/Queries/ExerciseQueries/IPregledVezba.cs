using System;
using System.Collections.Generic;
using System.Text;
using FitEnd.Application.Dto;
using FitEnd.Application.Searches;
using FitEnd.Application.Pagination;

namespace FitEnd.Application.Queries
{
    public interface IPregledVezba : IQuery<VezbaPrazanSearch, VracanjePaginacije<ExerciseDto>>
    {
    }
}
