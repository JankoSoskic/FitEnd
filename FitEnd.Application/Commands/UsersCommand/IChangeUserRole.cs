using FitEnd.Application.Dto.UsersDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Commands.UsersCommand
{
    public interface IChangeUserRole : ICommand<ChangeUserRoleDto>
    {
    }
}
