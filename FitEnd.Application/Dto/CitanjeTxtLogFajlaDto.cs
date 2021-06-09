using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto
{
    public class CitanjeTxtLogFajlaDto : DtoAbstract
    {
        public string KadaJeRadjeno { get; set; }
        public string IdentitetKoRadi { get; set; }
        public string OpisStaRadi { get; set; }
        public object Parametri { get; set; }
    }
}
