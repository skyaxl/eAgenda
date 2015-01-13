namespace Uniplac.eAgenda.WindowsApp.Controls.TarefaForms
{
    partial class ItemTarefaDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.tituloTarefa = new System.Windows.Forms.Label();
            this.percentualTarefa = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listTarefas = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarefa:";
            // 
            // tituloTarefa
            // 
            this.tituloTarefa.AutoSize = true;
            this.tituloTarefa.Location = new System.Drawing.Point(54, 13);
            this.tituloTarefa.Name = "tituloTarefa";
            this.tituloTarefa.Size = new System.Drawing.Size(35, 13);
            this.tituloTarefa.TabIndex = 1;
            this.tituloTarefa.Text = "label2";
            // 
            // percentualTarefa
            // 
            this.percentualTarefa.AutoSize = true;
            this.percentualTarefa.Location = new System.Drawing.Point(131, 35);
            this.percentualTarefa.Name = "percentualTarefa";
            this.percentualTarefa.Size = new System.Drawing.Size(35, 13);
            this.percentualTarefa.TabIndex = 3;
            this.percentualTarefa.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Percentual concluído:";
            // 
            // listTarefas
            // 
            this.listTarefas.FormattingEnabled = true;
            this.listTarefas.Location = new System.Drawing.Point(16, 60);
            this.listTarefas.Name = "listTarefas";
            this.listTarefas.Size = new System.Drawing.Size(453, 184);
            this.listTarefas.TabIndex = 4;
            this.listTarefas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listTarefas_ItemCheck);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(394, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(313, 267);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // ItemTarefaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 302);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.listTarefas);
            this.Controls.Add(this.percentualTarefa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tituloTarefa);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemTarefaDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizando os percentuais da tarefa...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tituloTarefa;
        private System.Windows.Forms.Label percentualTarefa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox listTarefas;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}