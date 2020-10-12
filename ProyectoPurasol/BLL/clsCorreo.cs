﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class clsCorreo
    {
        public Task SendEmailAsync(string email, string usuario,string contrasena)
        {
            try
            {
                // Credentials
                var credentials = new NetworkCredential("registro.purasol@outlook.com", "Purasol123.");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("registro.purasol@outlook.com", "Registro Purasol"),
                    Subject = "Registro de usuario",
                    Body = "<h4>Usuario:"+ usuario + "</h4><br/>"+ "<h4>Contraseña:" + contrasena + "</h4><br/>",
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(email));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.live.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
