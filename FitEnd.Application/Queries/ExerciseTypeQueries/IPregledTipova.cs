using FitEnd.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Queries
{
    public interface IPregledTipova : IQuery<object,ICollection<SviTipoviDto>>
    {
    }
}
