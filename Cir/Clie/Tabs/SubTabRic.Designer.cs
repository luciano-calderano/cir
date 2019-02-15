namespace Cir.Clie.Tabs
{
    partial class SubTabRic
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
            this.listViewRic = new System.Windows.Forms.ListView();
            this.btnNewRic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxClosed = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listViewRic
            // 
            this.listViewRic.Location = new System.Drawing.Point(4, 44);
            this.listViewRic.Name = "listViewRic";
            this.listViewRic.Size = new System.Drawing.Size(984, 420);
            this.listViewRic.TabIndex = 0;
            this.listViewRic.UseCompatibleStateImageBehavior = false;
            this.listViewRic.Click += new System.EventHandler(this.listViewRic_Click);
            // 
            // btnNewRic
            // 
            this.btnNewRic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRic.ForeColor = System.Drawing.Color.Black;
            this.btnNewRic.Location = new System.Drawing.Point(878, 3);
            this.btnNewRic.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewRic.Name = "btnNewRic";
            this.btnNewRic.Size = new System.Drawing.Size(110, 32);
            this.btnNewRic.TabIndex = 42;
            this.btnNewRic.Text = "Inserisci";
            this.btnNewRic.UseVisualStyleBackColor = true;
            this.btnNewRic.Click += new System.EventHandler(this.btnNewRic_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 43;
            this.label1.Text = "Richieste";
            // 
            // checkBoxClosed
            // 
            this.checkBoxClosed.AutoSize = true;
            this.checkBoxClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxClosed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxClosed.Location = new System.Drawing.Point(100, 10);
            this.checkBoxClosed.Name = "checkBoxClosed";
            this.checkBoxClosed.Size = new System.Drawing.Size(70, 19);
            this.checkBoxClosed.TabIndex = 44;
            this.checkBoxClosed.Text = "Chiuse";
            this.checkBoxClosed.UseVisualStyleBackColor = true;
            this.checkBoxClosed.CheckedChanged += new System.EventHandler(this.checkBoxClosed_CheckedChanged);
            // 
            // SubTabRic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(992, 468);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxClosed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewRic);
            this.Controls.Add(this.listViewRic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubTabRic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CliTabRic";
            this.VisibleChanged += new System.EventHandler(this.SubTabRic_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewRic;
        private System.Windows.Forms.Button btnNewRic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxClosed;
    }
}