namespace Cir
{
    partial class SubMainFat
    {

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listView = new System.Windows.Forms.ListView();
            this.toolTipCli = new System.Windows.Forms.ToolTip(this.components);
            this.pickDatIni = new System.Windows.Forms.DateTimePicker();
            this.pickDatFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(5, 50);
            this.listView.Margin = new System.Windows.Forms.Padding(4);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(990, 645);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // pickDatIni
            // 
            this.pickDatIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickDatIni.Location = new System.Drawing.Point(329, 12);
            this.pickDatIni.Name = "pickDatIni";
            this.pickDatIni.Size = new System.Drawing.Size(105, 22);
            this.pickDatIni.TabIndex = 1;
            // 
            // pickDatFin
            // 
            this.pickDatFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickDatFin.Location = new System.Drawing.Point(463, 12);
            this.pickDatFin.Name = "pickDatFin";
            this.pickDatFin.Size = new System.Drawing.Size(105, 22);
            this.pickDatFin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(252, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fatture dal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(438, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "al";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(593, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(103, 32);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Aggiorna";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(709, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(96, 32);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Pag. seg.";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // SubMainFat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pickDatFin);
            this.Controls.Add(this.pickDatIni);
            this.Controls.Add(this.listView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SubMainFat";
            this.Text = "FormFat";
            this.VisibleChanged += new System.EventHandler(this.SubFormFat_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ToolTip toolTipCli;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.DateTimePicker pickDatIni;
        private System.Windows.Forms.DateTimePicker pickDatFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnNext;
    }
}