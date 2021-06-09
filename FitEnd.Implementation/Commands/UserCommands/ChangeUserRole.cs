using FitEnd.Application.Commands.UsersCommand;
using FitEnd.Application.Dto.UsersDto;
using FitEnd.DataAccess;
using FitEnd.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Implementation.Commands.UserCommands
{
    public class ChangeUserRole : IChangeUserRole
    {
        private readonly Context context;
        private readonly ChangeUserRoleValidator validator;
        public ChangeUserRole(Context context, ChangeUserRoleValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int IdUseCase => 17;

        public string NameUseCase => "Change user role";

        public void Izvrsi(ChangeUserRoleDto zahtev)
        {
            this.validator.ValidateAndThrow(zahtev);
            var user = this.context.Users.Find(zahtev.IdKorisnika);
            user.IdUloge = zahtev.NoviRole;
            this.context.SaveChanges();
        }
    }
}
