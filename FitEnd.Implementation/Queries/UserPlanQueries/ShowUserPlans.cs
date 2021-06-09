using FitEnd.Application.Actors;
using FitEnd.Application.Dto;
using FitEnd.Application.Dto.UserPlanDto;
using FitEnd.Application.Exceptions;
using FitEnd.Application.Queries.UserPlanQueries;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Queries.UserPlanQueries
{
    public class ShowUserPlans : IShowUserPlans
    {
        private readonly Context context;
        private readonly IAppActor actor;

        public ShowUserPlans(Context context, IAppActor actor)
        {
            this.context = context;
            this.actor = actor;
        }

        public int IdUseCase => 12;

        public string NameUseCase => "Show the plan";

        public UserPlanDto Izvrsi(int pretraga)
        {
            var prva = this.context.UserPlans.Find(pretraga);
            if(prva == null)
            {
                throw new NePronadjeniObjekatException(pretraga);
            }

            var Planovi = this.context.UserPlans.Where(x => (x.Id == pretraga && x.IdUser == this.actor.Id)).Select(x => new UserPlanDto()
            {
                Id = x.Id,
                TIllWhen = x.TillWhen,
                WeightGoal = (int)x.WeightGoal,
                PlanDetails = x.Details.Select(x => new PlanDetailDto()
                {
                    Exercise = new ExerciseDto()
                    {
                        IdExercise = x.IdExercise,
                        Name = x.Exercise.Naziv,
                        Description = x.Exercise.Description,
                        AverageCalLost = x.Exercise.AverageCalLost,
                        ExerciseType = x.Exercise.ExerciseType.Name,
                        PicSrcs = x.Exercise.ExercisePics.Select(x => x.Src),
                        Alts = x.Exercise.ExercisePics.Select(x => x.Alt),
                    },
                    KadaSeRadi = x.WhenWorking,
                    Repetitions = x.Repetitions
                }).OrderBy(x => x.KadaSeRadi).ToList()
            }).ToList();
          
            return Planovi.Count() == 1 ? Planovi.First() : throw new NeDozvoljeniPristupException(this.NameUseCase);
        }
    }
}
