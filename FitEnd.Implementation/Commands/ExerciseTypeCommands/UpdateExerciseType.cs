using FitEnd.Application.Commands.ExerciseTypeCommands;
using FitEnd.Application.Dto;
using FitEnd.Application.Dto.ExerciseTypeDto;
using FitEnd.Application.Exceptions;
using FitEnd.DataAccess;
using FitEnd.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Implementation.Commands.ExerciseTypeCommands
{
    public class UpdateExerciseType : IUpdateExerciseType
    {
        private readonly Context context;
        private readonly NewExerciseTypeValidator validator;

        public UpdateExerciseType(Context context, NewExerciseTypeValidator validator)
        {
            this.context = context;
            this.validator = validator;
        }

        public int IdUseCase => 8;

        public string NameUseCase => "Update exercise type";

        public void Izvrsi(UpdateExerciseTypeDto zahtev)
        {
            var obj = this.context.ExerciseTypes.Find(zahtev.Id);
            if(obj == null)
            {
                throw new NePronadjeniObjekatException(zahtev.Id);
            }
            var prepravkaVAL = new NewExerciseTypeDto()
            {
                Naziv = zahtev.Naziv
            };
            this.validator.ValidateAndThrow(prepravkaVAL);
            obj.Name = zahtev.Naziv;
            this.context.SaveChanges();
        }
    }
}
