using FitEnd.Application.Actors;
using FitEnd.Application.Commands.UserPlanCommands;
using FitEnd.Application.Dto.UserPlanDto;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;
using FitEnd.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Implementation.Commands.UserPlansCommands
{
    public class NewUserWeight : INewUserWeight
    {
        private readonly Context context;
        private readonly IAppActor actor;
        private readonly NewUserWeightValidator validator;

        public NewUserWeight(Context context, IAppActor actor, NewUserWeightValidator validator)
        {
            this.context = context;
            this.actor = actor;
            this.validator = validator;
        }

        public int IdUseCase => 15;

        public string NameUseCase => "Update user weight";

        public void Izvrsi(UserNewWeightDto zahtev)
        {
            this.validator.ValidateAndThrow(zahtev);
            var novaTezina = new UserWeights()
            {
                Weight = zahtev.UserWeight,
                IdUser = this.actor.Id
            };
            this.context.UserWeights.Add(novaTezina);
            this.context.SaveChanges();
        }
    }
}
