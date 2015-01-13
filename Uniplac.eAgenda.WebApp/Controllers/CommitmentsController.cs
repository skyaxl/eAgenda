using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Web;
using System.Web.Http;

using Uniplac.eAgenda.Dominio.CompromissoModule;
using Uniplac.eAgenda.Infraestrutura.Dao.CompromissoModule;

namespace Uniplac.eAgenda.WebApp.Controllers
{

    public class CommitmentsController : ApiController
    {
        // GET: api/Commitments
        public IEnumerable<Compromisso> Get()
        {
            var dao = new CompromissoDao();
            return dao.SelecionarTodosCompromissos();
        }

        // GET: api/Commitments/5
        public Compromisso Get(int id)
        {
            var dao = new CompromissoDao();

            return dao.SelecionarCompromissoPorNumero(id);
        }

        // POST: api/Commitments
        public void Post([FromBody]Compromisso value)
        {
            var dao = new CompromissoDao();
            try
            {
                value.Valida();
            }
            catch (ApplicationException applicationException)
            {
                throw new BadRequestException(applicationException.Message);
            }


            dao.AdicionarCompromisso(value);
        }

        [HttpPut]
        public void Put(int id, [FromBody]Compromisso value)
        {
            var dao = new CompromissoDao();

            try
            {
                value.Valida();
            }
            catch (ApplicationException applicationException)
            {
                throw new BadRequestException(applicationException.Message);
            }

            dao.AtualizarCompromisso(value);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var dao = new CompromissoDao();
            Compromisso encontrado = dao.SelecionarCompromissoPorNumero(id);
            dao.ExcluirCompromisso(encontrado);
        }
    }
}