namespace Uniplac.eAgenda.WindowsApp.Controls.TarefaForms
{
    partial class TarefaDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDataConclusao = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.panelItensTarefa = new System.Windows.Forms.GroupBox();
            this.listItensTarefa = new System.Windows.Forms.ListBox();
            this.txtItemTarefa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdicionaItem = new System.Windows.Forms.Button();
            this.contextMenuItens = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItensExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPrioridade = new System.Windows.Forms.TextBox();
            this.panelItensTarefa.SuspendLayout();
            this.contextMenuItens.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(292, 315);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(373, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(99, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(59, 20);
            this.txtNumero.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Título:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(99, 45);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(349, 20);
            this.txtTitulo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Número:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data Conclusão:";
            // 
            // cmbDataConclusao
            // 
            this.cmbDataConclusao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbDataConclusao.Location = new System.Drawing.Point(99, 74);
            this.cmbDataConclusao.Name = "cmbDataConclusao";
            this.cmbDataConclusao.Size = new System.Drawing.Size(131, 20);
            this.cmbDataConclusao.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Prioridade:";
            // 
            // panelItensTarefa
            // 
            this.panelItensTarefa.Controls.Add(this.btnAdicionaItem);
            this.panelItensTarefa.Controls.Add(this.label4);
            this.panelItensTarefa.Controls.Add(this.txtItemTarefa);
            this.panelItensTarefa.Controls.Add(this.listItensTarefa);
            this.panelItensTarefa.Location = new System.Drawing.Point(15, 107);
            this.panelItensTarefa.Name = "panelItensTarefa";
            this.panelItensTarefa.Size = new System.Drawing.Size(433, 197);
            this.panelItensTarefa.TabIndex = 25;
            this.panelItensTarefa.TabStop = false;
            this.panelItensTarefa.Text = "Itens da Tarefa";
            // 
            // listItensTarefa
            // 
            this.listItensTarefa.ContextMenuStrip = this.contextMenuItens;
            this.listItensTarefa.FormattingEnabled = true;
            this.listItensTarefa.Location = new System.Drawing.Point(6, 58);
            this.listItensTarefa.Name = "listItensTarefa";
            this.listItensTarefa.Size = new System.Drawing.Size(414, 134);
            this.listItensTarefa.TabIndex = 0;
            // 
            // txtItemTarefa
            // 
            this.txtItemTarefa.Location = new System.Drawing.Point(88, 23);
            this.txtItemTarefa.Name = "txtItemTarefa";
            this.txtItemTarefa.Size = new System.Drawing.Size(242, 20);
            this.txtItemTarefa.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Título do Item:";
            // 
            // btnAdicionaItem
            // 
            this.btnAdicionaItem.Location = new System.Drawing.Point(345, 20);
            this.btnAdicionaItem.Name = "btnAdicionaItem";
            this.btnAdicionaItem.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionaItem.TabIndex = 26;
            this.btnAdicionaItem.Text = "Adicionar";
            this.btnAdicionaItem.UseVisualStyleBackColor = true;
            this.btnAdicionaItem.Click += new System.EventHandler(this.btnAdicionaItem_Click);
            // 
            // contextMenuItens
            // 
            this.contextMenuItens.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItensExcluir});
            this.contextMenuItens.Name = "contextMenuItens";
            this.contextMenuItens.Size = new System.Drawing.Size(109, 26);
            this.contextMenuItens.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuItens_ItemClicked);
            // 
            // menuItensExcluir
            // 
            this.menuItensExcluir.Name = "menuItensExcluir";
            this.menuItensExcluir.Size = new System.Drawing.Size(108, 22);
            this.menuItensExcluir.Text = "Excluir";
            // 
            // txtPrioridade
            // 
            this.txtPrioridade.Location = new System.Drawing.Point(317, 73);
            this.txtPrioridade.Name = "txtPrioridade";
            this.txtPrioridade.Size = new System.Drawing.Size(131, 20);
            this.txtPrioridade.TabIndex = 27;
            this.txtPrioridade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TarefaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 348);
            this.ControlBox = false;
            this.Controls.Add(this.txtPrioridade);
            this.Controls.Add(this.panelItensTarefa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDataConclusao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TarefaDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Tarefas";
            this.panelItensTarefa.ResumeLayout(false);
            this.panelItensTarefa.PerformLayout();
            this.contextMenuItens.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker cmbDataConclusao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox panelItensTarefa;
        private System.Windows.Forms.ListBox listItensTarefa;
        private System.Windows.Forms.Button btnAdicionaItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtItemTarefa;
        private System.Windows.Forms.ContextMenuStrip contextMenuItens;
        private System.Windows.Forms.ToolStripMenuItem menuItensExcluir;
        private System.Windows.Forms.TextBox txtPrioridade;
    }
}