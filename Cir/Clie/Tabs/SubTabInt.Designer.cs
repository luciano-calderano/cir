namespace Cir.Clie.Tabs
{
    partial class SubTabInt
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
            this.cmbIntTip = new System.Windows.Forms.ComboBox();
            this.btnNewInt = new System.Windows.Forms.Button();
            this.listViewInt = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateIniz = new System.Windows.Forms.DateTimePicker();
            this.dateFine = new System.Windows.Forms.DateTimePicker();
            this.btnReload = new System.Windows.Forms.Button();
            this.comboCms = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbIntTip
            // 
            this.cmbIntTip.FormattingEnabled = true;
            this.cmbIntTip.Location = new System.Drawing.Point(4, 20);
            this.cmbIntTip.Name = "cmbIntTip";
            this.cmbIntTip.Size = new System.Drawing.Size(241, 21);
            this.cmbIntTip.TabIndex = 45;
            this.cmbIntTip.SelectedIndexChanged += new System.EventHandler(this.cmbIntTip_SelectedIndexChanged);
            // 
            // btnNewInt
            // 
            this.btnNewInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewInt.ForeColor = System.Drawing.Color.Black;
            this.btnNewInt.Location = new System.Drawing.Point(878, 13);
            this.btnNewInt.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewInt.Name = "btnNewInt";
            this.btnNewInt.Size = new System.Drawing.Size(110, 32);
            this.btnNewInt.TabIndex = 41;
            this.btnNewInt.Text = "Inserisci";
            this.btnNewInt.UseVisualStyleBackColor = true;
            this.btnNewInt.Click += new System.EventHandler(this.btnNewInt_Click);
            // 
            // listViewInt
            // 
            this.listViewInt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewInt.Location = new System.Drawing.Point(4, 48);
            this.listViewInt.Margin = new System.Windows.Forms.Padding(4);
            this.listViewInt.Name = "listViewInt";
            this.listViewInt.Size = new System.Drawing.Size(984, 416);
            this.listViewInt.TabIndex = 31;
            this.listViewInt.UseCompatibleStateImageBehavior = false;
            this.listViewInt.Click += new System.EventHandler(this.listViewInt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Tipo intervento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(576, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "dal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(679, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "al";
            // 
            // dateIniz
            // 
            this.dateIniz.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateIniz.Location = new System.Drawing.Point(579, 20);
            this.dateIniz.Name = "dateIniz";
            this.dateIniz.Size = new System.Drawing.Size(93, 20);
            this.dateIniz.TabIndex = 48;
            // 
            // dateFine
            // 
            this.dateFine.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFine.Location = new System.Drawing.Point(682, 20);
            this.dateFine.Name = "dateFine";
            this.dateFine.Size = new System.Drawing.Size(93, 20);
            this.dateFine.TabIndex = 49;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(781, 18);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 50;
            this.btnReload.Text = "Aggiorna";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // comboCms
            // 
            this.comboCms.FormattingEnabled = true;
            this.comboCms.Location = new System.Drawing.Point(277, 20);
            this.comboCms.Name = "comboCms";
            this.comboCms.Size = new System.Drawing.Size(241, 21);
            this.comboCms.TabIndex = 52;
            this.comboCms.SelectedIndexChanged += new System.EventHandler(this.comboCms_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(274, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Filtra commessa/contratto";
            // 
            // SubTabInt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(992, 468);
            this.Controls.Add(this.comboCms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.dateFine);
            this.Controls.Add(this.dateIniz);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNewInt);
            this.Controls.Add(this.cmbIntTip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewInt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubTabInt";
            this.VisibleChanged += new System.EventHandler(this.SubTabInt_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbIntTip;
        private System.Windows.Forms.Button btnNewInt;
        private System.Windows.Forms.ListView listViewInt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateIniz;
        private System.Windows.Forms.DateTimePicker dateFine;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ComboBox comboCms;
        private System.Windows.Forms.Label label4;
    }
}
