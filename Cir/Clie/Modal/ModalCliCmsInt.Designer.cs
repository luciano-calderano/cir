namespace Cir.Modal
{
    partial class ModalCliCmsInt
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
            this.listViewInt = new System.Windows.Forms.ListView();
            this.btnStampa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewInt
            // 
            this.listViewInt.Location = new System.Drawing.Point(12, 45);
            this.listViewInt.Name = "listViewInt";
            this.listViewInt.Size = new System.Drawing.Size(907, 459);
            this.listViewInt.TabIndex = 0;
            this.listViewInt.UseCompatibleStateImageBehavior = false;
            // 
            // btnStampa
            // 
            this.btnStampa.Location = new System.Drawing.Point(843, 13);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(75, 23);
            this.btnStampa.TabIndex = 1;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // ModalCliCmsInt
            // 
            this.ClientSize = new System.Drawing.Size(931, 516);
            this.Controls.Add(this.btnStampa);
            this.Controls.Add(this.listViewInt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModalCliCmsInt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Interventi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewInt;
        private System.Windows.Forms.Button btnStampa;
    }
}