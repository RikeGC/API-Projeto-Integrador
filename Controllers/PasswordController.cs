using Lib_API_Projeto_Integrador.Repositorio;
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
    public class PasswordController : ApiController
    {
        //[HttpGet]
        public IHttpActionResult Get(string email)
        {
            try
            {
                ClienteRepo clienteRepo = new ClienteRepo();
                var password = clienteRepo.ConsultarPorEmail(email);

                string body = "";
                body += "Nome: " + password.Nome + Environment.NewLine;
                body += "E-mail: " + password.Email + Environment.NewLine;
                body += "Telefone: " + password.Telefone + Environment.NewLine;
                body += "Assunto: " + "Recuperação de Senha" + Environment.NewLine;
                body += "Mensagem: " + "Senha do Usuario " + password.Usuario + " é '" + password.Senha + "' (Sem '')." + Environment.NewLine;

                //Configurações do SMTP
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("LavaR.Ferrari@gmail.com", "lava@123");

                //Preparando a mensagem a ser enviada
                MailMessage msg = new MailMessage();
                //Rementente
                msg.From = new MailAddress("LavaR.Ferrari@gmail.com");
                //Destinatario
                msg.To.Add(new MailAddress(password.Email));
                //Assunto
                msg.Subject = "Contato via APP: ";
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
