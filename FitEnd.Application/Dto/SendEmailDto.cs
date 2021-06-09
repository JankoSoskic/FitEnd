using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Dto
{
    public class SendEmailDto : DtoAbstract
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string komeSeSalje { get; set; }

    }
}
