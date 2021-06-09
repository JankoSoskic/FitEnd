using System;
using System.Collections.Generic;
using System.Text;
using FitEnd.Application.Dto;

namespace FitEnd.Application.Pagination
{
    public class VracanjePaginacije<NekiDto>
        where NekiDto : DtoAbstract
    {
        public int KolikoZapisa { get; set; }
        public int TrenutnaStrana { get; set; }
        public int ZapisPoStrani { get; set; }
        public int StranicaIma => (int)Math.Ceiling((float)this.KolikoZapisa / this.ZapisPoStrani);
        public ICollection<NekiDto> Zapisi { get; set; }
    }
}
