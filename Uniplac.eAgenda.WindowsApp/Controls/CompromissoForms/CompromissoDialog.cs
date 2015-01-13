using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniplac.eAgenda.Dominio.CompromissoModule;

namespace Uniplac.eAgenda.WindowsApp.Controls.CompromissoForms
{
    public partial class CompromissoDialog : Form
    {
        private Compromisso _compromisso;
      
        public CompromissoDialog()
        {
            InitializeComponent();
        }

        public Compromisso Compromisso
        {
            get
            {
                return _compromisso;
            }
            set
            {
                _compromisso = value;

                txtNumero.Text = _compromisso.Numero.ToString();
                txtAssunto.Text = _compromisso.Assunto;
                txtLocal.Text = _compromisso.Local;
                cmbDataInicio.Value = _compromisso.DataInicio;
                cmbDataTermino.Value = _compromisso.DataTermino.HasValue ? _compromisso.DataTermino.Value : DateTime.Now;

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _compromisso.Numero = Convert.ToInt32( txtNumero.Text );

                _compromisso.Assunto = txtAssunto.Text;

                _compromisso.Local = txtLocal.Text;

                _compromisso.DataInicio = cmbDataInicio.Value;

                _compromisso.DataTermino = cmbDataTermino.Value;

                _compromisso.DiaInteiro = chkDiaInteiro.Checked;

                _compromisso.Valida();

            }
            catch (Exception exc)
            {
                Principal.Instance.ShowErrorInFooter(exc.Message);

                DialogResult = DialogResult.None;
            }
        }

    }
}