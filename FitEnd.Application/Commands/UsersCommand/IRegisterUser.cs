using FitEnd.Application.Dto.UserLog_RegDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Commands.UsersCommand
{
    public interface IRegisterUser : ICommand<UserRegistrationDto>
    {
    }
}
