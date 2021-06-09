using FitEnd.Application.Commands;
using FitEnd.Application.Dto;
using FitEnd.Application.GenericActions;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;
using FitEnd.Implementation.Extensions;
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
    public class UpisExercise : IUpisExercise
    {
        private readonly Context context;
        private readonly ExerciseValidator validator;
        private readonly IPrebacivacSlika prebacivac;

        public UpisExercise(Context context, ExerciseValidator validator, IPrebacivacSlika prebacivac)
        {
            this.context = context;
            this.validator = validator;
            this.prebacivac = prebacivac;
        }

        public int IdUseCase => 3;

        public string NameUseCase => "New Exercise, insert DB";

        public void Izvrsi(UpisExerciseDto zahtev)
        {
            validator.ValidateAndThrow(zahtev);
            var imenaSlika = this.prebacivac.prebaciSliku(zahtev.Slike);

            var novaVezba = new Exercise()
            {
                AverageCalLost = zahtev.AverageCalLost,
                Description = zahtev.Description,
                IdType = zahtev.IdTypeOf,
                Naziv = zahtev.Naziv,
                ExercisePics = imenaSlika.Select(x => new ExercisePictures()
                {
                    Src = x,
                    Alt = zahtev.Naziv
                }).ToList()
            };

            this.context.Exercises.Add(novaVezba);

            this.context.SaveChanges();

        }
    }
}
