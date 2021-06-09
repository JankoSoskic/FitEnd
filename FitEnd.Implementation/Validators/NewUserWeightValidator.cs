using FitEnd.Application.Actors;
using FitEnd.Application.Dto.UserPlanDto;
using FitEnd.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Validators
{
    public class NewUserWeightValidator : AbstractValidator<UserNewWeightDto>
    {
        public NewUserWeightValidator(Context context,IAppActor actor)
        {
            RuleFor(x => x.UserWeight).NotEmpty().WithMessage("You must specify new weight").GreaterThan(20).WithMessage("Must be greater than 20kg")
                .Must(x => x != context.UserWeights.Where(x => x.IdUser == actor.Id).OrderByDescending(x => x.CreatedAt).First().Weight).WithMessage("Weight is the same");
        }
    }
}
