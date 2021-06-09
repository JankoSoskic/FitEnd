using FitEnd.Application;
using FitEnd.Application.Dto;
using FitEnd.Application.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FitEnd.Implementation.Queries
{
    public class CitanjeLogFajla : ICitanjeIzLogFajla
    {
        public int IdUseCase => 20;

        public string NameUseCase => "Reading key insights from txt file";

        public IEnumerable<CitanjeTxtLogFajlaDto> Izvrsi(string pretraga)
        {
            var putanja = Path.Combine("wwwroot", "Logs", "logs.txt");
            var Redovi = new List<CitanjeTxtLogFajlaDto>();
            using(StreamReader stream = File.OpenText(putanja))
            {
                string s;
                while ((s= stream.ReadLine()) != null)
                {
                    var splitovan = s.Split("__||__");
                   
                    Redovi.Add(new CitanjeTxtLogFajlaDto()
                    {
                        IdentitetKoRadi = splitovan[1],
                        KadaJeRadjeno = splitovan[0],
                        OpisStaRadi = splitovan[2],
                        Parametri = splitovan[3]
                    });
                }
            }
            return Redovi;
        }
    }
}
