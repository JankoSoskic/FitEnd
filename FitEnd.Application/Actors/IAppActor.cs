using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Actors
{
    public interface IAppActor 
    {
        public int Id { get; }
        public string Identity { get; }
        public IEnumerable<int> AllowedActions { get; }

    }
}
