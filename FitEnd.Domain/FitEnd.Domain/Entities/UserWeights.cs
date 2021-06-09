using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class UserWeights : Entity
    {
        public int IdUser { get; set; }
        public float Weight { get; set; }

        public User User { get; set; }
    }
}
