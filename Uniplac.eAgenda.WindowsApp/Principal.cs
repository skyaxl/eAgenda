using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniplac.eAgenda.WindowsApp.Controls.CompromissoForms;
using Uniplac.eAgenda.WindowsApp.Controls.Shared;
using Uniplac.eAgenda.WindowsApp.Controls.TarefaForms;
using Uniplac.eAgenda.WindowsApp.Properties;

namespace Uniplac.eAgenda.WindowsApp
{
    public partial class Principal : Form
    {
        private static Principal _instance;
        private DataManager _dataManager;
        private UserControl _control;

        public Principal()
        {
            InitializeComponent();
            _instance = this;
        }

        public static Principal Instance
        {
            get
            {
                return _instance;
            }
        }

        public void ShowErrorInFooter(string message)
        {
            statusMessage.Text = message;
            statusImage.Image = Resources.Symbol_Error_16x;
        }

        public void ShowSucessInFooter(string message)
        {
            statusMessage.Text = message;
            statusImage.Image = Resources.Symbol_Check_16x;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.AddData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.DeleteData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.UpdateData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnUpdateItens_Click(object sender, EventArgs e)
        {
            try
            {
                _dataManager.UpdateItens();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        /// <summary>
        /// O Método LoadDataManager() é responsável por definir o contexto de cadastro da tela principal,
        /// ou seja, quando o usuário seleciona uma opção da barra de menu, esta operação carrega o UserControl
        /// correspondente, atualiza o título da janela e também os Tooltips dos botões.
        /// </summary>
        /// <param name="manager"></param>
        private void LoadDataManager(DataManager manager)
        {
            try
            {
                if (_dataManager != null && _dataManager.GetType() == manager.GetType())
                    return;

                if (_control != null)
                {
                    panelPrincipal.Controls.Clear();
                }

                statusImage.Image = null;
                statusMessage.Text = "";

                _dataManager = manager;

                _control = _dataManager.GetControl();

                _control.Dock = DockStyle.Fill;

                panelPrincipal.Controls.Add(_control);

                labelTipoCadastro.Text = "Operação selecionada: " + _dataManager.GetDescription();

                
                btnAdd.ToolTipText = _dataManager.GetToolTipMessage().Add;
                btnUpdateItens.ToolTipText = _dataManager.GetToolTipMessage().EditItens;
                btnUpdate.ToolTipText = _dataManager.GetToolTipMessage().Edit;
                btnDelete.ToolTipText = _dataManager.GetToolTipMessage().Delete;                

                btnAdd.Enabled = _dataManager.GetStateButtons().Add;
                btnUpdateItens.Enabled = _dataManager.GetStateButtons().UpdateItens;
                btnUpdate.Enabled = _dataManager.GetStateButtons().Update;
                btnDelete.Enabled = _dataManager.GetStateButtons().Delete;


                toolbar.Enabled = _dataManager != null;
            }
            catch (Exception be)
            {
                MessageBox.Show(be.Message);
            }
        }

        private void tarefasMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new TarefaDataManager());
        }

        private void compromissosMenuItem_Click(object sender, EventArgs e)
        {
            LoadDataManager(new CompromissoDataManager());
        }

        
       

       




    }
}
