namespace Uniplac.eAgenda.WindowsApp.Controls.TarefaForms
{
    partial class TarefaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listTarefas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listTarefas
            // 
            this.listTarefas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTarefas.FormattingEnabled = true;
            this.listTarefas.Location = new System.Drawing.Point(0, 0);
            this.listTarefas.Name = "listTarefas";
            this.listTarefas.Size = new System.Drawing.Size(323, 262);
            this.listTarefas.TabIndex = 0;
            // 
            // TarefaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listTarefas);
            this.Name = "TarefaControl";
            this.Size = new System.Drawing.Size(323, 262);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listTarefas;
    }
}
