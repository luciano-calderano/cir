namespace Cir
{
    partial class SubMainRic
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
            this.listView = new System.Windows.Forms.ListView();
            this.checkChiuse = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIns = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(12, 35);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(976, 653);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // checkChiuse
            // 
            this.checkChiuse.AutoSize = true;
            this.checkChiuse.ForeColor = System.Drawing.Color.White;
            this.checkChiuse.Location = new System.Drawing.Point(923, 12);
            this.checkChiuse.Name = "checkChiuse";
            this.checkChiuse.Size = new System.Drawing.Size(58, 17);
            this.checkChiuse.TabIndex = 16;
            this.checkChiuse.Text = "Chiuse";
            this.checkChiuse.UseVisualStyleBackColor = true;
            this.checkChiuse.CheckedChanged += new System.EventHandler(this.checkTutte_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Richieste clienti";
            // 
            // btnIns
            // 
            this.btnIns.Location = new System.Drawing.Point(811, 6);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(75, 23);
            this.btnIns.TabIndex = 18;
            this.btnIns.Text = "Nuova";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // SubFormRic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnIns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkChiuse);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubFormRic";
            this.Text = "SubFormRic";
            this.VisibleChanged += new System.EventHandler(this.SubFormRic_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.CheckBox checkChiuse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIns;
    }
}