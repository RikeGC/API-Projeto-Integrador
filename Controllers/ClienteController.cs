using Lib_API_Projeto_Integrador.Modelo;
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
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        [Authorize]
        public /*List<Cliente>*/ IHttpActionResult Get()
        {
            try
            {

                ClienteRepo clienteRepo = new ClienteRepo();
                var clienteLogado = clienteRepo.ConsultarPorEmail(User.Identity.Name);
                //List<Cliente> cliente = clienteRepo.Pesquisar();

                var cliente = clienteRepo.Pesquisar(clienteLogado.ID);

                return Ok(cliente);

                //return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Cliente/5
        [Authorize]
        public IHttpActionResult Get(int id)
        {
            try
            {
                ClienteRepo clienteRepo = new ClienteRepo();
                //List<TipoServico> tipoServico = tipoServicoRepo.Pesquisar();
                var cliente = clienteRepo.Consultar(id);
                return Ok(cliente);
                //return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                ClienteRepo clienteRepo = new ClienteRepo();
                clienteRepo.Inserir(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Cliente/5
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody]Cliente cliente)
        {
            try
            {
                cliente.ID = id;
                ClienteRepo clienteRepo = new ClienteRepo();
                clienteRepo.Alterar(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Cliente/5
        [Authorize]
        public IHttpActionResult Delete(int id, [FromBody]Cliente cliente)
        {
            try
            {
                cliente.ID = id;
                ClienteRepo clienteRepo = new ClienteRepo();
                clienteRepo.Excluir(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}