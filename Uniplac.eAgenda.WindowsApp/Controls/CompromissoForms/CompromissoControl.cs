using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniplac.eAgenda.Dominio.CompromissoModule;

namespace Uniplac.eAgenda.WindowsApp.Controls.CompromissoForms
{
    public partial class CompromissoControl : UserControl
    {
        private ICompromissoRepository _repository;

        public CompromissoControl()
        {
            InitializeComponent();
        }

        public CompromissoControl(ICompromissoRepository _repository) : this()
        {
            this._repository = _repository;
        }

        public Compromisso GetCompromisso()
        {
            Compromisso t = listCompromissos.SelectedItem as Compromisso;

            return _repository.SelecionarCompromissoPorNumero(t.Numero);
        }
       
        public void RefreshGrid()
        {
            var Compromissos = _repository.SelecionarTodosCompromissos();

            listCompromissos.Items.Clear();

            foreach (var Compromisso in Compromissos)
            {
                listCompromissos.Items.Add(Compromisso);
            }
        }
    }
}
