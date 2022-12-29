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
    [Authorize]
    public class CarroController : ApiController
    {
        // GET: api/Cliente
        public /*List<Cliente>*/ IHttpActionResult Get()
        {
            try
            {

                CarroRepo carroRepo = new CarroRepo();

                //List<Cliente> cliente = clienteRepo.Pesquisar();
                ClienteRepo clienteRepo = new ClienteRepo();
                var clienteLogado = clienteRepo.ConsultarPorEmail(User.Identity.Name);
                var carro = carroRepo.Pesquisar(clienteLogado.ID);

                return Ok(carro);

                //return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Cliente/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                CarroRepo carroRepo = new CarroRepo();
                //List<TipoServico> tipoServico = tipoServicoRepo.Pesquisar();
                ClienteRepo clienteRepo = new ClienteRepo();

                var clienteLogado = clienteRepo.ConsultarPorEmail(User.Identity.Name);
                var cliente = carroRepo.Pesquisar(clienteLogado.ID);
                return Ok(cliente);
                //return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]Carro carro)
        {
            try
            {
                ClienteRepo clienteRepo = new ClienteRepo();
                CarroRepo carroRepo = new CarroRepo();
                var clienteLogado = clienteRepo.ConsultarPorEmail(User.Identity.Name);
                carro.Cliente = clienteLogado.ID;
                carroRepo.Inserir(carro);
                return Ok(carro);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, [FromBody]Carro carro)
        {
            try
            {
                carro.ID = id;
                CarroRepo carroRepo = new CarroRepo();
                carroRepo.Alterar(carro);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Cliente/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                CarroRepo carroRepo = new CarroRepo();
                carroRepo.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
