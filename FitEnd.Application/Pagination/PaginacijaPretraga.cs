using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Pagination
{
    public abstract class PaginacijaPretraga
    {
        public int PoStrani { get; set; } = 5;
        public int KojaStrana { get; set; } = 1;
    }
}
