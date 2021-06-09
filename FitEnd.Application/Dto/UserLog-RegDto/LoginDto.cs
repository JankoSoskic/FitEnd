using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto.UserLog_RegDto
{
    public class LoginDto :DtoAbstract
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
