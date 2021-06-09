using FitEnd.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application
{
    public interface IUseCase
    {
        public int IdUseCase { get; }
        public string NameUseCase { get; }
    }

    public interface IQuery<pretraga, rezultat> : IUseCase
    {
        public rezultat Izvrsi(pretraga pretraga);
    }
    public interface ICommand<zahtev> : IUseCase
    {
        public void Izvrsi(zahtev zahtev);
    }
}
