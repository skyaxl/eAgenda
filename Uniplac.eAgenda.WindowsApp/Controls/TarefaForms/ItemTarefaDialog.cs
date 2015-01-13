using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniplac.eAgenda.Dominio.TarefaModule;

namespace Uniplac.eAgenda.WindowsApp.Controls.TarefaForms
{
    public partial class ItemTarefaDialog : Form
    {
        private Tarefa _tarefa;


        public ItemTarefaDialog()
        {
            InitializeComponent();
        }

        public Tarefa Tarefa
        {
            get { return _tarefa; }

            set
            {
                _tarefa = value;

                tituloTarefa.Text = _tarefa.Titulo;

                AtualizaPercentual();

                for (int i = 0; i < _tarefa.ItensExecucacao.Count; i++)
                {
                    ItemTarefa item = _tarefa.ItensExecucacao[i];

                    listTarefas.Items.Add(_tarefa.ItensExecucacao[i]);

                    listTarefas.SetItemCheckState(i, item.EstaFechado() ? CheckState.Checked : CheckState.Unchecked);
                }
            }
        }

        private void AtualizaPercentual()
        {
            percentualTarefa.Text = _tarefa.Percentual.ToString();
        }

        private void listTarefas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var items = listTarefas.Items;

            ItemTarefa itemSelecionado = _tarefa.ItensExecucacao[e.Index];

            _tarefa.AtualizarPercentual(itemSelecionado.Numero, e.NewValue == CheckState.Checked ? 100 : 0 );

            AtualizaPercentual();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            

        }
    }
}
