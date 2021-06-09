using FitEnd.Application.Actors;
using FitEnd.Application.Commands.UserPlanCommands;
using FitEnd.Application.Dto.UserPlanDto;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;
using FitEnd.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitEnd.Implementation.Commands.UserPlansCommands
{
    public class CreateNewUserPlan : ICreateNewUserPlan
    {
        private readonly Context context;
        private readonly NewUserPlanValidator validor;
        private readonly IAppActor actor;
        private static int LooseCalForOneKG = 9000; //Uzet je neki prosek od 7000 da je potrebno za mrsavljenje 1kg-a, uzeto u obzir da se unosi oko 2000 kalorija na dan
        private static int DifferentExercisePerDay = 6; //Broj razlcitih vezba po nekoj vezbi

        public CreateNewUserPlan(Context context, NewUserPlanValidator validor, IAppActor actor)
        {
            this.context = context;
            this.validor = validor;
            this.actor = actor;
        }

        public int IdUseCase => 11;

        public string NameUseCase => "Create new user plan";

        public void Izvrsi(NewUserPlanDto zahtev)
        {
            var randomela = new Random();

            this.validor.ValidateAndThrow(zahtev);
            var trenutnaTezina = this.context.UserWeights.Where(x => x.IdUser == this.actor.Id).OrderByDescending(x => x.CreatedAt).First().Weight;
            var kolikoGubiKalorija = (trenutnaTezina - zahtev.WeightGoal) * LooseCalForOneKG;//Broj kilograma koje zeli da izgubi
            var kolikoDana = Math.Ceiling(((zahtev.TillWhen - DateTime.UtcNow).TotalDays));//Kroz koliko dana zeli da izgubi tezinu
            var kalorijaPoDanuVezbeGubi = Math.Ceiling(kolikoGubiKalorija / kolikoDana);//Kada dodje dan vezbanja koliko kalorija mora da izgubi
            var PotrebnoIzgubljenihKalorijaPoVezbi = Math.Ceiling(kalorijaPoDanuVezbeGubi / DifferentExercisePerDay);//Posto ce po danu vezbanja raditi 6 razlicitih vezba, po vezbi mora da izgubi odrjedjeni broj kalorija u sumi
            var Vezbe = this.context.Exercises.ToList();
            var brojVezba = Vezbe.Count();
            var SviPlanoviDetails = new List<PlanDetail>();

            for (int i = 0; i < kolikoDana; i += 2) //Svaki drugi dan ce se odrzavati vezba, samim tim i napraviti novi plan detail po danu vezbe
            {

                var SestRandom = new List<int>();
                for (int y = 0; y < 6; y++)
                {
                    SestRandom.Add(randomela.Next(0, brojVezba));
                }
                var IzabraneVezbe = new List<Exercise>();
                foreach (var jedan in SestRandom)
                {
                    IzabraneVezbe.Add(Vezbe.ElementAt(jedan));
                }
                foreach (var jedan in IzabraneVezbe)
                {
                    var kadaRadiVezbu = DateTime.UtcNow.AddDays(2);
                    var noviDetalj = new PlanDetail()
                    {
                        IdExercise = jedan.Id,
                        Repetitions = (int)Math.Ceiling(PotrebnoIzgubljenihKalorijaPoVezbi / jedan.AverageCalLost),
                        WhenWorking = DateTime.UtcNow.AddDays(i)
                    };
                    SviPlanoviDetails.Add(noviDetalj);
                }
            }
            var noviUserPlan = new UserPlan()
            {
                IdUser = this.actor.Id,
                TillWhen = zahtev.TillWhen,
                WeightGoal = zahtev.WeightGoal,
                Details = SviPlanoviDetails
            };
            this.context.Add(noviUserPlan);
            this.context.SaveChanges();
        }
    }
}
