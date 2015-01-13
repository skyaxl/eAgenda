using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Web.Http;

using Uniplac.eAgenda.Dominio.TarefaModule;
using Uniplac.eAgenda.Infraestrutura.Dao.TarefaModule;

namespace Uniplac.eAgenda.WebApp.Controllers
{
    public class TasksController : ApiController
    {
        private readonly TarefaDao _repository = new TarefaDao();

        public IEnumerable<Tarefa> Get()
        {
            return _repository.SelecionarTodasTarefas();
        }

        // GET: api/Tasks/5
        public Tarefa Get(int id)
        {
            var task = _repository.SelecionarTarefaPorNumero(id);
            if (task.ItensExecucacao != null)
                task.ItensExecucacao.ForEach(item => item.Tarefa = null);
            return task;
        }

        // POST: api/Tasks
        public void Post([FromBody]Tarefa value)
        {
            value.ItensExecucacao.ForEach(item => item.Tarefa = value);

            try
            {
                value.Valida();
            }
            catch (ApplicationException applicationException)
            {
                throw new BadRequestException(applicationException.Message);
            }

            _repository.AdicionarTarefa(value);
        }

        [HttpPut]
        public void Put(int id, [FromBody]Tarefa value)
        {
            value.ItensExecucacao.ForEach(item => item.Tarefa = value);

            try
            {
                value.Valida();
            }
            catch (ApplicationException applicationException)
            {
                throw new BadRequestException(applicationException.Message);
            }

            _repository.AtualizarTarefa(value);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Tarefa tarefa = _repository.SelecionarTarefaPorNumero(id);
            _repository.ExcluirTarefa(tarefa);
        }
    }
}