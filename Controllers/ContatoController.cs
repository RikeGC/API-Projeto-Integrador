using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_Projeto_Integrador.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ContatoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string nome, string email, string telefone, string assunto, string mensagem)
        {
            try
            {
                string body = "";
                body += "Nome: " + nome + Environment.NewLine;
                body += "E-mail: " + email + Environment.NewLine;
                body += "Telefone: " + telefone + Environment.NewLine;
                body += "Assunto: " + assunto + Environment.NewLine;
                body += "Mensagem: " + mensagem + Environment.NewLine;

                //Configurações do SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("LavaR.Ferrari@gmail.com", "lava@123");

                //Preparando a mensagem a ser enviada
                MailMessage msg = new MailMessage();
                //Rementente
                msg.From = new MailAddress(email);
                //Destinatario
                msg.To.Add(new MailAddress("LavaR.Ferrari@gmail.com"));
                //Assunto
                msg.Subject = "Contato via site: ";
                //Corpo do Email
                msg.Body = body;

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
