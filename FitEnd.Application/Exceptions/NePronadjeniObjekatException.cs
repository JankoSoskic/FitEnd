using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Exceptions
{
    public class NePronadjeniObjekatException : Exception
    {
        public NePronadjeniObjekatException(int idTrazenog):base($"Row with id = {idTrazenog}, is not found")
        {

        }
    }
}
