using Lib_API_Projeto_Integrador.Modelo;
using Lib_API_Projeto_Integrador.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_Projeto_Integrador.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class ServicoController : ApiController
    {
        // GET: api/Cliente
        public /*List<Cliente>*/ IHttpActionResult Get()
        {
            try
            {

                ServicoRepo servicoRepo = new ServicoRepo();

                //List<Cliente> cliente = clienteRepo.Pesquisar();

                var cliente = servicoRepo.Pesquisar();

                return Ok(cliente);

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
                ServicoRepo servicoRepo = new ServicoRepo();
                //List<TipoServico> tipoServico = tipoServicoRepo.Pesquisar();
                var servico = servicoRepo.Consultar(id);
                return Ok(servico);
                //return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]Servico servico)
        {
            try
            {
                ServicoRepo servicoRepo = new ServicoRepo();
                servicoRepo.Inserir(servico);
                return Ok(servico);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, [FromBody]Servico servico)
        {
            try
            {
                servico.ID = id;
                ServicoRepo servicoRepo = new ServicoRepo();
                servicoRepo.Alterar(servico);
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
                ServicoRepo servicoRepo = new ServicoRepo();
                servicoRepo.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}