using System;
using System.Windows.Forms;
using Uniplac.eAgenda.Dominio.TarefaModule;
using Uniplac.eAgenda.Infraestrutura.Dao.TarefaModule;
using Uniplac.eAgenda.WindowsApp.Controls.Shared;

namespace Uniplac.eAgenda.WindowsApp.Controls.TarefaForms
{
    public class TarefaDataManager : DataManager
    {
        private ITarefaRepository _repository;

        private TarefaControl _control;

        public TarefaDataManager()
        {
            _repository = new TarefaDao();
            _control = new TarefaControl(_repository);
        }


        public override void AddData()
        {
            var dialog = new TarefaDialog();
            dialog.Tarefa = new Tarefa();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _repository.AdicionarTarefa(dialog.Tarefa);
                _control.RefreshGrid();
            }
        }

        public override void UpdateData()
        {
            Tarefa tarefa = _control.GetTarefa();

            if (tarefa == null)
            {
                MessageBox.Show("Nenhum tarefa selecionada. Selecione uma tarefa antes de solicitar a edição");
                return;
            }

            var dialog = new TarefaDialog();
            dialog.Tarefa = tarefa;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _repository.AtualizarTarefa(dialog.Tarefa);
                _control.RefreshGrid();
            }
        }

        public override void DeleteData()
        {
            Tarefa tarefa = _control.GetTarefa();

            if (tarefa == null)
            {
                MessageBox.Show("Nenhuma tarefa selecionada. Selecione uma tarefa antes de solicitar a exclusão");
                return;
            }
            if (MessageBox.Show("Deseja remover a tarefa selecionada?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    _repository.ExcluirTarefa(tarefa);
                    _control.RefreshGrid();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public override UserControl GetControl()
        {
            if (_control != null)
                _control.RefreshGrid();

            return _control;
        }

        public override string GetDescription()
        {
            return "Cadastro de Tarefas";
        }

        public override ToolTipMessage GetToolTipMessage()
        {
            return new ToolTipMessage
                       {
                           Add = "Adiciona uma nova tarefa",
                           Delete = "Exclui a tarefa selecionada",
                           Edit = "Atualiza a tarefa selecionada",
                           EditItens = "Atualiza o percentual dos itens da tarefa"
                       };
        }

        public override StateButtons GetStateButtons()
        {
            return new StateButtons
            {
                Add = true,
                Delete = true,
                Update = true,
                UpdateItens = true
            };
        }


        public override void UpdateItens()
        {
            Tarefa tarefa = _control.GetTarefa();

            if (tarefa == null)
            {
                MessageBox.Show("Nenhuma tarefa selecionada. Selecione um tarefa antes de solicitar a atualização dos percentuais");
                return;
            }

            var dialog = new ItemTarefaDialog();
            dialog.Tarefa = tarefa;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _repository.AtualizarTarefa(dialog.Tarefa);
                _control.RefreshGrid();
            }
        }

    }
}