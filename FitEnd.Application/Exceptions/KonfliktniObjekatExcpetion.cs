using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Exceptions
{
    public class KonfliktniObjekatExcpetion : Exception
    {
        public KonfliktniObjekatExcpetion(int idTrazenog) : base($"Exercise with id:{idTrazenog} already exists in another Plans, so you can not remove this object")
        {

        }
    }
}
