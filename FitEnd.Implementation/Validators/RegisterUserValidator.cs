using FitEnd.Application.Dto.UserLog_RegDto;
using FitEnd.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<UserRegistrationDto>
    {
        public RegisterUserValidator(Context context)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must not be empty").EmailAddress().WithMessage("Email is bad format").Must(x => !context.Users.Any(t => t.Email == x)).WithMessage("Email already taken");
            RuleFor(x => x.Ime).NotEmpty().WithMessage("Name must not be empty").Matches("^[A-Z][a-z]{2,15}$").WithMessage("Name must begin with capital letter, min 2 chars max 15");
            RuleFor(x => x.Prezime).NotEmpty().WithMessage("Last name must not be empty").Matches("^[A-Z][a-z]{2,15}$").WithMessage("Last name must begin with capital letter, min 2 chars max 15");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must not be empty").Matches("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}").WithMessage("Password must contain atleast one number, capital letter, of min 6 length");
            RuleFor(x => x.Tezina).NotEmpty().WithMessage("Weight must not be empty").GreaterThan(20).WithMessage("Weight must be greater than 20kg");
            RuleFor(x => x.Visina).NotEmpty().WithMessage("Height must not be empty").GreaterThan(120).WithMessage("Must be greater than 120cm").LessThan(270).WithMessage("Must be less then 270cm");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username must not be empty").Matches("^[A-z1-9]{5,25}$").WithMessage("Username must only contain numbers and letters, min 5 chars max 25").Must(x => !context.Users.Any(t => t.Username == x)).WithMessage("Username already taken");
        }
    }
}
