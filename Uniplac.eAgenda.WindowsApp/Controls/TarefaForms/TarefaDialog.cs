using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Uniplac.eAgenda.Dominio.TarefaModule;

namespace Uniplac.eAgenda.WindowsApp.Controls.TarefaForms
{
    public partial class TarefaDialog : Form
    {
        private Tarefa _tarefa;

        public TarefaDialog()
        {
            InitializeComponent();            
        }       

        public Tarefa Tarefa
        {
            get { return _tarefa; }

            set
            {
                _tarefa = value;

                if(_tarefa.Numero > 0)
                    EditandoTarefa();
                
                txtNumero.Text = _tarefa.Numero.ToString();
                txtTitulo.Text = _tarefa.Titulo;
                cmbDataConclusao.Value = _tarefa.DataConclusao;
                txtPrioridade.Text = _tarefa.Prioridade.ToString();                
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {                
                _tarefa.Numero = Convert.ToInt32( txtNumero.Text );
                _tarefa.Titulo = txtTitulo.Text;
                _tarefa.DataConclusao = cmbDataConclusao.Value;
                _tarefa.Prioridade = Convert.ToInt32(txtPrioridade.Text);

                _tarefa.Valida();

                Principal.Instance.ShowSucessInFooter(string.Format("A tarefa \"{0}\" foi salva com sucesso", _tarefa.Titulo));
                 
            }
            catch(Exception exc)
            {
                Principal.Instance.ShowErrorInFooter(exc.Message);

                DialogResult = DialogResult.None;
            }

        }

        private void contextMenuItens_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Excluir")
            {                
                listItensTarefa.Items.Remove(listItensTarefa.SelectedItem);

                ItemTarefa item = (ItemTarefa)listItensTarefa.SelectedItem;

                _tarefa.RemoveItemExecucao(item);
            }
        }

        private void btnAdicionaItem_Click(object sender, EventArgs e)
        {
            ItemTarefa item = new ItemTarefa();
            item.Titulo = txtItemTarefa.Text;

            listItensTarefa.Items.Add(item);

            _tarefa.AdicionaItemExecucao(item);
        }

        private void EditandoTarefa()
        {
            panelItensTarefa.Visible = false;
            Height = 188;
        }
    }
}