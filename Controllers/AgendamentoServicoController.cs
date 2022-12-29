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
    public class AgendamentoServicoController : ApiController
    {
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        AgendaServRepo agendamentoServicoRepo = new AgendaServRepo();
        //        var agendamentoServico = agendamentoServicoRepo.Consultar();

        //        return Ok(agendamentoServico);


        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        public IHttpActionResult Get(int id)
        {
            try
            {
                AgendaServRepo agendamentoServicoRepo = new AgendaServRepo();
                var agendamentoServico = agendamentoServicoRepo.Consultar(id);

                return Ok(agendamentoServico);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Post([FromBody]AgendamentoServico agendamentoServico)
        {
            try
            {
                AgendaServRepo agendamentoServicoRepo = new AgendaServRepo();
                agendamentoServicoRepo.Inserir(agendamentoServico);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        public IHttpActionResult Put(int id, [FromBody]AgendamentoServico agendamentoServico)
        {
            try
            {
                agendamentoServico.ID = id;
                AgendaServRepo agendamentoServicoRepo = new AgendaServRepo();
                agendamentoServicoRepo.Alterar(agendamentoServico);
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
                AgendaServRepo agendamentoServicoRepo = new AgendaServRepo();
                agendamentoServicoRepo.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
