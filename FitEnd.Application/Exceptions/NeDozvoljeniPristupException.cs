using FitEnd.Application.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Exceptions
{
    public class NeDozvoljeniPristupException : Exception
    {
        public NeDozvoljeniPristupException(string imeUseCase): base($"{imeUseCase} is not allowed for you")
        {

        }
    }
}
