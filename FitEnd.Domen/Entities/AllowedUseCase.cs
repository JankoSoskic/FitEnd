using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class AllowedUseCase : Entity
    {
        public int IdRole { get; set; }
        public int IdUseCase { get; set; }

        public Role Uloga { get; set; }
        public UseCase UseCase { get; set; }
    }
}
