using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.UserLog_RegDto
{
    public class UserRegistrationDto : DtoAbstract
    {
        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Visina { get; set; }
        public float Tezina { get; set; }
    }
}
