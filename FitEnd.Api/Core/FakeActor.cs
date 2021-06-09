using FitEnd.Application.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitEnd.Api.Core
{
    public class FakeActor : IAppActor
    {
        public int Id { get => 1; }
        public string Identity { get => "Ovde bi bilo ime prezime itd...."; }
        public IEnumerable<int> AllowedActions { get => Enumerable.Range(1, 60); }
    }
}
