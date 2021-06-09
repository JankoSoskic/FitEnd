using FitEnd.Application.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitEnd.Api.Core
{
    public class JwtActor : IAppActor
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public IEnumerable<int> AllowedActions { get; set; }
    }
}
