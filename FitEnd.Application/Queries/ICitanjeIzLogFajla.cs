using FitEnd.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Queries
{
    public interface ICitanjeIzLogFajla : IQuery<string,IEnumerable<CitanjeTxtLogFajlaDto>>
    {
    }
}
