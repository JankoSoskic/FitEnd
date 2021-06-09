using FitEnd.Application.Dto;
using FitEnd.Application.Exceptions;
using FitEnd.Application.Queries;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Queries
{
    public class UzmiVezbuPrekoID : IPregledVezbePoID
    {
        public Context context;

        public UzmiVezbuPrekoID(Context context)
        {
            this.context = context;
        }
        public int IdUseCase => 2;

        public string NameUseCase => "Search Exercise with ID";

        public ExerciseDto Izvrsi(int pretraga)
        {
            var vezba = this.context.Exercises.Where(x => x.Id == pretraga).Select(x => new ExerciseDto()
            {

                IdExercise = x.Id,
                Name = x.Naziv,
                AverageCalLost = x.AverageCalLost,
                Alts = x.ExercisePics.Select(x => x.Alt),
                PicSrcs = x.ExercisePics.Select(x => x.Src),
                Description = x.Description,
                ExerciseType = x.ExerciseType.Name
            }).ToList();
            if (vezba.Count != 1)
            {
                throw new NePronadjeniObjekatException(pretraga);
            }
            return vezba.First();
        }
    }
}
