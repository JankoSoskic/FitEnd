using FitEnd.Application.GenericActions;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnosInicijalnihPodataka : ControllerBase
    {

       
        // POST api/<UnosInicijalnihPodataka>
        [HttpPost]
        public IActionResult Post([FromServices] Context context,[FromServices] IEncodePassword encoder)
        {
            // iz nekog razologa mi nije upisivao sve podatke redno kao sto su navedeni, neko orderovane po imenu, iz tog razloga for petlja i odma saveChanges, a ne AddRange()

            #region Dodavanje ExerciseTypes
            var ExerciseType = new Domain.Entities.ExerciseType[4];
            ExerciseType[0] = (new Domain.Entities.ExerciseType()
            {
                Name = "Endurance",
            });
            ExerciseType[1] = (new Domain.Entities.ExerciseType()
            {
                Name = "Strength",
            });
            ExerciseType[2] = (new Domain.Entities.ExerciseType()
            {
                Name = "Balance",
            });
            ExerciseType[3] = (new Domain.Entities.ExerciseType()
            {
                Name = "Flexibility",
            });
            foreach(var ex in ExerciseType)
            {
                context.ExerciseTypes.Add(ex);
                context.SaveChanges();
            }
            #endregion

            #region Dodavanje Exercise
            var Exercises = new List<FitEnd.Domain.Entities.Exercise>();
            Exercises.Add(new Exercise()
            {
                Naziv = "Pull up",
                AverageCalLost = 2,
                Description = "A pullup is an upper body strength training exercise. To perform a pullup, you start by hanging onto a pullup bar with your palms facing away from you and your body extended fully. You then pull yourself up until your chin is above the bar",
                IdType = 2,
            });
            Exercises.Add(new Exercise()
            {
                Naziv = "100m sprint",
                AverageCalLost = 2.5,
                Description = "100m sprint is a good exercise for fast burning fat, be carefoul though it is really tiring.",
                IdType = 1,
            });
            Exercises.Add(new Exercise()
            {
                Naziv = "Push up",
                AverageCalLost = 1,
                Description = "Traditional pushups are beneficial for building upper body strength. They work the triceps, pectoral muscles, and shoulders. When done with proper form, they can also strengthen the lower back and core by engaging (pulling in) the abdominal muscles.",
                IdType = 2,
            });
            Exercises.Add(new Exercise()
            {
                Naziv = "Knees to Chest",
                AverageCalLost = 0.6,
                Description = "Lie on the back with knees bent. Grasp the tops of knees and bring them out toward the armpits, rocking gently. Hold for five seconds. Repeat three to five times.",
                IdType = 4,
            });
            Exercises.Add(new Exercise()
            {
                Naziv = "Single Limb Stance with Arm",
                AverageCalLost = 0.8,
                Description = "This balance exercise for seniors improves your physical coordination. Stand with your feet together and arms at your side next to a chair.Lift your left hand over your head.Then, slowly raise your left foot off the floor.Hold that position for ten seconds. Repeat the same action on the right side.",
                IdType = 3,
            });
            Exercises.Add(new Exercise()
            {
                Naziv = "Bicep Curl",
                AverageCalLost = 2,
                Description = "One of the simplest and most common weight exercises is also one of the best. It works a host of bicep and tricep muscles. Throughout this movement, make sure you keep your back straight and your upper body controlled.",
                IdType = 2,
            });
            Exercises.Add(new Exercise()
            {
                Naziv = "1km jogg",
                AverageCalLost = 62,
                Description = "Running is the best calorie burner, the longer you run the better.",
                IdType = 2,
            });
            foreach (var ex in Exercises)
            {
                context.Exercises.Add(ex);
            context.SaveChanges();
            }
            #endregion

            #region Dodavanje ExercisePictures
            var ExercisesPictures = new List<ExercisePictures>();
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 1,
                Alt = "Pull ups",
                Src = "1.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 1,
                Alt = "Pull ups",
                Src = "2.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 2,
                Alt = "100m sprint",
                Src = "3.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 3,
                Alt = "Push ups",
                Src = "4.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 3,
                Alt = "Push ups",
                Src = "5.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 3,
                Alt = "Push ups",
                Src = "6.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 4,
                Alt = "Knees to Chest",
                Src = "7.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 6,
                Alt = "Bicep Curl",
                Src = "8.jpg"
            });
            ExercisesPictures.Add(new ExercisePictures()
            {
                IdExercise = 7,
                Alt = "1km jogg",
                Src = "9.jpg"
            });
            foreach (var ex in ExercisesPictures)
            {
                context.ExercisePictures.Add(ex);
            context.SaveChanges();
            }
            #endregion

            #region Dodavanje Roles
            var Roles = new List<Role>();
            Roles.Add(new Role()
            {
                Name = "User",//1
            });
            Roles.Add(new Role()
            {
                Name = "Admin",//2
            });
            foreach (var ex in Roles)
            {
                context.Roles.Add(ex);
            context.SaveChanges();
            }
            #endregion

            #region Dodavanje UseCases

            var UseCases = new List<UseCase>();

            UseCases.Add(new UseCase()
            {
                Name = "Search for every exercise paginated"//1 anonimni 
            });
            UseCases.Add(new UseCase()
            {
                Name = "Search Exercise with ID"//2 anonimni
            });
            UseCases.Add(new UseCase()
            {
                Name = "New Exercise, insert DB"//3
            });
            UseCases.Add(new UseCase()
            {
                Name = "Update one exercise"//4
            });
            UseCases.Add(new UseCase()
            {
                Name = "Remove exercise"//5
            });
            UseCases.Add(new UseCase()
            {
                Name = "Getting every single Exercise type"//6 anonimni
            });
            UseCases.Add(new UseCase()
            {
                Name = "Inserting new exercise type"//7
            });
            UseCases.Add(new UseCase()
            {
                Name = "Update exercise type"//8
            });
            UseCases.Add(new UseCase()
            {
                Name = "Deleteing Exercise type"//9
            });
            UseCases.Add(new UseCase()
            {
                Name = "Register new user to system"//10 anonimni
            });
            UseCases.Add(new UseCase()
            {
                Name = "Create new user plan"//11
            });
            UseCases.Add(new UseCase()
            {
                Name = "Show the plan"//12
            });
            UseCases.Add(new UseCase()
            {
                Name = "Delete user plan"//13
            });
            UseCases.Add(new UseCase()
            {
                Name = "Search exercise by its Name"//14 anonimni
            });
            UseCases.Add(new UseCase()
            {
                Name = "Update user weight"//15
            });
            UseCases.Add(new UseCase()
            {
                Name = "Search for users"//16
            });
            UseCases.Add(new UseCase()
            {
                Name = "Change user role"//17
            });
            UseCases.Add(new UseCase()
            {
                Name = "Search for every role"//18
            });
            UseCases.Add(new UseCase()
            {
                Name = "Delete user"//19
            });
            UseCases.Add(new UseCase()
            {
                Name = "Reading key insights from txt file"//20
            });
            foreach (var ex in UseCases)
            {
                context.UseCases.Add(ex);
            context.SaveChanges();
            }
            #endregion

            #region Dodavanje AllowedUseCases

            var AllowedUseCases = new List<AllowedUseCase>();

            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 1,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 1,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 2,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 2,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 3,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 4,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 5,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 6,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 6,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 7,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 8,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 9,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 10,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 11,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 12,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 13,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 14,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 14,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 1,
                IdUseCase = 15,
            });

            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 16,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 17,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 18,
            });

            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 19,
            });
            AllowedUseCases.Add(new AllowedUseCase()
            {
                IdRole = 2,
                IdUseCase = 20,
            });
            foreach (var ex in AllowedUseCases)
            {
                context.AllowedUseCases.Add(ex);
            context.SaveChanges();
            }
            #endregion

            #region Dodavanje Users

            var Users = new List<User>();
            Users.Add(new User()
            {
                Username = "Regularni",
                Ime = "Petar",
                Prezime = "Petrovic",
                Password = encoder.EnkodujPassword("Solser1234"),
                Email = "NekiEmail@gmail.com",
                Visina = "175",
                IdUloge = 1
            });
            Users.Add(new User()
            {
                Username = "Admin",
                Ime = "Admin",
                Prezime = "Adminovic",
                Password = encoder.EnkodujPassword("Solser1234"),
                Email = "Admin@gmail.com",
                Visina = "175",
                IdUloge = 2
            });
            foreach (var ex in Users)
            {
                context.Users.Add(ex);
            context.SaveChanges();
            }
            #endregion

            #region Dodavanje UserWeight
            var tezine = new List<UserWeights>();
            tezine.Add(new UserWeights()
            {
                IdUser = 1,
                Weight = 75
            });
            tezine.Add(new UserWeights()
            {
                IdUser = 2,
                Weight = 55
            });
            foreach (var ex in tezine)
            {
                context.UserWeights.Add(ex);
            context.SaveChanges();
            }
            #endregion

            return NoContent();
        }

    }
}
