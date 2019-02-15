namespace Cir.Fatt
{
    partial class SubFatt
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
            this.listViewIva = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCliIva = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCliNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.txtFatNum = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.lblFatId = new System.Windows.Forms.Label();
            this.btnDelRow = new System.Windows.Forms.Button();
            this.btnInsRow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.listViewTot = new System.Windows.Forms.ListView();
            this.btnStm = new System.Windows.Forms.Button();
            this.comboTipoDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRitAcc = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotDaPag = new System.Windows.Forms.Label();
            this.chkCmsAnticipo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewIva
            // 
            this.listViewIva.Location = new System.Drawing.Point(753, 186);
            this.listViewIva.Name = "listViewIva";
            this.listViewIva.Size = new System.Drawing.Size(228, 123);
            this.listViewIva.TabIndex = 67;
            this.listViewIva.UseCompatibleStateImageBehavior = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(629, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 15);
            this.label8.TabIndex = 65;
            this.label8.Text = "Partita Iva / Cod. Fiscale";
            // 
            // txtCliIva
            // 
            this.txtCliIva.Location = new System.Drawing.Point(632, 76);
            this.txtCliIva.Name = "txtCliIva";
            this.txtCliIva.Size = new System.Drawing.Size(160, 21);
            this.txtCliIva.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(629, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 63;
            this.label7.Text = "Intestazione";
            // 
            // txtCliNom
            // 
            this.txtCliNom.Location = new System.Drawing.Point(632, 23);
            this.txtCliNom.Name = "txtCliNom";
            this.txtCliNom.Size = new System.Drawing.Size(349, 21);
            this.txtCliNom.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(795, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 56;
            this.label1.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(891, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 57;
            this.label2.Text = "Data";
            // 
            // dataGrid
            // 
            this.dataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(5, 4);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(618, 375);
            this.dataGrid.TabIndex = 62;
            this.dataGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellEndEdit);
            this.dataGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellLeave);
            this.dataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGrid_KeyDown);
            this.dataGrid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGrid_KeyUp);
            this.dataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseDown);
            // 
            // txtFatNum
            // 
            this.txtFatNum.Location = new System.Drawing.Point(798, 135);
            this.txtFatNum.Name = "txtFatNum";
            this.txtFatNum.Size = new System.Drawing.Size(90, 21);
            this.txtFatNum.TabIndex = 58;
            this.txtFatNum.TextChanged += new System.EventHandler(this.txtFatNum_TextChanged);
            this.txtFatNum.DoubleClick += new System.EventHandler(this.txtFatNum_DoubleClick);
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(894, 135);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(86, 21);
            this.datePicker.TabIndex = 59;
            // 
            // lblFatId
            // 
            this.lblFatId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFatId.ForeColor = System.Drawing.Color.Gray;
            this.lblFatId.Location = new System.Drawing.Point(939, 7);
            this.lblFatId.Name = "lblFatId";
            this.lblFatId.Size = new System.Drawing.Size(42, 13);
            this.lblFatId.TabIndex = 69;
            this.lblFatId.Text = "00000";
            this.lblFatId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDelRow
            // 
            this.btnDelRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelRow.Location = new System.Drawing.Point(197, 386);
            this.btnDelRow.Name = "btnDelRow";
            this.btnDelRow.Size = new System.Drawing.Size(178, 30);
            this.btnDelRow.TabIndex = 71;
            this.btnDelRow.Text = "Cancella riga";
            this.btnDelRow.UseVisualStyleBackColor = true;
            this.btnDelRow.Click += new System.EventHandler(this.btnDelRow_Click);
            // 
            // btnInsRow
            // 
            this.btnInsRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsRow.Location = new System.Drawing.Point(5, 386);
            this.btnInsRow.Name = "btnInsRow";
            this.btnInsRow.Size = new System.Drawing.Size(186, 30);
            this.btnInsRow.TabIndex = 70;
            this.btnInsRow.Text = "Inserisci riga";
            this.btnInsRow.UseVisualStyleBackColor = true;
            this.btnInsRow.Click += new System.EventHandler(this.btnInsRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(881, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 68;
            this.btnSave.Text = "Conferma";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(753, 386);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(111, 30);
            this.btnDel.TabIndex = 72;
            this.btnDel.Text = "Elimina";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // listViewTot
            // 
            this.listViewTot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listViewTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewTot.Location = new System.Drawing.Point(753, 314);
            this.listViewTot.Name = "listViewTot";
            this.listViewTot.Size = new System.Drawing.Size(228, 65);
            this.listViewTot.TabIndex = 73;
            this.listViewTot.UseCompatibleStateImageBehavior = false;
            // 
            // btnStm
            // 
            this.btnStm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStm.FlatAppearance.BorderSize = 0;
            this.btnStm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStm.ForeColor = System.Drawing.Color.Black;
            this.btnStm.Location = new System.Drawing.Point(501, 386);
            this.btnStm.Name = "btnStm";
            this.btnStm.Size = new System.Drawing.Size(122, 30);
            this.btnStm.TabIndex = 76;
            this.btnStm.Text = "Prova stampa";
            this.btnStm.UseVisualStyleBackColor = true;
            this.btnStm.Visible = false;
            this.btnStm.Click += new System.EventHandler(this.btnStm_Click);
            // 
            // comboTipoDoc
            // 
            this.comboTipoDoc.FormattingEnabled = true;
            this.comboTipoDoc.Location = new System.Drawing.Point(632, 135);
            this.comboTipoDoc.Name = "comboTipoDoc";
            this.comboTipoDoc.Size = new System.Drawing.Size(160, 23);
            this.comboTipoDoc.TabIndex = 77;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(629, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 78;
            this.label3.Text = "Documento";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(628, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 15);
            this.label4.TabIndex = 79;
            this.label4.Text = "Ritenuta d\'acconto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRitAcc
            // 
            this.lblRitAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRitAcc.Location = new System.Drawing.Point(628, 208);
            this.lblRitAcc.Name = "lblRitAcc";
            this.lblRitAcc.Size = new System.Drawing.Size(120, 15);
            this.lblRitAcc.TabIndex = 80;
            this.lblRitAcc.Text = "0.00";
            this.lblRitAcc.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(628, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 81;
            this.label6.Text = "Totale da pagare";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTotDaPag
            // 
            this.lblTotDaPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotDaPag.Location = new System.Drawing.Point(628, 250);
            this.lblTotDaPag.Name = "lblTotDaPag";
            this.lblTotDaPag.Size = new System.Drawing.Size(120, 15);
            this.lblTotDaPag.TabIndex = 82;
            this.lblTotDaPag.Text = "0.00";
            this.lblTotDaPag.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkCmsAnticipo
            // 
            this.chkCmsAnticipo.AutoSize = true;
            this.chkCmsAnticipo.Location = new System.Drawing.Point(816, 76);
            this.chkCmsAnticipo.Name = "chkCmsAnticipo";
            this.chkCmsAnticipo.Size = new System.Drawing.Size(133, 19);
            this.chkCmsAnticipo.TabIndex = 83;
            this.chkCmsAnticipo.Text = "Anticipo commessa";
            this.chkCmsAnticipo.UseVisualStyleBackColor = true;
            // 
            // SubFatt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 420);
            this.Controls.Add(this.chkCmsAnticipo);
            this.Controls.Add(this.lblTotDaPag);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblRitAcc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboTipoDoc);
            this.Controls.Add(this.btnStm);
            this.Controls.Add(this.listViewTot);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.lblFatId);
            this.Controls.Add(this.btnDelRow);
            this.Controls.Add(this.btnInsRow);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listViewIva);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCliIva);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCliNom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.txtFatNum);
            this.Controls.Add(this.datePicker);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SubFatt";
            this.Text = "SubFatt";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewIva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCliIva;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCliNom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.TextBox txtFatNum;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label lblFatId;
        private System.Windows.Forms.Button btnDelRow;
        private System.Windows.Forms.Button btnInsRow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ListView listViewTot;
        private System.Windows.Forms.Button btnStm;
        private System.Windows.Forms.ComboBox comboTipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRitAcc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotDaPag;
        private System.Windows.Forms.CheckBox chkCmsAnticipo;
    }
}