using FitEnd.Application.Commands.UsersCommand;
using FitEnd.Application.Dto;
using FitEnd.Application.Dto.UserLog_RegDto;
using FitEnd.Application.Email;
using FitEnd.Application.GenericActions;
using FitEnd.DataAccess;
using FitEnd.Domain.Entities;
using FitEnd.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Implementation.Commands.UserCommands
{
    public class RegisterUser : IRegisterUser
    {
        private readonly Context context;
        private readonly RegisterUserValidator validator;
        private readonly IEncodePassword enkoder;
        private readonly IEmailSender emailSender;

        public RegisterUser(Context context, RegisterUserValidator validator, IEncodePassword enkoder, IEmailSender emailSender)
        {
            this.context = context;
            this.validator = validator;
            this.enkoder = enkoder;
            this.emailSender = emailSender;
        }

        public int IdUseCase => 10;

        public string NameUseCase => "Register new user to system";

        public void Izvrsi(UserRegistrationDto zahtev)
        {
            this.validator.ValidateAndThrow(zahtev);
            var tezina = new List<UserWeights>();
            tezina.Add(new UserWeights()
            {
                Weight = zahtev.Tezina
            });

            var novUser = new User()
            {
                Username = zahtev.Username,
                Ime = zahtev.Ime,
                Prezime = zahtev.Prezime,
                Email = zahtev.Email,
                Password = this.enkoder.EnkodujPassword(zahtev.Password),
                IdUloge = 1,
                Visina = zahtev.Visina.ToString(),
                Weights =  tezina
            };

            this.context.Users.Add(novUser);
            this.context.SaveChanges();

            this.emailSender.sendEmail(new SendEmailDto()
            {
                Content = "<h1>Welcome to FitEnd, you have been succesfully registered</h1>",
                komeSeSalje = zahtev.Email,
                Subject = "FitEnd registered"
            });
        }
    }
}
