namespace Uniplac.eAgenda.WindowsApp.Controls.CompromissoForms
{
    partial class CompromissoDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtLocal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDataInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDataTermino = new System.Windows.Forms.DateTimePicker();
            this.chkDiaInteiro = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(376, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(295, 183);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Número:";
            // 
            // txtAssunto
            // 
            this.txtAssunto.Location = new System.Drawing.Point(101, 38);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(349, 20);
            this.txtAssunto.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Assunto:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(101, 12);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(59, 20);
            this.txtNumero.TabIndex = 7;
            // 
            // txtLocal
            // 
            this.txtLocal.Location = new System.Drawing.Point(101, 64);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(349, 20);
            this.txtLocal.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Local:";
            // 
            // cmbDataInicio
            // 
            this.cmbDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cmbDataInicio.Location = new System.Drawing.Point(101, 91);
            this.cmbDataInicio.Name = "cmbDataInicio";
            this.cmbDataInicio.Size = new System.Drawing.Size(107, 20);
            this.cmbDataInicio.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Data de início:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(224, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Data de término:";
            // 
            // cmbDataTermino
            // 
            this.cmbDataTermino.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cmbDataTermino.Location = new System.Drawing.Point(315, 91);
            this.cmbDataTermino.Name = "cmbDataTermino";
            this.cmbDataTermino.Size = new System.Drawing.Size(135, 20);
            this.cmbDataTermino.TabIndex = 15;
            // 
            // chkDiaInteiro
            // 
            this.chkDiaInteiro.AutoSize = true;
            this.chkDiaInteiro.Location = new System.Drawing.Point(101, 117);
            this.chkDiaInteiro.Name = "chkDiaInteiro";
            this.chkDiaInteiro.Size = new System.Drawing.Size(90, 17);
            this.chkDiaInteiro.TabIndex = 17;
            this.chkDiaInteiro.Text = "É dia inteiro ?";
            this.chkDiaInteiro.UseVisualStyleBackColor = true;
            // 
            // CompromissoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 218);
            this.Controls.Add(this.chkDiaInteiro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDataTermino);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDataInicio);
            this.Controls.Add(this.txtLocal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompromissoDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Compromissos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker cmbDataInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker cmbDataTermino;
        private System.Windows.Forms.CheckBox chkDiaInteiro;
    }
}