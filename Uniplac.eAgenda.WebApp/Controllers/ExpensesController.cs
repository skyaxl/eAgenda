using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Web.Http;

using Uniplac.eAgenda.Dominio.DespesaModule;
using Uniplac.eAgenda.Infraestrutura.Dao.DespesaModule;

namespace Uniplac.eAgenda.WebApp.Controllers
{
    public class ExpensesController : ApiController
    {
        private readonly DespesaDao _dao = new DespesaDao();

        // GET: api/Expenses
        public IEnumerable<Despesa> Get()
        {
            return _dao.SelecionarTodasDespesas();
        }

        // GET: api/Expenses/5
        public Despesa Get(int id)
        {
            return _dao.SelecionarDespesaPorNumero(id);
        }

        // POST: api/Expenses
        public void Post([FromBody]Despesa value)
        {

            try
            {
                value.Valida();
            }
            catch (ApplicationException applicationException)
            {
                throw new BadRequestException(applicationException.Message);
            }
            _dao.AdicionarDespesa(value);
        }

        // PUT: api/Expenses/5
        public void Put(int id, [FromBody]Despesa value)
        {

            try
            {
                value.Valida();
            }
            catch (ApplicationException applicationException)
            {
                throw new BadRequestException(applicationException.Message);
            }

            _dao.AtualizarDespesa(value);
        }

        // DELETE: api/Expenses/5
        public void Delete(int id)
        {
            var despesa = _dao.SelecionarDespesaPorNumero(id);
            _dao.ExcluirDespesa(despesa);
        }
    }
}