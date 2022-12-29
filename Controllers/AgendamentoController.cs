using Lib_API_Projeto_Integrador.Modelo;
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
    [Authorize]
    public class AgendamentoController : ApiController
    {

        public IHttpActionResult Get()
        {
            try
            {
                AgendamentoRepo agendamentoRepo = new AgendamentoRepo();
                ClienteRepo clienteRepo = new ClienteRepo();
                var clienteLogado = clienteRepo.ConsultarPorEmail(User.Identity.Name);
                var agendamento = agendamentoRepo.Pesquisar(clienteLogado.ID);

                return Ok(agendamento);


            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                AgendamentoRepo agendamentoRepo = new AgendamentoRepo();
                var agendamento = agendamentoRepo.Consultar(id);

                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Post([FromBody]Agendamento agendamento)
        {
            try
            {
                AgendamentoRepo agendamentoRepo = new AgendamentoRepo();
                agendamentoRepo.Inserir(agendamento);
                return Ok(agendamento);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Put(int id, [FromBody]Agendamento agendamento)
        {
            try
            {
                agendamento.ID = id;
                AgendamentoRepo agendamentoRepo = new AgendamentoRepo();
                agendamentoRepo.Alterar(agendamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AgendamentoRepo agendamentoRepo = new AgendamentoRepo();
                agendamentoRepo.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

