using FitEnd.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitEnd.Application.Email
{
    public interface IEmailSender
    {
        public void sendEmail(SendEmailDto dto);
    }
}
