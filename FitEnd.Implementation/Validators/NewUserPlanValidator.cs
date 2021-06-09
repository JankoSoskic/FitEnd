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
    public class NewUserPlanValidator : AbstractValidator<NewUserPlanDto>
    {
        public NewUserPlanValidator(Context context,IAppActor actor)
        {
            RuleFor(x => x.WeightGoal).NotEmpty().WithMessage("Weight goal is required").GreaterThan(20).WithMessage("Must be greater than 20kg").Must(x =>
            {
                var TrenutnaTezinaKorisnika = context.UserWeights.Where(m => m.IdUser == actor.Id).OrderByDescending(t => t.CreatedAt).First().Weight;
                return x < TrenutnaTezinaKorisnika;
            }).WithMessage("Weight goal must be less than current weight");
            RuleFor(x => x.TillWhen).NotEmpty().WithMessage("End date is required").Must(x => x > DateTime.UtcNow.AddDays(30)).WithMessage("End goal must atleast 30 days in future");
        }
    }
}
