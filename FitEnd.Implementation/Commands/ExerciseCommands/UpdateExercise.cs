using FitEnd.Application.Commands;
using FitEnd.Application.Dto;
using FitEnd.Application.Exceptions;
using FitEnd.Application.GenericActions;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;
using FitEnd.Implementation.GenericActions;
using FitEnd.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Commands
{
    public class UpdateExercise : IUpdateExercise
    {
        private readonly Context context;
        private readonly ExerciseValidator validator;
        private readonly IPrebacivacSlika prebacivac;

        public UpdateExercise(Context context, ExerciseValidator validator, IPrebacivacSlika prebacivac)
        {
            this.context = context;
            this.validator = validator;
            this.prebacivac = prebacivac;
        }

        public int IdUseCase => 4;

        public string NameUseCase => "Update one exercise";

        public void Izvrsi(UpdateExerciseDto zahtev)
        {
            var exercise = this.context.Exercises.Find(zahtev.Id);
            if(exercise == null)
            {
                throw new NePronadjeniObjekatException(zahtev.Id);
            }
            var prepravkaVAL = new UpisExerciseDto()
            {
                AverageCalLost = zahtev.AverageCalLost,
                Description = zahtev.Description,
                IdTypeOf = zahtev.IdTypeOf,
                Naziv = zahtev.Naziv,
                Slike = zahtev.Slike
            };
            this.validator.ValidateAndThrow(prepravkaVAL);
            var slikeZaBrisanje = this.context.ExercisePictures.Where(x => x.IdExercise == zahtev.Id);
            this.context.ExercisePictures.RemoveRange(slikeZaBrisanje);
            this.prebacivac.izbrisiSlike(slikeZaBrisanje);
            var novaImena = this.prebacivac.prebaciSliku(zahtev.Slike);
            exercise.AverageCalLost = zahtev.AverageCalLost;
            exercise.Description = zahtev.Description;
            exercise.ExercisePics = novaImena.Select(x => new ExercisePictures()
            {
                Alt = zahtev.Naziv,
                Src = x
            }).ToList();
            exercise.Naziv = zahtev.Naziv;
            exercise.IdType = zahtev.IdTypeOf;

            this.context.SaveChanges();
        }
    }
}
