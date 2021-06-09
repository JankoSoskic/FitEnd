using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Domain.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Visina { get; set; }
        public int IdUloge { get; set; }

        public ICollection<UserWeights> Weights { get; set; } = new HashSet<UserWeights>();
        public Role Role { get; set; }
        public ICollection<UserPlan> Plans { get; set; } = new HashSet<UserPlan>();

    }
}
