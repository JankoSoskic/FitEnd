using FitEnd.Application.Commands;
using FitEnd.Application.Dto;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;
using FitEnd.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Implementation.Commands.ExerciseTypeCommands
{
    public class NewExerciseType : INewExerciseType
    {
        private readonly Context context;
        private readonly NewExerciseTypeValidator validator;

        public NewExerciseType(Context context, NewExerciseTypeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int IdUseCase => 7;

        public string NameUseCase => "Inserting new exercise type";

        public void Izvrsi(NewExerciseTypeDto zahtev)
        {
            this.validator.ValidateAndThrow(zahtev);

            var noviTip = new ExerciseType()
            {
                Name = zahtev.Naziv
            };
            this.context.ExerciseTypes.Add(noviTip);
            this.context.SaveChanges();
        }
    }
}
