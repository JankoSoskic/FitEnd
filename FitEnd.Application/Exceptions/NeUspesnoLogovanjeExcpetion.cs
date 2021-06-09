using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Exceptions
{
    public class NeUspesnoLogovanjeExcpetion : Exception
    {
        public NeUspesnoLogovanjeExcpetion() : base("That combination of username and password is not found")
        {

        }
    }
}
