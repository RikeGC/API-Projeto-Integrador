using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace API_Projeto_Integrador.Controllers
{
    public class TrabalheController : ApiController
    {
        public static string Base64Encode(string curriculo)
        {
            var curriculoByte = System.Text.Encoding.UTF8.GetBytes(curriculo);
            return System.Convert.ToBase64String(curriculoByte);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        [HttpGet]
        public IHttpActionResult Get(string nome, string email, string telefone, string curriculo, string assunto, string mensagem)
        {

            {
                try
                {
                    string boby = "";
                    boby += "Nome: " + nome + Environment.NewLine;
                    boby += "E-mail: " + email + Environment.NewLine;
                    boby += "Telefone: " + telefone + Environment.NewLine;
                    boby += "Assunto: " + assunto + Environment.NewLine;
                    boby += "Mensagem: " + mensagem + Environment.NewLine;
                    boby += "Anexo: " + curriculo + Environment.NewLine;

                    // Configura��es de SMTP
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("ti01senacsmp@gmail.com", "LUgiEw6u");

                    //Preparando a mensagem a ser enviada
                    MailMessage msg = new MailMessage();
                    //Remetente
                    msg.From = new MailAddress("rodrigorslima16@gmail.com");
                    //Destinatario
                    msg.To.Add(new MailAddress("thiagoadolfomancha123@gmail.com"));
                    //Assunto
                    msg.Subject = "Contato via site: " + assunto;
                    //Corpo do Email
                    msg.Body = boby;

                    smtp.Send(msg);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
                return Ok();
            }

        }
    }
}
