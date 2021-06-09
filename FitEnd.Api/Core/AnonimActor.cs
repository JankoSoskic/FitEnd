using FitEnd.Application.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitEnd.Api.Core
{
    public class AnonimActor : IAppActor
    {
        public int Id => 1;

        public string Identity => "Anonymus actor";

        public IEnumerable<int> AllowedActions => new List<int>() { 1,2,6,10,14};
    }
}
