namespace Cir.SubForm
{
    partial class ModalFormInterv
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.datePickerDatIni = new System.Windows.Forms.DateTimePicker();
            this.comboOraIni = new System.Windows.Forms.ComboBox();
            this.comboOraIniMin = new System.Windows.Forms.ComboBox();
            this.comboOraFinMin = new System.Windows.Forms.ComboBox();
            this.comboOraFin = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboTip = new System.Windows.Forms.ComboBox();
            this.comboNumOpe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescri = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblFat = new System.Windows.Forms.Label();
            this.comboCms = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTot = new System.Windows.Forms.Label();
            this.lblCmsImp = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.lblCms_id = new System.Windows.Forms.Label();
            this.btnTec = new System.Windows.Forms.Button();
            this.listBoxTec = new System.Windows.Forms.ListBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data intervento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "alle ore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dalle ore";
            // 
            // datePickerDatIni
            // 
            this.datePickerDatIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerDatIni.Location = new System.Drawing.Point(119, 13);
            this.datePickerDatIni.Margin = new System.Windows.Forms.Padding(4);
            this.datePickerDatIni.Name = "datePickerDatIni";
            this.datePickerDatIni.Size = new System.Drawing.Size(97, 22);
            this.datePickerDatIni.TabIndex = 5;
            // 
            // comboOraIni
            // 
            this.comboOraIni.FormattingEnabled = true;
            this.comboOraIni.Items.AddRange(new object[] {
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.comboOraIni.Location = new System.Drawing.Point(119, 44);
            this.comboOraIni.Margin = new System.Windows.Forms.Padding(4);
            this.comboOraIni.Name = "comboOraIni";
            this.comboOraIni.Size = new System.Drawing.Size(45, 24);
            this.comboOraIni.TabIndex = 8;
            this.comboOraIni.Text = "07";
            this.comboOraIni.SelectedIndexChanged += new System.EventHandler(this.comboOraIni_SelectedIndexChanged);
            // 
            // comboOraIniMin
            // 
            this.comboOraIniMin.FormattingEnabled = true;
            this.comboOraIniMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.comboOraIniMin.Location = new System.Drawing.Point(173, 44);
            this.comboOraIniMin.Margin = new System.Windows.Forms.Padding(4);
            this.comboOraIniMin.Name = "comboOraIniMin";
            this.comboOraIniMin.Size = new System.Drawing.Size(45, 24);
            this.comboOraIniMin.TabIndex = 9;
            this.comboOraIniMin.Text = "00";
            this.comboOraIniMin.SelectedIndexChanged += new System.EventHandler(this.comboOraIniMin_SelectedIndexChanged);
            // 
            // comboOraFinMin
            // 
            this.comboOraFinMin.FormattingEnabled = true;
            this.comboOraFinMin.Items.AddRange(new object[] {
            "00",
            "15",
            "30",
            "45"});
            this.comboOraFinMin.Location = new System.Drawing.Point(173, 76);
            this.comboOraFinMin.Margin = new System.Windows.Forms.Padding(4);
            this.comboOraFinMin.Name = "comboOraFinMin";
            this.comboOraFinMin.Size = new System.Drawing.Size(45, 24);
            this.comboOraFinMin.TabIndex = 11;
            this.comboOraFinMin.Text = "00";
            this.comboOraFinMin.SelectedIndexChanged += new System.EventHandler(this.comboOraFinMin_SelectedIndexChanged);
            // 
            // comboOraFin
            // 
            this.comboOraFin.FormattingEnabled = true;
            this.comboOraFin.Items.AddRange(new object[] {
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.comboOraFin.Location = new System.Drawing.Point(119, 76);
            this.comboOraFin.Margin = new System.Windows.Forms.Padding(4);
            this.comboOraFin.Name = "comboOraFin";
            this.comboOraFin.Size = new System.Drawing.Size(45, 24);
            this.comboOraFin.TabIndex = 10;
            this.comboOraFin.Text = "07";
            this.comboOraFin.SelectedIndexChanged += new System.EventHandler(this.comboOraFin_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 289);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tecnici";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 156);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tipo intervento";
            // 
            // comboTip
            // 
            this.comboTip.FormattingEnabled = true;
            this.comboTip.Location = new System.Drawing.Point(119, 153);
            this.comboTip.Margin = new System.Windows.Forms.Padding(4);
            this.comboTip.Name = "comboTip";
            this.comboTip.Size = new System.Drawing.Size(273, 24);
            this.comboTip.TabIndex = 15;
            this.comboTip.SelectedIndexChanged += new System.EventHandler(this.comboTip_SelectedIndexChanged);
            // 
            // comboNumOpe
            // 
            this.comboNumOpe.FormattingEnabled = true;
            this.comboNumOpe.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboNumOpe.Location = new System.Drawing.Point(119, 385);
            this.comboNumOpe.Margin = new System.Windows.Forms.Padding(4);
            this.comboNumOpe.Name = "comboNumOpe";
            this.comboNumOpe.Size = new System.Drawing.Size(47, 24);
            this.comboNumOpe.TabIndex = 17;
            this.comboNumOpe.Text = "1";
            this.comboNumOpe.SelectedIndexChanged += new System.EventHandler(this.comboNumOpe_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 388);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Num. operai";
            // 
            // txtDescri
            // 
            this.txtDescri.Location = new System.Drawing.Point(433, 36);
            this.txtDescri.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescri.Name = "txtDescri";
            this.txtDescri.Size = new System.Drawing.Size(482, 93);
            this.txtDescri.TabIndex = 18;
            this.txtDescri.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(430, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Descrizione intervento";
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Green;
            this.btnOk.Location = new System.Drawing.Point(786, 401);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(129, 49);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Conferma";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblFat
            // 
            this.lblFat.AutoSize = true;
            this.lblFat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFat.Location = new System.Drawing.Point(430, 348);
            this.lblFat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFat.Name = "lblFat";
            this.lblFat.Size = new System.Drawing.Size(45, 15);
            this.lblFat.TabIndex = 21;
            this.lblFat.Text = "Fattura";
            // 
            // comboCms
            // 
            this.comboCms.FormattingEnabled = true;
            this.comboCms.Location = new System.Drawing.Point(25, 207);
            this.comboCms.Margin = new System.Windows.Forms.Padding(4);
            this.comboCms.Name = "comboCms";
            this.comboCms.Size = new System.Drawing.Size(367, 24);
            this.comboCms.TabIndex = 28;
            this.comboCms.SelectedIndexChanged += new System.EventHandler(this.comboCms_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 188);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Commessa / Contratto / Preventivo";
            // 
            // lblTot
            // 
            this.lblTot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTot.Location = new System.Drawing.Point(730, 347);
            this.lblTot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(185, 16);
            this.lblTot.TabIndex = 32;
            this.lblTot.Text = "lblTot";
            this.lblTot.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCmsImp
            // 
            this.lblCmsImp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCmsImp.Location = new System.Drawing.Point(207, 235);
            this.lblCmsImp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCmsImp.Name = "lblCmsImp";
            this.lblCmsImp.Size = new System.Drawing.Size(185, 16);
            this.lblCmsImp.TabIndex = 33;
            this.lblCmsImp.Text = "lblCmsImp";
            this.lblCmsImp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDel.Location = new System.Drawing.Point(433, 401);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(129, 49);
            this.btnDel.TabIndex = 34;
            this.btnDel.Text = "Elimina";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblCms_id
            // 
            this.lblCms_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCms_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCms_id.ForeColor = System.Drawing.Color.Gray;
            this.lblCms_id.Location = new System.Drawing.Point(340, 194);
            this.lblCms_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCms_id.Name = "lblCms_id";
            this.lblCms_id.Size = new System.Drawing.Size(52, 10);
            this.lblCms_id.TabIndex = 36;
            this.lblCms_id.Text = "0";
            this.lblCms_id.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnTec
            // 
            this.btnTec.Location = new System.Drawing.Point(301, 307);
            this.btnTec.Name = "btnTec";
            this.btnTec.Size = new System.Drawing.Size(91, 28);
            this.btnTec.TabIndex = 38;
            this.btnTec.Text = "Seleziona";
            this.btnTec.UseVisualStyleBackColor = true;
            this.btnTec.Click += new System.EventHandler(this.btnTec_Click);
            // 
            // listBoxTec
            // 
            this.listBoxTec.FormattingEnabled = true;
            this.listBoxTec.ItemHeight = 16;
            this.listBoxTec.Location = new System.Drawing.Point(25, 307);
            this.listBoxTec.Name = "listBoxTec";
            this.listBoxTec.Size = new System.Drawing.Size(270, 68);
            this.listBoxTec.TabIndex = 37;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(433, 146);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(482, 189);
            this.dataGrid.TabIndex = 39;
            this.dataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEnter);
            this.dataGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellLeave);
            // 
            // ModalFormInterv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 463);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btnTec);
            this.Controls.Add(this.listBoxTec);
            this.Controls.Add(this.lblCms_id);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lblCmsImp);
            this.Controls.Add(this.lblTot);
            this.Controls.Add(this.comboCms);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblFat);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDescri);
            this.Controls.Add(this.comboNumOpe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboTip);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboOraFinMin);
            this.Controls.Add(this.comboOraFin);
            this.Controls.Add(this.comboOraIniMin);
            this.Controls.Add(this.comboOraIni);
            this.Controls.Add(this.datePickerDatIni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModalFormInterv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intervento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datePickerDatIni;
        private System.Windows.Forms.ComboBox comboOraIni;
        private System.Windows.Forms.ComboBox comboOraIniMin;
        private System.Windows.Forms.ComboBox comboOraFinMin;
        private System.Windows.Forms.ComboBox comboOraFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboTip;
        private System.Windows.Forms.ComboBox comboNumOpe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtDescri;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblFat;
        private System.Windows.Forms.ComboBox comboCms;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.Label lblCmsImp;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lblCms_id;
        private System.Windows.Forms.Button btnTec;
        private System.Windows.Forms.ListBox listBoxTec;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}