using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class UseCase : Entity
    {
        public string Name { get; set; }

        public ICollection<AllowedUseCase> AllowedUseCases { get; set; } = new HashSet<AllowedUseCase>();
    }
}
