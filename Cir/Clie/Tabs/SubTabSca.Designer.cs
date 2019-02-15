namespace Cir.Clie.Tabs
{
    partial class SubTabSca
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
            this.btnNewRic = new System.Windows.Forms.Button();
            this.listViewSca = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Scadenze";
            // 
            // btnNewRic
            // 
            this.btnNewRic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRic.ForeColor = System.Drawing.Color.Black;
            this.btnNewRic.Location = new System.Drawing.Point(878, 5);
            this.btnNewRic.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewRic.Name = "btnNewRic";
            this.btnNewRic.Size = new System.Drawing.Size(110, 32);
            this.btnNewRic.TabIndex = 46;
            this.btnNewRic.Text = "Inserisci";
            this.btnNewRic.UseVisualStyleBackColor = true;
            this.btnNewRic.Click += new System.EventHandler(this.btnNewSca_Click);
            // 
            // listViewSca
            // 
            this.listViewSca.Location = new System.Drawing.Point(4, 44);
            this.listViewSca.Name = "listViewSca";
            this.listViewSca.Size = new System.Drawing.Size(984, 420);
            this.listViewSca.TabIndex = 45;
            this.listViewSca.UseCompatibleStateImageBehavior = false;
            this.listViewSca.Click += new System.EventHandler(this.listViewSca_Click);
            // 
            // SubTabSca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(992, 468);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNewRic);
            this.Controls.Add(this.listViewSca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubTabSca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SubTabSca";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.SubTabSca_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNewRic;
        private System.Windows.Forms.ListView listViewSca;
    }
}