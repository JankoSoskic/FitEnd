using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.UsersDto
{
    public class ChangeUserRoleDto : DtoAbstract
    {
        public int IdKorisnika { get; set; }
        public int NoviRole { get; set; }

    }
}
