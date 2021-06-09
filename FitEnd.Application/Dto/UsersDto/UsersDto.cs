using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.UsersDto
{
    public class UsersDto : DtoAbstract
    {
        public int Id { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string NazivUloge { get; set; }

    }
}
