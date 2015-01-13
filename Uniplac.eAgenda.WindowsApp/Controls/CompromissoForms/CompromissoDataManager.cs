using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniplac.eAgenda.Dominio.CompromissoModule;
using Uniplac.eAgenda.Infraestrutura.Dao.CompromissoModule;
using Uniplac.eAgenda.WindowsApp.Controls.Shared;

namespace Uniplac.eAgenda.WindowsApp.Controls.CompromissoForms
{
    public class CompromissoDataManager : DataManager
    {
        private ICompromissoRepository _repository;

        private CompromissoControl _control;

        public CompromissoDataManager()
        {
            _repository = new CompromissoDao();
            _control = new CompromissoControl(_repository);
        }

        public override void AddData()
        {
            var dialog = new CompromissoDialog();
            dialog.Compromisso = new Compromisso();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _repository.AdicionarCompromisso(dialog.Compromisso);
                _control.RefreshGrid();
            }
        }       

        public override void UpdateData()
        {
            Compromisso Compromisso = _control.GetCompromisso();

            if (Compromisso == null)
            {
                MessageBox.Show("Nenhum compromisso selecionado. Selecionar um compromisso antes de solicitar a edição");
                return;
            }

            var dialog = new CompromissoDialog();
            dialog.Compromisso = Compromisso;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _repository.AtualizarCompromisso(dialog.Compromisso);
                _control.RefreshGrid();
            }
        }

        public override void DeleteData()
        {
            Compromisso Compromisso = _control.GetCompromisso();

            if (Compromisso == null)
            {
                MessageBox.Show("Nenhum compromisso selecionado. Selecione um compromisso antes de solicitar a exclusão");
                return;
            }
            if (MessageBox.Show("Deseja remover o compromisso selecionado?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                try
                {
                    _repository.ExcluirCompromisso(Compromisso);
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
            return "Cadastro de Compromissos";
        }

        public override ToolTipMessage GetToolTipMessage()
        {
            return new ToolTipMessage
            {
                Add = "Adiciona um novo compromisso",
                Delete = "Exclui o compromisso selecionado",
                Edit = "Atualiza o compromisso selecionado"                
            };
        }

        public override StateButtons GetStateButtons()
        {
            return new StateButtons
            {
                Add = true,
                Delete = true,
                Update = true
            };
        }

    }
}
