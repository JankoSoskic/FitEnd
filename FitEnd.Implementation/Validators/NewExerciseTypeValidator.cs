using FitEnd.Application.Dto;
using FitEnd.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Validators
{
    public class NewExerciseTypeValidator : AbstractValidator<NewExerciseTypeDto>
    {
        public NewExerciseTypeValidator(Context context)
        {
            RuleFor(x => x.Naziv).NotEmpty().WithMessage("Name must not be empty").Matches("^[A-Z][a-z\\s]{2,14}$").WithMessage("Name must begin with capital letter, min 3 chars and max 15").Must(x => !context.ExerciseTypes.Any(t => t.Name == x)).WithMessage("That name already exist's in database");
        }
    }
}
