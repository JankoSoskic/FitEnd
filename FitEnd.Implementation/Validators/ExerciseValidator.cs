using FitEnd.Application.Dto;
using FitEnd.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Validators
{
    public class ExerciseValidator : AbstractValidator<UpisExerciseDto>
    {
        public ExerciseValidator(Context context)
        {
            RuleFor(x => x.Naziv).NotEmpty().WithMessage("Name must not be empty").Matches("^[A-Z][a-z\\s]{2,24}$").WithMessage("Name must begin with capital letter, min 3 chars and max 25").Must(x => !context.Exercises.Any(t => t.Naziv.ToLower() == x.ToLower())).WithMessage("That name already exist's in database");
            RuleFor(x => x.AverageCalLost).NotEmpty().WithMessage("Average cal lost must not be emtpy").GreaterThan(0).WithMessage("Must be greater than 0");
            RuleFor(x => x.IdTypeOf).NotEmpty().WithMessage("Type must not be empty").Must(x => context.ExerciseTypes.Any(y => y.Id == x)).WithMessage("Specified id is not found in database");
            RuleFor(x => x.Slike).NotEmpty().WithMessage("There must be atleast 1 image").Must(x =>
            {
                var unikatneSlike = x.Distinct();
                return unikatneSlike.Count() == x.Count();
            }).WithMessage("There are copyies of sent pictures");
            RuleForEach(x => x.Slike).SetValidator(new ImageValidator());
        }
    }
}
