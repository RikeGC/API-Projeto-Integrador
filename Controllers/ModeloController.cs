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
    public class ModeloController : ApiController
    {
        // GET: api/Cliente
        public /*List<Cliente>*/ IHttpActionResult Get()
        {
            try
            {

                ModeloRepo modeloRepo = new ModeloRepo();

                //List<Cliente> cliente = clienteRepo.Pesquisar();

                var modelo = modeloRepo.Pesquisar();

                return Ok(modelo);

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
                ModeloRepo modeloRepo = new ModeloRepo();
                //List<TipoServico> tipoServico = tipoServicoRepo.Pesquisar();
                var modelo = modeloRepo.Consultar(id);
                return Ok(modelo);
                //return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]MModelo modelo)
        {
            try
            {
                ModeloRepo modeloRepo = new ModeloRepo();
                modeloRepo.Inserir(modelo);
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Cliente/5
        public IHttpActionResult Put(int id, [FromBody]MModelo modelo)
        {
            try
            {
                modelo.ID = id;
                ModeloRepo modeloRepo = new ModeloRepo();
                modeloRepo.Alterar(modelo);
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
                ModeloRepo modeloRepo = new ModeloRepo();
                modeloRepo.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
