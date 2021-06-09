using FitEnd.Application.Commands.UsersCommand;
using FitEnd.Application.Exceptions;
using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Implementation.Commands.UserCommands
{
    public class DeleteUser : IDeleteUser
    {
        private readonly Context context;

        public DeleteUser(Context context)
        {
            this.context = context;
        }

        public int IdUseCase => 19;

        public string NameUseCase => "Delete user";

        public void Izvrsi(int zahtev)
        {
            var korisnik = this.context.Users.Find(zahtev);
            if(korisnik == null)
            {
                throw new NePronadjeniObjekatException(zahtev); 
            }
            korisnik.IsDeleted = true;
            korisnik.DeletedAt = DateTime.UtcNow;
            this.context.SaveChanges();
        }
    }
}
