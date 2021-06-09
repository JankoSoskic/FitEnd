using FitEnd.Application.Dto.UsersDto;
using FitEnd.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Validators
{
    public class ChangeUserRoleValidator : AbstractValidator<ChangeUserRoleDto>
    {
        public ChangeUserRoleValidator(Context context)
        {
            RuleFor(x => x.IdKorisnika).NotEmpty().WithMessage("Id User is manditory").Must(x => context.Users.Any(t => t.Id == x)).WithMessage("User is not found");
            RuleFor(x => x.NoviRole).NotEmpty().WithMessage("Role is manditory").Must(x => context.Roles.Any(t => t.Id == x)).WithMessage("Role not found")
               .Must((x, y) => 
               {
                   var kor = context.Users.Where(t => t.Id == x.IdKorisnika).Select(m => m.IdUloge);
                   var ima = kor.Count() == 1 ? kor.First() : 0;
                   return ima != x.NoviRole;
               } ).WithMessage("Role must be different");
        }
    }
}
