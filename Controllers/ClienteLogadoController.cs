using Lib_API_Projeto_Integrador.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_Projeto_Integrador.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClienteLogadoController : ApiController
    {
        [Authorize]
        // GET: api/UsuarioLogado
        public IHttpActionResult Get()
        {
            //User.Identity.Name
            ClienteRepo clienteRepo = new ClienteRepo();

            var clienteLogado = clienteRepo.ConsultarPorEmail(User.Identity.Name);
            clienteLogado.Senha = "";


            return Ok(clienteLogado);
        }


    }
}
