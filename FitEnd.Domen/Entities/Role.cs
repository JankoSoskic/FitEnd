using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<AllowedUseCase> AllowedUseCase { get; set; } = new HashSet<AllowedUseCase>();

    }
}
