namespace Cir.SubForm
{
    partial class SubMainScaden
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbScadenTip = new System.Windows.Forms.ComboBox();
            this.comboZone = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.Location = new System.Drawing.Point(13, 52);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(975, 636);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo";
            // 
            // cmbScadenTip
            // 
            this.cmbScadenTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbScadenTip.FormattingEnabled = true;
            this.cmbScadenTip.Location = new System.Drawing.Point(58, 16);
            this.cmbScadenTip.Name = "cmbScadenTip";
            this.cmbScadenTip.Size = new System.Drawing.Size(354, 23);
            this.cmbScadenTip.TabIndex = 2;
            this.cmbScadenTip.SelectedIndexChanged += new System.EventHandler(this.cmbScadenTip_SelectedIndexChanged);
            // 
            // comboZone
            // 
            this.comboZone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboZone.FormattingEnabled = true;
            this.comboZone.Location = new System.Drawing.Point(818, 16);
            this.comboZone.Name = "comboZone";
            this.comboZone.Size = new System.Drawing.Size(170, 23);
            this.comboZone.TabIndex = 6;
            this.comboZone.SelectedIndexChanged += new System.EventHandler(this.comboZone_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(773, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zona";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(431, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(108, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Pagina seguente";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // SubMainScaden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.comboZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbScadenTip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubMainScaden";
            this.Text = "SubFormScaden";
            this.VisibleChanged += new System.EventHandler(this.SubFormScaden_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbScadenTip;
        private System.Windows.Forms.ComboBox comboZone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
    }
}