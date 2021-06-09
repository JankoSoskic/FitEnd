using FitEnd.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Searches
{
    public class VezbaPrazanSearch : PaginacijaPretraga
    {
        public int IdTipaVezbe { get; set; } = -1;
    }
}
