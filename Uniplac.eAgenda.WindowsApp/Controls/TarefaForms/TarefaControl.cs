using System.Windows.Forms;
using Uniplac.eAgenda.Dominio.TarefaModule;
using Uniplac.eAgenda.WindowsApp.Controls.Shared;

namespace Uniplac.eAgenda.WindowsApp.Controls.TarefaForms
{
    public partial class TarefaControl : UserControl
    {

        private readonly ITarefaRepository _repository;
        
        public TarefaControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// É responsável por definir o repositório do UserControl
        /// Este método é chamado no constructor da classe TarefaDataManager
        ///</summary>
        /// <param name="repository"></param>
        public TarefaControl(ITarefaRepository repository) : this()
        {
            _repository = repository;
        }

        /// <summary>
        /// É responsável por retornar a tarefa que está selecionada no ListBox
        /// Esta função é chamada nos métodos EditData e DeleteData da classe TarefaDataManager
        /// </summary>
        /// <returns></returns>
        public Tarefa GetTarefa()
        {
            Tarefa t = listTarefas.SelectedItem as Tarefa;

            return _repository.SelecionarTarefaPorNumero(t.Numero);
        }

        /// <summary>
        /// É responsável por atualizar as tarefas que estão sendo mostradas no ListBox
        /// Esta função é chamada nos métodos AddData, EditData, DeleteData e na primeira vez
        /// que passa pelo método GetControl da classe TarefaDataManager
        /// </summary>
        /// <returns></returns>
        public void RefreshGrid()
        {
            var tarefas = _repository.SelecionarTodasTarefas();

            listTarefas.Items.Clear();

            foreach (var tarefa in tarefas)
            {
                listTarefas.Items.Add(tarefa);
            }
        }
    }
}